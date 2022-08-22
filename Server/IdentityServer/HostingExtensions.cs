using Duende.IdentityServer;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.Extensions.DependencyInjection;
using IdentityServerHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Runtime.InteropServices;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add configuration file
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            builder.Configuration.AddJsonFile(@"C:\\inetpub\\TheFortressWebApp.conf.json", optional: false, reloadOnChange: true);
        }
        else //linux
        {
            builder.Configuration.AddJsonFile(@"/var/www/TheFortressWebApp.conf.json", optional: false, reloadOnChange: true);
        }

        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

        var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
        var dbString = builder.Configuration.GetValue<string>("DbConnection");
        builder.Services.AddIdentityServer()
            .AddConfigurationStore(o =>
            {
                o.ConfigureDbContext = b => b.UseSqlServer(dbString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddOperationalStore(o =>
            {
                o.ConfigureDbContext = b => b.UseSqlServer(dbString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddTestUsers(TestUsers.Users);


        //builder.Services.AddAuthentication()
        //    .AddOpenIdConnect("oidc", "Demo IdentityServer", options =>
        //    {
        //        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
        //        options.SignOutScheme = IdentityServerConstants.SignoutScheme;
        //        options.SaveTokens = true;

        //        options.Authority = "https://demo.duendesoftware.com";
        //        options.ClientId = "interactive.confidential";
        //        options.ClientSecret = "secret";
        //        options.ResponseType = "code";

        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            NameClaimType = "name",
        //            RoleClaimType = "role"
        //        };
        //    });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        InitializeDatabase(app);

        app.UseStaticFiles();
        app.UseRouting();
        app.UseStaticFiles();

        app.UseIdentityServer();


        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }

    private static void InitializeDatabase(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            //serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            //context.Database.Migrate();
            if (context.Clients.Any())
            {
                foreach (var client in Config.Clients)
                {
                    if (!context.Clients.Any(x => x.ClientId == client.ClientId))
                    {
                        context.Clients.Add(client.ToEntity()); 
                    }
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.IdentityResources)
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in Config.ApiScopes)
                {
                    context.ApiScopes.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
        }
    }
}