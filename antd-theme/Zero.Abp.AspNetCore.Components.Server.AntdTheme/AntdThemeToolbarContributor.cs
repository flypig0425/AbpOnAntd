using System.Threading.Tasks;
using Zero.Abp.AntdesignUI.Components;
using Zero.Abp.AspNetCore.Components.Server.AntdTheme.Themes;
using Zero.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace Zero.Abp.AspNetCore.Components.Server.AntdTheme
{
    public class AntdThemeToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name == StandardToolbars.Main)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(FullScreen)));
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            }

            return Task.CompletedTask;
        }
    }
}
