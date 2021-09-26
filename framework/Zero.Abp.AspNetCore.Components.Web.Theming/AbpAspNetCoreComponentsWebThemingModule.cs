using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Zero.Abp.AntdesignLayout;
using Zero.Abp.AntdesignUI;

namespace Zero.Abp.AspNetCore.Components.Web.Theming
{
    [DependsOn(
        typeof(AbpAntdesignUIModule),
        typeof(AbpAntdesignLayoutModule),
        typeof(AbpUiNavigationModule)
        )]
    public class AbpAspNetCoreComponentsWebThemingModule : AbpModule
    {

    }
}