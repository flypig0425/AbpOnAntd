using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Web;

namespace Zero.Abp.AntdesignUI
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class AbpAntdesignUIModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureBlazorise(context);
        }

        private void ConfigureBlazorise(ServiceConfigurationContext context)
        {
            context.Services.AddAntDesign();
            context.Services.AddSingleton(typeof(AbpBlazorMessageLocalizerHelper<>));
        }
    }
}
