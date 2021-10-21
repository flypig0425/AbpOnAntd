using Volo.Abp.Modularity;
using Zero.Abp.FeatureManagement.Blazor.Server;

namespace Zero.Abp.TenantManagement.Blazor.Server
{
    [DependsOn(
        typeof(AbpTenantManagementBlazorModule),
        typeof(AbpFeatureManagementBlazorServerModule)
        )]
    public class AbpTenantManagementBlazorServerModule : AbpModule
    {

    }
}
