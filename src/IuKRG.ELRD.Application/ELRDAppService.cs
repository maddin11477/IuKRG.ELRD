using System;
using System.Collections.Generic;
using System.Text;
using IuKRG.ELRD.Localization;
using Volo.Abp.Application.Services;

namespace IuKRG.ELRD
{
    /* Inherit your application services from this class.
     */
    public abstract class ELRDAppService : ApplicationService
    {
        protected ELRDAppService()
        {
            LocalizationResource = typeof(ELRDResource);
        }
    }
}
