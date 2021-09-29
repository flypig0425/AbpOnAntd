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

            var tenantManagementMenuItem = new ApplicationMenuItem(
                TenantManagementMenuNames.GroupName,
                "租户管理",
                icon: "team");

            administrationMenu.AddItem(tenantManagementMenuItem);
            for (int i = 0; i < 100; i++)
            {
                tenantManagementMenuItem.AddItem(new ApplicationMenuItem(
               $"{ TenantManagementMenuNames.Tenants}{i}",
             $"租户列表{i}",
             url: $"~/TenantManagement/Tenants?{i}")
             );
            }
            return Task.CompletedTask;
        }
    }
}
