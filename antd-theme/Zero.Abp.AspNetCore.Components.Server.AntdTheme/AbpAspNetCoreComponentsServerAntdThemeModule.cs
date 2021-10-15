using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Server.AntdTheme.Bundling;
using Zero.Abp.AspNetCore.Components.Server.Theming;
using Zero.Abp.AspNetCore.Components.Server.Theming.Bundling;
using Zero.Abp.AspNetCore.Components.Web.AntdTheme;
using Zero.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace Zero.Abp.AspNetCore.Components.Server.AntdTheme
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebAntdThemeModule),
        typeof(AbpAspNetCoreComponentsServerThemingModule)
        )]
    public class AbpAspNetCoreComponentsServerAntdThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new AntdThemeToolbarContributor());
            });

            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(BlazorAntdThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(BlazorStandardBundles.Styles.Global)
                            .AddContributors(typeof(BlazorAntdThemeStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(BlazorAntdThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(BlazorStandardBundles.Scripts.Global)
                            .AddContributors(typeof(BlazorAntdThemeScriptContributor));
                    });
            });
        }
    }
}
