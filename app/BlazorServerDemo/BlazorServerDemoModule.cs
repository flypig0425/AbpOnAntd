using Antd.AbpDemo.Blazor.Menus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Net.Http;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;
using Zero.Abp.AspNetCore.Components.Server.BasicTheme;
using Zero.Abp.AspNetCore.Components.Server.BasicTheme.Bundling;
using Zero.Abp.AspNetCore.Components.Web.Theming.Routing;

namespace BlazorServerDemo
{
    [DependsOn(
       typeof(AbpAutofacModule),
       typeof(AbpSwashbuckleModule),
       typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
       typeof(AbpAspNetCoreSerilogModule),

       typeof(AbpAspNetCoreComponentsServerBasicThemeModule)
      )]
    public class BlazorServerDemoModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureUrls(configuration);
            ConfigureBundles();
            //ConfigureAuthentication(context, configuration);
            //ConfigureAutoMapper();
            //ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            //ConfigureAutoApiControllers();
            ConfigureHttpClient(context);
            //ConfigureAntDesign(context);
            ConfigureRouter(context);
            ConfigureMenu(context);
            ConfigureCors(context, configuration);
            ConfigureSwaggerServices(context.Services);
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
                //// MVC UI
                //options.StyleBundles.Configure(
                //    BasicThemeBundles.Styles.Global,
                //    bundle =>
                //    {
                //        bundle.AddFiles("/global-styles.css");
                //    }
                //);

                //BLAZOR UI
                options.StyleBundles.Configure(
                    BlazorBasicThemeBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/blazor-global-styles.css");
                        ////You can remove the following line if you don't use Blazor CSS isolation for components
                        //bundle.AddFiles("/Antd.AbpDemo.Blazor.styles.css");
                    }
                );
            });
        }


        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en-US", "English", "🇺🇸"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-CN", "简体中文", "🇨🇳"));
                //options.Languages.Add(new LanguageInfo("zh-Hant", "zh-TW", "繁體中文", "🇭🇰"));
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddAbpSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "AbpDemo API", Version = "v1" });
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

        private void ConfigureAntDesign(ServiceConfigurationContext context)
        {
            context.Services
                .AddAntDesign();
        }

        private void ConfigureMenu(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new BlazorServerDemoMenuContributor());
                options.MenuContributors.Add(new TenantManagementWebMainMenuContributor());
            });
        }

        private void ConfigureRouter(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AppAssembly = typeof(BlazorServerDemoModule).Assembly;
            });
        }
        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
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
            app.UseCors();
            //app.UseAuthentication();
            //app.UseJwtTokenMiddleware();

            app.UseUnitOfWork();
            //app.UseIdentityServer();
            //app.UseAuthorization();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AbpDemo API");
            });
            app.UseConfiguredEndpoints();
        }
    }
}