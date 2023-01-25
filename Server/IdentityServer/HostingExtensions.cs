using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Runtime.InteropServices;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using IdentityServer.Models;
using IdentityServer.DAL;
using AutoMapper;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add configuration file
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            builder.Configuration
                .AddJsonFile(@"C:\\inetpub\\TheFortressWebApp.conf.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
        else //linux
        {
            builder.Configuration
                .AddJsonFile(@"/var/www/TheFortressWebApp.conf.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        var mapperConfig = new MapperConfiguration(map =>
        {
            map.AddProfile<AutoMapperProfile>();
        });
        builder.Services.AddSingleton(mapperConfig.CreateMapper());


        var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
        var dbString = builder.Configuration.GetValue<string>("DbConnection");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(dbString));

        //builder.Services.AddScoped<IUserAuthRepository, UserAuthRepository>();
        builder.Services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();
        builder.Services.AddSingleton<IEmailService, EmailService>();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(o => o.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        var jwtSection = builder.Configuration.GetSection("JwtConfig");
        var audience = "";
        var issuer = "";
        var secret = jwtSection["Secret"];
        if (builder.Environment.IsProduction())
        {
            issuer = jwtSection["ValidIssuerPROD"];
            audience = jwtSection["ValidAudiencePROD"];
        }
        else
        {
            issuer = jwtSection["ValidIssuerDEV"];
            audience = jwtSection["ValidAudienceDEV"];
        }

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = audience,
                ValidIssuer = issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            };
        });

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