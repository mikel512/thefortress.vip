using Api.Data;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add configuration file
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    builder.Configuration.AddJsonFile(@"C:\\inetpub\\TheFortressWebApp.conf.json", optional: false, reloadOnChange: true);
}
else //linux
{
    builder.Configuration.AddJsonFile(@"/var/www/TheFortressWebApp.conf.json", optional: false, reloadOnChange: true);
}

// Configure DB connection
var dbString = builder.Configuration.GetValue<string>("DbConnection");
builder.Services.AddDbContext<TheFortressContext>(x => x.UseSqlServer(dbString));
IdentityModelEventSource.ShowPII = true;

// Configure DI
builder.Services.AddSingleton<IStorageService, StorageService>(); 


builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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


//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer(options =>
//    {
//        options.Authority = "https://localhost:5003";
//        options.TokenValidationParameters.ValidateAudience = false;
//    });
builder.Services.AddAuthorization(options =>
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireClaim("scope", "api1");
    })
);

// allow CORS requests from JS client
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



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
}
else
{
    app.UseHttpsRedirection();

}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
