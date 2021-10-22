using AbpBlazorServerApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpBlazorServerApp.Permissions
{
    public class AbpBlazorServerAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpBlazorServerAppPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpBlazorServerAppPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpBlazorServerAppResource>(name);
        }
    }
}
