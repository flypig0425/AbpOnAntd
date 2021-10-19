using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Zero.Abp.AntBlazorUI;

namespace Zero.Abp.AspNetCore.Components.Web.Theming
{
    [DependsOn(
        typeof(AbpAntdesignUIModule),
        typeof(AbpUiNavigationModule)
        )]
    public class AbpAspNetCoreComponentsWebThemingModule : AbpModule
    {

    }
}