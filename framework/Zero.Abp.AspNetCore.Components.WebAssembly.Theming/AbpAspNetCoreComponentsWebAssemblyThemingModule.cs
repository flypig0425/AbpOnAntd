using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Web.Theming;

namespace Zero.Abp.AspNetCore.Components.WebAssembly.Theming
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyModule)
    )]
    public class AbpAspNetCoreComponentsWebAssemblyThemingModule : AbpModule
    {

    }
}
