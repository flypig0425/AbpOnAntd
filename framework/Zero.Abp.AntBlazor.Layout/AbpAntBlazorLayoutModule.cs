using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Zero.Abp.AntBlazor.Layout.Core.LayoutConfig;
using Zero.Abp.AntBlazorUI;
using Zero.Abp.AntBlazorUI.Localization;

namespace Zero.Abp.AntBlazor.Layout
{
    [DependsOn(
        typeof(AbpAntBlazorUIModule)
        )]
    public class AbpAntBlazorLayoutModule : AbpModule
    {
        private readonly string AssemblyName = typeof(AbpAntBlazorLayoutModule).Assembly.GetName().Name;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAntBlazorLayoutModule>(AssemblyName);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                .Add<AbpAntBlazorUIResource>("en")
                .AddVirtualJson("/Localization/Resources/AntBlazorLayout");
            });

            ConfigureAntDesign(context);
        }

        private void ConfigureAntDesign(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var config = configuration.GetSection("AbpLayoutConfig");
            context.Services.Configure<AbpLayoutConfigOptions>(config);
        }
    }
}
