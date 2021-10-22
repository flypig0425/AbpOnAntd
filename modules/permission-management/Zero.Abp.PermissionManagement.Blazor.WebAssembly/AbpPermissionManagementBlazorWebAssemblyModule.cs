using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Zero.Abp.AspNetCore.Components.WebAssembly.Theming;

namespace Zero.Abp.PermissionManagement.Blazor.WebAssembly
{
    [DependsOn(
        typeof(AbpPermissionManagementBlazorModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
        typeof(AbpPermissionManagementHttpApiClientModule)
    )]
    public class AbpPermissionManagementBlazorWebAssemblyModule : AbpModule
    {
    }
}
