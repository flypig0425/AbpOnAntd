using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Web.AntdTheme;
using Zero.Abp.AspNetCore.Components.Web.Theming.Routing;
using Zero.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Zero.Abp.AspNetCore.Components.WebAssembly.Theming;
//using Zero.Abp.Http.Client.IdentityModel.WebAssembly;

namespace Zero.Abp.AspNetCore.Components.WebAssembly.AntdTheme
{
    [DependsOn(
        //typeof(AbpHttpClientIdentityModelWebAssemblyModule),
        typeof(AbpAspNetCoreComponentsWebAntdThemeModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class AbpAspNetCoreComponentsWebAssemblyAntdThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AbpAspNetCoreComponentsWebAssemblyAntdThemeModule).Assembly);
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new AntdThemeToolbarContributor());
            });
        }
    }
}
