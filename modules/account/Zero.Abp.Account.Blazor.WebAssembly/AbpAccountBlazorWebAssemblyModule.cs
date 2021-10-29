using Volo.Abp.Account;
using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.WebAssembly.Theming;

namespace Zero.Abp.Account.Blazor.WebAssembly
{
    [DependsOn(
        typeof(AbpAccountBlazorModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
        typeof(AbpAccountHttpApiClientModule)
    )]
    public class AbpAccountBlazorWebAssemblyModule : AbpModule
    {
    }
}
