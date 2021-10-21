using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Zero.Abp.FeatureManagement.Blazor.WebAssembly;

namespace Zero.Abp.TenantManagement.Blazor.WebAssembly
{
    [DependsOn(
        typeof(AbpTenantManagementBlazorModule),
        typeof(AbpFeatureManagementBlazorWebAssemblyModule),
        typeof(AbpTenantManagementHttpApiClientModule)
        )]
    public class AbpTenantManagementBlazorWebAssemblyModule : AbpModule
    {

    }
}
