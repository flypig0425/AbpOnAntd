using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Zero.Abp.AspNetCore.Components.Web.Theming;
using Zero.Abp.AspNetCore.Components.Web.Theming.Routing;
using Zero.Abp.SettingManagement.Blazor.Menus;

namespace Zero.Abp.SettingManagement.Blazor
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule)
        //,typeof(AbpSettingManagementApplicationContractsModule)
    )]
    public class AbpSettingManagementBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpSettingManagementBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<SettingManagementBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new SettingManagementMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AbpSettingManagementBlazorModule).Assembly);
            });

            //Configure<SettingManagementComponentOptions>(options =>
            //{
            //    options.Contributors.Add(new EmailingPageContributor());
            //});
        }
    }
}
