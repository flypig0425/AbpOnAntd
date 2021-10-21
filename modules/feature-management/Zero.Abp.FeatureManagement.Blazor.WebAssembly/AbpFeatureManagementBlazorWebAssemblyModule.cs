using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.WebAssembly.Theming;

namespace Zero.Abp.FeatureManagement.Blazor.WebAssembly
{
    [DependsOn(
        typeof(AbpFeatureManagementBlazorModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
        typeof(AbpFeatureManagementHttpApiClientModule)
    )]
    public class AbpFeatureManagementBlazorWebAssemblyModule : AbpModule
    {
    }
}
