using Volo.Abp.Modularity;
using Zero.Abp.PermissionManagement.Blazor.Server;

namespace Zero.Abp.Identity.Blazor.Server
{
    [DependsOn(
        typeof(AbpIdentityBlazorModule),
        typeof(AbpPermissionManagementBlazorServerModule)
    )]
    public class AbpIdentityBlazorServerModule : AbpModule
    {
    }
}
