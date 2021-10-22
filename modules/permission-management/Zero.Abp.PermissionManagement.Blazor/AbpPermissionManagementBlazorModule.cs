using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Zero.Abp.AspNetCore.Components.Web.Theming;

namespace Zero.Abp.PermissionManagement.Blazor
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpPermissionManagementApplicationContractsModule)
        )]
    public class AbpPermissionManagementBlazorModule : AbpModule
    {

    }
}
