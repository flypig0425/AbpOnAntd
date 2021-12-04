using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Zero.Abp.AntBlazor.Field.Localization;
using Zero.Abp.AntBlazor.Layout.LayoutConfig;
using Zero.Abp.AntBlazor.Layout.Localization;
using Zero.Abp.AntBlazorUI;

namespace Zero.Abp.AntBlazor.Field
{
    [DependsOn(
        typeof(AbpAntBlazorUIModule)
        )]
    public class AbpAntBlazorFieldModule : AbpModule
    {
        private readonly string AssemblyName = typeof(AbpAntBlazorFieldModule).Assembly.GetName().Name;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAntBlazorFieldModule>(AssemblyName);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                .Add<AntBlazorFieldResource>("en")
                .AddVirtualJson("/Localization/Resources/AntBlazorField");
            });
        }

    }
}
