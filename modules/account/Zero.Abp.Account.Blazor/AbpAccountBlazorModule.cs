using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Zero.Abp.AspNetCore.Components.Web.Theming;
using Zero.Abp.AspNetCore.Components.Web.Theming.Routing;

namespace Zero.Abp.Account.Blazor
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpIdentityAspNetCoreModule),
        //typeof(AbpExceptionHandlingModule),
        typeof(AbpAccountApplicationContractsModule)
        )]
    public class AbpAccountBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpAccountBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpAccountBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AbpAccountBlazorUserMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AbpAccountBlazorModule).Assembly);
            });
        }
    }
}
