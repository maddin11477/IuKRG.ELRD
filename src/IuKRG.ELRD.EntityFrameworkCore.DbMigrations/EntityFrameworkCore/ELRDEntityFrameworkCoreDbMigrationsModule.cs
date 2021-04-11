using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace IuKRG.ELRD.EntityFrameworkCore
{
    [DependsOn(
        typeof(ELRDEntityFrameworkCoreModule)
        )]
    public class ELRDEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ELRDMigrationsDbContext>();
        }
    }
}
