using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.WebAssembly.Theming;

namespace Zero.Abp.SettingManagement.Blazor.WebAssembly
{
    [DependsOn(
        typeof(AbpSettingManagementBlazorModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    //,typeof(AbpSettingManagementHttpApiClientModule)
    )]
    public class AbpSettingManagementBlazorWebAssemblyModule : AbpModule
    {
    }
}
