using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Zero.Abp.PermissionManagement.Blazor.WebAssembly;

namespace Zero.Abp.Identity.Blazor.WebAssembly
{
    [DependsOn(
        typeof(AbpIdentityBlazorModule),
        typeof(AbpPermissionManagementBlazorWebAssemblyModule),
        typeof(AbpIdentityHttpApiClientModule)
    )]
    public class AbpIdentityBlazorWebAssemblyModule : AbpModule
    {
    }
}
