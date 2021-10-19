using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Zero.Abp.AspNetCore.Components.Web.Theming;

namespace Zero.Abp.AspNetCore.Components.Web.AntdTheme
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebThemingModule)
        )]
    public class AbpAspNetCoreComponentsWebAntdThemeModule : AbpModule
    {
        private readonly string AssemblyName = typeof(AbpAspNetCoreComponentsWebAntdThemeModule).Assembly.GetName().Name;
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreComponentsWebAntdThemeModule>(AssemblyName);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                .Add<AbpAntdThemeResource>("en")
                .AddVirtualJson("/Localization/Resources/AntdTheme");
            });
        }
    }
}