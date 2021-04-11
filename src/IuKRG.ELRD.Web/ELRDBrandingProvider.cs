using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace IuKRG.ELRD.Web
{
    [Dependency(ReplaceServices = true)]
    public class ELRDBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ELRD";
    }
}
