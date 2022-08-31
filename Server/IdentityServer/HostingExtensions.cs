using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Runtime.InteropServices;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using IdentityServer.Models;
using IdentityServer.DAL;
using AutoMapper;

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

        var mapperConfig = new MapperConfiguration(map =>
        {
            map.AddProfile<UserMappingProfile>();
        });
        builder.Services.AddSingleton(mapperConfig.CreateMapper());


        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

        var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
        var dbString = builder.Configuration.GetValue<string>("DbConnection");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(dbString));

        //builder.Services.AddScoped<IUserAuthRepository, UserAuthRepository>();
        builder.Services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddCors(options =>
        {
            // this defines a CORS policy called "default"
            options.AddPolicy("default", policy =>
            {
                policy.WithOrigins("https://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseCors("default");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

}