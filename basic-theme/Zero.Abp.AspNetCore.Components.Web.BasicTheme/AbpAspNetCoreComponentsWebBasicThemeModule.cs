using Volo.Abp.Modularity;
using Zero.Abp.AntdesignUI;
using Zero.Abp.AspNetCore.Components.Web.Theming;

namespace Zero.Abp.AspNetCore.Components.Web.BasicTheme
{
    [DependsOn(
        typeof(AbpAntdesignUIModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule)
        )]
    public class AbpAspNetCoreComponentsWebBasicThemeModule : AbpModule
    {

    }
}