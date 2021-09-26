using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Web;

namespace Zero.Abp.AntdesignLayout
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebModule)
        )]
    public class AbpAntdesignLayoutModule : AbpModule
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
