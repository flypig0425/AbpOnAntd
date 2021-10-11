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

            for (int t = 0; t < 2; t++)
            {
                var tenantManagementMenuItem = new ApplicationMenuItem(
                    $"{  TenantManagementMenuNames.GroupName}{t}",
                  $"租户管理{t}",
                  icon: "team");

                administrationMenu.AddItem(tenantManagementMenuItem);

                var tenantManagementMenuItem1 = new ApplicationMenuItem(
                  $"{  TenantManagementMenuNames.GroupName}{t}_1",
                $"租户管理{t}_1",
                icon: "team");

                tenantManagementMenuItem.AddItem(tenantManagementMenuItem1);
                for (int i = 0; i < 2; i++)
                {
                    tenantManagementMenuItem1.AddItem(new ApplicationMenuItem(
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
