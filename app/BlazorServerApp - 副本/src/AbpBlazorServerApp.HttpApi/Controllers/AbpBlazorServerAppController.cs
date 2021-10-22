using AbpBlazorServerApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpBlazorServerApp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpBlazorServerAppController : AbpController
    {
        protected AbpBlazorServerAppController()
        {
            LocalizationResource = typeof(AbpBlazorServerAppResource);
        }
    }
}