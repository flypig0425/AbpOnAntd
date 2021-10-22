using System;
using System.Collections.Generic;
using System.Text;
using AbpBlazorServerApp.Localization;
using Volo.Abp.Application.Services;

namespace AbpBlazorServerApp
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpBlazorServerAppAppService : ApplicationService
    {
        protected AbpBlazorServerAppAppService()
        {
            LocalizationResource = typeof(AbpBlazorServerAppResource);
        }
    }
}
