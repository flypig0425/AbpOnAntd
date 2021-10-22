using Volo.Abp.Modularity;
using Zero.Abp.AntBlazorUI;
using Zero.Abp.AspNetCore.Components.Web.Theming;

namespace Zero.Abp.AspNetCore.Components.WebAssembly.Theming
{
    [DependsOn(
        typeof(AbpAntBlazorUIModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyModule)
    )]
    public class AbpAspNetCoreComponentsWebAssemblyThemingModule : AbpModule
    {

    }
}
