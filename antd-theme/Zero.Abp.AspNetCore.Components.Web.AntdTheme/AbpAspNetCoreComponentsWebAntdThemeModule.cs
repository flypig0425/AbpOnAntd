using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Zero.Abp.AntdesignUI;
using Zero.Abp.AspNetCore.Components.Web.Theming;

namespace Zero.Abp.AspNetCore.Components.Web.AntdTheme
{
    [DependsOn(
        typeof(AbpAntdesignUIModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule)
        )]
    public class AbpAspNetCoreComponentsWebAntdThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureAntDesign(context);
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreComponentsWebAntdThemeModule>(AbpAntdTheme.AssemblyName);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                .Add<AbpAntdThemeResource>("en")
                .AddVirtualJson("/Localization/Resources/AntdTheme");
            });
        }

        private void ConfigureAntDesign(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var config = configuration.GetSection("AbpLayoutConfig");
            context.Services.Configure<AbpLayoutConfigOptions>(config);
            context.Services.AddAntDesign();
        }
    }
}