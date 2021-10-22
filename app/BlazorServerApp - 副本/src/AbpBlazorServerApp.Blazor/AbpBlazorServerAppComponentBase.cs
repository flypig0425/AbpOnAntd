using AbpBlazorServerApp.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpBlazorServerApp.Blazor
{
    public abstract class AbpBlazorServerAppComponentBase : AbpComponentBase
    {
        protected AbpBlazorServerAppComponentBase()
        {
            LocalizationResource = typeof(AbpBlazorServerAppResource);
        }
    }
}
