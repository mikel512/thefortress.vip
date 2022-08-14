using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;
using System.Reflection;
using System.Runtime.InteropServices;
using TheFortress.API.Data;
using TheFortress.API.Models;

var builder = WebApplication.CreateBuilder(args);

if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    builder.Configuration.AddJsonFile(@"C:\\inetpub\\TheFortressWebApp.conf.json", optional: false, reloadOnChange: true);

}
else //linux
{
    builder.Configuration.AddJsonFile(@"/var/www/TheFortressWebApp.conf.json", optional: false, reloadOnChange: true);

}

IdentityModelEventSource.ShowPII = true;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
    {
        builder.Configuration.Bind("AzureAdB2C", options);

        options.TokenValidationParameters.NameClaimType = "name";
    },
    options =>
    {
        builder.Configuration.Bind("AzureAdB2C", options);
    });

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TheFortressContext>(x => x.UseSqlServer(builder.Configuration.GetValue<string>("DbConnection")));

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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
