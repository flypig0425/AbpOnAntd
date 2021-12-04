using AbpBlazorServerApp.Localization;
using AbpBlazorServerApp.MultiTenancy;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using Zero.Abp.Identity.Blazor;
using Zero.Abp.SettingManagement.Blazor.Menus;
using Zero.Abp.TenantManagement.Blazor.Navigation;

namespace AbpBlazorServerApp.Blazor.Menus
{
    public class AbpBlazorServerAppMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<AbpBlazorServerAppResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    AbpBlazorServerAppMenus.Home,
                    l["Menu:Home"],
                    "/",
                    //icon: "fa fa-home",
                    order: 0
                )
            );

            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

            return Task.CompletedTask;
        }
    }
}
