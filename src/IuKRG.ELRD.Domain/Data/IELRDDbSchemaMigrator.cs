using System.Threading.Tasks;

namespace IuKRG.ELRD.Data
{
    public interface IELRDDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
