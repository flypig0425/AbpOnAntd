using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
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
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureAntDesign(context);
            context.Services.AddSingleton(typeof(AbpBlazorMessageLocalizerHelper<>));
        }

        private void ConfigureAntDesign(ServiceConfigurationContext context)
        {
            context.Services.AddAntDesign();
        }
    }
}
