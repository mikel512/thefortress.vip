using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection; 

namespace TheFortress.API
{
    public class CustomEFDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Decorate<IDatabaseModelFactory, CustomSqlServerDatabaseModelFactory>();
        }
    }
}
