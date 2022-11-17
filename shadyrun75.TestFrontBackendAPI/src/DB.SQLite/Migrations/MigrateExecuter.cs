using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace shadyrun75.TestFrontBackendAPI.DB.SQLite.Migrations
{
    public class MigrateExecuter
    {
        public static void Main(string migrationAssemblyPath, string dbPath)
        {
            var connectionString = $"Data Source={dbPath};Cache=Shared";
            var serviceProvider = CreateServices(migrationAssemblyPath, connectionString);

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices(string migrationAssemblyPath, string connectionString)
        {
            Assembly migrationAssembly = Assembly.LoadFrom(migrationAssemblyPath);
            var sc = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                .AddSQLite()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(migrationAssembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
            return sc;
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
    }
}