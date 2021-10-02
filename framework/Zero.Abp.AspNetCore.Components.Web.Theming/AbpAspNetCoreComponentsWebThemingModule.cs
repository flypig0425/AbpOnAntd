using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AspNetCore.Components.Web.Theming
{
    [DependsOn(
        typeof(AbpUiNavigationModule)
        )]
    public class AbpAspNetCoreComponentsWebThemingModule : AbpModule
    {

    }
}