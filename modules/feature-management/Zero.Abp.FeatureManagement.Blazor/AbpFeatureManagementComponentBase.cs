using Volo.Abp.FeatureManagement.Localization;
using Zero.Abp.AspNetCore.Components;

namespace Zero.Abp.FeatureManagement.Blazor
{
    public abstract class AbpFeatureManagementComponentBase : AbpComponentBase
    {
        protected AbpFeatureManagementComponentBase()
        {
            LocalizationResource = typeof(AbpFeatureManagementResource);
        }
    }
}