using AbpBlazorServerApp.Blazor.Menus;
using AbpBlazorServerApp.EntityFrameworkCore;
using AbpBlazorServerApp.Localization;
using AbpBlazorServerApp.MultiTenancy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Net.Http;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using Zero.Abp.Account.Blazor.Server;
using Zero.Abp.AspNetCore.Components.Server.AntdTheme;
using Zero.Abp.AspNetCore.Components.Server.AntdTheme.Bundling;
using Zero.Abp.AspNetCore.Components.Web.Theming.Routing;
using Zero.Abp.Identity.Blazor.Server;
using Zero.Abp.SettingManagement.Blazor.Server;
using Zero.Abp.TenantManagement.Blazor.Server;

namespace AbpBlazorServerApp.Blazor
{
    [DependsOn(
        typeof(AbpBlazorServerAppApplicationModule),
        typeof(AbpBlazorServerAppEntityFrameworkCoreModule),
        typeof(AbpBlazorServerAppHttpApiModule),
        typeof(AbpAspNetCoreMultiTenancyModule),

        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAccountWebIdentityServerModule),

        typeof(AbpAutofacModule),
        typeof(AbpSwashbuckleModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpAspNetCoreSerilogModule),
        //typeof(AbpAccountBlazorServerModule),
        typeof(AbpAspNetCoreComponentsServerAntdThemeModule),
        typeof(AbpIdentityBlazorServerModule),
        typeof(AbpTenantManagementBlazorServerModule),
        typeof(AbpSettingManagementBlazorServerModule)
       )]
    public class AbpBlazorServerAppBlazorModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(AbpBlazorServerAppResource),
                    typeof(AbpBlazorServerAppDomainModule).Assembly,
                    typeof(AbpBlazorServerAppDomainSharedModule).Assembly,
                    typeof(AbpBlazorServerAppApplicationModule).Assembly,
                    typeof(AbpBlazorServerAppApplicationContractsModule).Assembly,
                    typeof(AbpBlazorServerAppBlazorModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureUrls(configuration);
            ConfigureBundles();
            ConfigureAuthentication(context, configuration);
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureSwaggerServices(context.Services);
            ConfigureAutoApiControllers();
            ConfigureHttpClient(context);
            ConfigureBlazorise(context);
            ConfigureRouter(context);
            ConfigureMenu(context);
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureBundles()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                // MVC UI
                //options.StyleBundles.Configure(
                //    BasicThemeBundles.Styles.Global,
                //    bundle =>
                //    {
                //        bundle.AddFiles("/global-styles.css");
                //    }
                //);

                //BLAZOR UI
                options.StyleBundles.Configure(
                    BlazorAntdThemeBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/blazor-global-styles.css");
                        //You can remove the following line if you don't use Blazor CSS isolation for components
                        bundle.AddFiles("/AbpBlazorServerApp.Blazor.styles.css");
                    }
                );
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "AbpBlazorServerApp";
                });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpBlazorServerAppDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}AbpBlazorServerApp.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpBlazorServerAppDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}AbpBlazorServerApp.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpBlazorServerAppApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}AbpBlazorServerApp.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpBlazorServerAppApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}AbpBlazorServerApp.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpBlazorServerAppBlazorModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en-US", "English", "🇺🇸"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-CN", "简体中文", "🇨🇳"));
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddAbpSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "AbpBlazorServerApp API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }

        private static void ConfigureHttpClient(ServiceConfigurationContext context)
        {
            context.Services.AddTransient(sp => new HttpClient
            {
                BaseAddress = new Uri("/")
            });
        }

        private void ConfigureBlazorise(ServiceConfigurationContext context)
        {
            //context.Services
            //    .AddBootstrapProviders()
            //    .AddFontAwesomeIcons();
        }

        private void ConfigureMenu(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AbpBlazorServerAppMenuContributor());
            });
        }

        private void ConfigureRouter(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AppAssembly = typeof(AbpBlazorServerAppBlazorModule).Assembly;
            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(AbpBlazorServerAppApplicationModule).Assembly);
            });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpBlazorServerAppBlazorModule>();
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var env = context.GetEnvironment();
            var app = context.GetApplicationBuilder();

            app.UseAbpRequestLocalization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseUnitOfWork();
            //app.UseIdentityServer();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AbpBlazorServerApp API");
            });
            app.UseConfiguredEndpoints();
        }
    }
}
