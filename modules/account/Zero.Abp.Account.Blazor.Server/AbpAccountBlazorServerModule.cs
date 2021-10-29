using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Server.Theming;

namespace Zero.Abp.Account.Blazor.Server
{
    [DependsOn(
        typeof(AbpAccountBlazorModule),
        typeof(AbpAspNetCoreComponentsServerThemingModule)
        )]
    public class AbpAccountBlazorServerModule : AbpModule
    {

    }
}
