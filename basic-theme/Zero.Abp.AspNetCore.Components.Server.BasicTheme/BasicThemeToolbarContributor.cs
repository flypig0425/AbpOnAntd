﻿using System.Threading.Tasks;
using Zero.Abp.AspNetCore.Components.Server.BasicTheme.Themes.Basic;
using Zero.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace Zero.Abp.AspNetCore.Components.Server.BasicTheme
{
    public class BasicThemeToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name == StandardToolbars.Main)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            }

            return Task.CompletedTask;
        }
    }
}
