using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Server.Theming;

namespace Zero.Abp.PermissionManagement.Blazor.Server
{
    [DependsOn(
        typeof(AbpPermissionManagementBlazorModule),
        typeof(AbpAspNetCoreComponentsServerThemingModule)
    )]
    public class AbpPermissionManagementBlazorServerModule : AbpModule
    {
    }
}
