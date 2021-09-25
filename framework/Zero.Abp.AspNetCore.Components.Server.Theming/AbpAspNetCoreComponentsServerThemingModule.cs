using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Server.Theming.Bundling;
using Zero.Abp.AspNetCore.Components.Web.Theming;
using Zero.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Zero.Abp.AspNetCore.Components.Server.Theming
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAspNetCoreMvcUiBundlingModule)
        )]
    public class AbpAspNetCoreComponentsServerThemingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(BlazorStandardBundles.Styles.Global, bundle =>
                    {
                        bundle.AddContributors(typeof(BlazorGlobalStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(BlazorStandardBundles.Scripts.Global, bundle =>
                    {
                        bundle.AddContributors(typeof(BlazorGlobalScriptContributor));
                    });
            });
        }
    }
}