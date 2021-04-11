using IuKRG.ELRD.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace IuKRG.ELRD.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ELRDPageModel : AbpPageModel
    {
        protected ELRDPageModel()
        {
            LocalizationResourceType = typeof(ELRDResource);
        }
    }
}