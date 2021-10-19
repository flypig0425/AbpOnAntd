using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Zero.Abp.AntBlazor.Layout;

namespace Zero.Abp.AspNetCore.Components.Web.Theming
{
    [DependsOn(
        typeof(AbpAntBlazorLayoutModule),
        typeof(AbpUiNavigationModule)
        )]
    public class AbpAspNetCoreComponentsWebThemingModule : AbpModule
    {

    }
}