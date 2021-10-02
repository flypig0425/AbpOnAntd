using Localization.Resources.AbpUi;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Antd.AbpDemo.Blazor.Menus
{
    public class TenantManagementWebMainMenuContributor : IMenuContributor
    {
        public virtual Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var administrationMenu = context.Menu.GetAdministration();

            var l = context.GetLocalizer<AbpUiResource>();

            for (int t = 0; t < 10; t++)
            {
                var tenantManagementMenuItem = new ApplicationMenuItem(
                    $"{  TenantManagementMenuNames.GroupName}{t}",
                  $"租户管理{t}",
                  icon: "team");

                administrationMenu.AddItem(tenantManagementMenuItem);
                for (int i = 0; i < 10; i++)
                {
                    tenantManagementMenuItem.AddItem(new ApplicationMenuItem(
                   $"{ TenantManagementMenuNames.Tenants}{t}{i}",
                 $"租户列表{t}{i}",
                 url: $"~/TenantManagement/Tenants/{t}{i}")
                 );
                }
            }


            return Task.CompletedTask;
        }
    }
}
