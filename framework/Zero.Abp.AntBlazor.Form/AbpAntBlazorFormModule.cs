using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Zero.Abp.AntBlazor.Form.Localization;
using Zero.Abp.AntBlazorUI;

namespace Zero.Abp.AntBlazor.Form
{
    [DependsOn(
        typeof(AbpAntBlazorUIModule)
        )]
    public class AbpAntBlazorFormModule : AbpModule
    {
        private readonly string AssemblyName = typeof(AbpAntBlazorFormModule).Assembly.GetName().Name;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAntBlazorFormModule>(AssemblyName);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                .Add<AntBlazorFormResource>("en")
                .AddVirtualJson("/Localization/Resources/AntBlazorForm");
            });
        }

    }
}
