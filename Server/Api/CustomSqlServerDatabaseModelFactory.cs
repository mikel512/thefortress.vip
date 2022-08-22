using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Data.Common;

namespace TheFortress.API
{
    public class CustomSqlServerDatabaseModelFactory : IDatabaseModelFactory
    {
        private IDatabaseModelFactory databaseModelFactory;

        private static readonly List<string> ExcludedTables = new List<string>
        {
            "ApiResourceClaims",
            "ApiResourceProperties",
            "ApiResources",
            "ApiResourceScopes",
            "ApiResourceSecrets",
            "ApiScopeClaims",
            "ApiScopeProperties",
            "ApiScopes",
            "ClientClaims",
            "ClientCorsOrigins",
            "ClientGrantTypes",
            "ClientIdPRestrictions",
            "ClientPostLogoutRedirectUris",
            "ClientProperties",
            "ClientRedirectUris",
            "Clients",
            "ClientScopes",
            "ClientSecrets", 
            "ClientClaims",
            "DeviceCodes",
            "IdentityProviders",
            "IdentityResourceClaims",
            "IdentityResourceProperties",
            "IdentityResources",
            "Keys",
            "PersistedGrants",
            "ServerSideSessions",
        };

        public CustomSqlServerDatabaseModelFactory(IDatabaseModelFactory databaseModelFactory)
        {
            this.databaseModelFactory = databaseModelFactory;
        }

        public DatabaseModel Create(string connectionString, DatabaseModelFactoryOptions options)
        {
            var databaseModel = databaseModelFactory.Create(connectionString, options);

            RemoveTables(databaseModel);

            return databaseModel;
        }

        public DatabaseModel Create(DbConnection connection, DatabaseModelFactoryOptions options)
        {
            var databaseModel = databaseModelFactory.Create(connection, options);

            RemoveTables(databaseModel);

            return databaseModel;
        }

        private static void RemoveTables(DatabaseModel databaseModel)
        {
            var tablesToBeRemoved = databaseModel.Tables.Where(x => ExcludedTables.Contains(x.Name)).ToList();

            foreach (var tableToRemove in tablesToBeRemoved)
            {
                databaseModel.Tables.Remove(tableToRemove);
            }
        }
    }
}
