using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace IuKRG.ELRD.Data
{
    /* This is used if database provider does't define
     * IELRDDbSchemaMigrator implementation.
     */
    public class NullELRDDbSchemaMigrator : IELRDDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}