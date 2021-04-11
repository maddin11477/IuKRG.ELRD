using IuKRG.ELRD.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace IuKRG.ELRD.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ELRDController : AbpController
    {
        protected ELRDController()
        {
            LocalizationResource = typeof(ELRDResource);
        }
    }
}