using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Authorization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Zero.Abp.AntBlazorUI.Localization;
using Zero.Abp.AspNetCore.Components.Web;

namespace Zero.Abp.AntBlazorUI
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebModule),
        typeof(AbpAuthorizationModule)
        )]
    public class AbpAntdesignUIModule : AbpModule
    {
        private readonly string AssemblyName = typeof(AbpAntdesignUIModule).Assembly.GetName().Name;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Localization.AbpStringLocalizerFactory.Replace(context.Services);

            context.Services.AddSingleton(typeof(AbpBlazorMessageLocalizerHelper<>));
            context.Services.AddAntDesign();

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAntdesignUIModule>(AssemblyName);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                .Add<AbpAntdesignUIResource>("en")
                .AddVirtualJson("/Localization/Resources/AbpAntdesignUI");
            });
        }

    }
}
