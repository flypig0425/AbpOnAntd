using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Zero.Abp.AntdesignUI.Layout;
using Zero.Abp.AntdesignUI.Localization;
using Zero.Abp.AspNetCore.Components.Web;
using Zero.Abp.AspNetCore.Components.Web.Theming;

namespace Zero.Abp.AntdesignUI
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class AbpAntdesignUIModule : AbpModule
    {
        private readonly string AssemblyName = typeof(AbpAntdesignUIModule).Assembly.GetName().Name;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Localization.AbpStringLocalizerFactory.Replace(context.Services);

            ConfigureAntDesign(context);
            context.Services.AddSingleton(typeof(AbpBlazorMessageLocalizerHelper<>));


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

        private void ConfigureAntDesign(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var config = configuration.GetSection("AbpLayoutConfig");
            context.Services.Configure<AbpLayoutConfigOptions>(config);
            context.Services.AddAntDesign();
        }
    }
}
