using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vApplication.Context;

public class TheFortressDbContextFactory : IDesignTimeDbContextFactory<TheFortressContext>
{
    public TheFortressContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("C:\\inetpub\\TheFortressWebApp.conf.json")
            .Build();

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<TheFortressContext>();
        var connectionString = configuration.GetValue<string>("DbConnection");
        dbContextOptionsBuilder
            .UseSqlServer(connectionString);

        return new TheFortressContext(dbContextOptionsBuilder.Options);
    }
}
