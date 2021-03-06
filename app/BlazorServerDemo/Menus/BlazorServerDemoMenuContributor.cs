using Localization.Resources.AbpUi;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace BlazorServerDemo.Menus
{
    public class BlazorServerDemoMenuContributor : IMenuContributor
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
            var l = context.GetLocalizer<AbpUiResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    BlazorServerDemoMenus.Home,
                   l["Menu:Home"],
                    "/",
                    icon: "fas fa-home",
                    order: 0
                )
            );
           
            administration.AddItem(new ApplicationMenuItem(
                "PageContainer_Basic",
              "页面1", "/PageDemo", icon: "fas fa-home", order: 0));


            //if (MultiTenancyConsts.IsEnabled)
            //{
            //administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            //}
            //else
            //{
            //    administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            //}

            //administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            //administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

            return Task.CompletedTask;
        }
    }
}
