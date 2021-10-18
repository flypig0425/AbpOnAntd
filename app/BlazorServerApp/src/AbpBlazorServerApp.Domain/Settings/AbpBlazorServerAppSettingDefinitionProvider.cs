using Volo.Abp.Settings;

namespace AbpBlazorServerApp.Settings
{
    public class AbpBlazorServerAppSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpBlazorServerAppSettings.MySetting1));
        }
    }
}
