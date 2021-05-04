using IuKRG.ELRD.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
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

            // Get environment value from launch settings
            var env = Environment.GetEnvironmentVariable("ENVIRONMENT");
            // Set builder options
            Configure<AbpConfigurationBuilderOptions>(options =>
            {
                options.EnvironmentName = env;
                options.FileName = $"appsettings.{env}";
            });

        }
    }
}
