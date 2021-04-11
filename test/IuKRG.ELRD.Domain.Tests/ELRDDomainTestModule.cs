using IuKRG.ELRD.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace IuKRG.ELRD
{
    [DependsOn(
        typeof(ELRDEntityFrameworkCoreTestModule)
        )]
    public class ELRDDomainTestModule : AbpModule
    {

    }
}