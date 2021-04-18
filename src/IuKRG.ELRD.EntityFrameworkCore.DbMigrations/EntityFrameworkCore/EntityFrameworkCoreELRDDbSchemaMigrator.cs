using System;
using System.Threading.Tasks;
using IuKRG.ELRD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace IuKRG.ELRD.EntityFrameworkCore
{
    public class EntityFrameworkCoreELRDDbSchemaMigrator
        : IELRDDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreELRDDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ELRDMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ELRDMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}