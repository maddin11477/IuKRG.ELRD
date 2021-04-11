using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IuKRG.ELRD.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class ELRDMigrationsDbContextFactory : IDesignTimeDbContextFactory<ELRDMigrationsDbContext>
    {
        public ELRDMigrationsDbContext CreateDbContext(string[] args)
        {
            ELRDEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ELRDMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new ELRDMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../IuKRG.ELRD.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
