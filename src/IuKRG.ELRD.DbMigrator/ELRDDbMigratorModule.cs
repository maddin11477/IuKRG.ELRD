using IuKRG.ELRD.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace IuKRG.ELRD.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ELRDEntityFrameworkCoreDbMigrationsModule),
        typeof(ELRDApplicationContractsModule)
        )]
    public class ELRDDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
