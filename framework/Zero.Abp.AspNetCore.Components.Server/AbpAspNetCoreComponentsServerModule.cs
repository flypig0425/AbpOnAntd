using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.AspNetCore.Auditing;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.AspNetCore.Uow;
using Volo.Abp.EventBus;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Zero.Abp.AspNetCore.Components.Web;

namespace Zero.Abp.AspNetCore.Components.Server
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreComponentsWebModule),
        typeof(AbpAspNetCoreSignalRModule),
        typeof(AbpEventBusModule),
        typeof(AbpAspNetCoreMvcContractsModule)
        )]
    public class AbpAspNetCoreComponentsServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var serverSideBlazorBuilder = context.Services.AddServerSideBlazor();
            context.Services.ExecutePreConfiguredActions(serverSideBlazorBuilder);

            Configure<AbpAspNetCoreUnitOfWorkOptions>(options =>
            {
                options.IgnoredUrls.AddIfNotContains("/_blazor");
            });

            Configure<AbpAspNetCoreAuditingOptions>(options =>
            {
                options.IgnoredUrls.AddIfNotContains("/_blazor");
            });

            Configure<AbpEndpointRouterOptions>(options =>
            {
                options.EndpointConfigureActions.Add(endpointContext =>
                {
                    endpointContext.Endpoints.MapBlazorHub();
                    endpointContext.Endpoints.MapFallbackToPage("/_Host");
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.GetEnvironment().WebRootFileProvider =
                new CompositeFileProvider(
                    new ManifestEmbeddedFileProvider(typeof(IServerSideBlazorBuilder).Assembly),
                    context.GetEnvironment().WebRootFileProvider
                );
        }
    }
}
