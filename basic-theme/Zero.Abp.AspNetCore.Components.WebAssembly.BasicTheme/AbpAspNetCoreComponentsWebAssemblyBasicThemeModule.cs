using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Web.BasicTheme;
using Zero.Abp.AspNetCore.Components.Web.Theming.Routing;
using Zero.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Zero.Abp.AspNetCore.Components.WebAssembly.Theming;

namespace Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme
{
    [DependsOn(
        //typeof(AbpHttpClientIdentityModelWebAssemblyModule),
        typeof(AbpAspNetCoreComponentsWebBasicThemeModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class AbpAspNetCoreComponentsWebAssemblyBasicThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AbpAspNetCoreComponentsWebAssemblyBasicThemeModule).Assembly);
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new BasicThemeToolbarContributor());
            });
        }
    }
}
