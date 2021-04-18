using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace IuKRG.ELRD.Web
{
    [Dependency(ReplaceServices = true)]
    public class ELRDBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ELRD";
    }
}
