using Volo.Abp.Modularity;

namespace IuKRG.ELRD
{
    [DependsOn(
        typeof(ELRDApplicationModule),
        typeof(ELRDDomainTestModule)
        )]
    public class ELRDApplicationTestModule : AbpModule
    {

    }
}