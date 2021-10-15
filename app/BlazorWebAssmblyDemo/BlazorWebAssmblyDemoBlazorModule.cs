using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Web.AntdTheme.Basic;
using Zero.Abp.AspNetCore.Components.Web.Theming.Routing;
using Zero.Abp.AspNetCore.Components.WebAssembly.AntdTheme;

namespace BlazorWebAssmblyDemo
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebAssemblyAntdThemeModule)
    )]
    public class BlazorWebAssmblyDemoBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
            var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();

            ConfigureHttpClient(context, environment);
            ConfigureRouter(context);
            ConfigureUI(builder);
        }

        private void ConfigureRouter(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AppAssembly = typeof(BlazorWebAssmblyDemoBlazorModule).Assembly;
            });
        }

        private static void ConfigureUI(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#ApplicationContainer");
        }

        private static void ConfigureHttpClient(ServiceConfigurationContext context, IWebAssemblyHostEnvironment environment)
        {
            context.Services.AddTransient(sp => new HttpClient
            {
                BaseAddress = new Uri(environment.BaseAddress)
            });
        }

    }
}
