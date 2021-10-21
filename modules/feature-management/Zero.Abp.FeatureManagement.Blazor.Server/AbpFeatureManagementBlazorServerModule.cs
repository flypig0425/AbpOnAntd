using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Server.Theming;

namespace Zero.Abp.FeatureManagement.Blazor.Server
{
    [DependsOn(
        typeof(AbpFeatureManagementBlazorModule),
        typeof(AbpAspNetCoreComponentsServerThemingModule)
        )]
    public class AbpFeatureManagementBlazorServerModule : AbpModule
    {

    }
}
