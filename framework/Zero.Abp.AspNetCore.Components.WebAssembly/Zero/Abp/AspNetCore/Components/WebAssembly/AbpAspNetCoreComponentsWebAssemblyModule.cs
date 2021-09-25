using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.AspNetCore.Mvc.Client;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.UI;
using Zero.Abp.AspNetCore.Components.Web;
using Zero.Abp.AspNetCore.Components.Web.ExceptionHandling;

namespace Zero.Abp.AspNetCore.Components.WebAssembly
{
    [DependsOn(
        typeof(AbpUiModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcClientCommonModule),
        typeof(AbpAspNetCoreComponentsWebModule)
        )]
    public class AbpAspNetCoreComponentsWebAssemblyModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpHttpClientBuilderOptions>(options =>
            {
                options.ProxyClientBuildActions.Add((_, builder) =>
                {
                    builder.AddHttpMessageHandler<AbpBlazorClientHttpMessageHandler>();
                });
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services
                .GetHostBuilder().Logging
                .AddProvider(new AbpExceptionHandlingLoggerProvider(context.Services));
        }
    }
}
