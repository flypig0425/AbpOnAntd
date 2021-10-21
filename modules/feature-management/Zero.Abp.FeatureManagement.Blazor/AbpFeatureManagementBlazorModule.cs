using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Features;
using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Web.Theming;

namespace Zero.Abp.FeatureManagement.Blazor
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpFeaturesModule)
    )]
    public class AbpFeatureManagementBlazorModule : AbpModule
    {

    }
}