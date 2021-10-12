using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Server.Theming;

namespace Zero.Abp.SettingManagement.Blazor.Server
{
    [DependsOn(
        typeof(AbpSettingManagementBlazorModule),
        typeof(AbpAspNetCoreComponentsServerThemingModule)
    )]
    public class AbpSettingManagementBlazorServerModule : AbpModule
    {
    }
}
