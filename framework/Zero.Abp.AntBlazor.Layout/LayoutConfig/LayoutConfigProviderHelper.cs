using AntDesign;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;

namespace Zero.Abp.AntBlazor.Layout.LayoutConfig
{
    public static class LayoutConfigProviderHelper
    {
        public static LayoutSettings NormalizeLayout(LayoutSettings settings)
        {
            if (settings.Layout == Layout.Side.Name)
            {
                settings.HeaderTheme = "light";
                settings.SidebarTheme = "dark";
                settings.SplitMenus = false;
            }
            if (settings.Layout == Layout.Top.Name)
            {
                settings.SplitMenus = false;
                settings.HeaderTheme = "dark";

                //Settings.SidebarTheme = "light";//
                //Settings.FixedSidebar = false;//
                //Settings.MenuRender = false;
                //Settings.MenuHeaderRender = false;
            }
            if (settings.Layout == Layout.Mix.Name)
            {
                settings.FixedHeader = true;
                settings.HeaderTheme = "dark";
                settings.SidebarTheme = "light";
            }
            return settings;
        }

        public static async Task<string> GetThemeUrlAsync(LayoutSettings settings)
        {
            var _themeUrl = "#";
            var primaryColor = settings.PrimaryColor == "default" ? null : settings.PrimaryColor;
            var fileNameArr = new List<string>();
            fileNameArr.AddIf(settings.CompactTheme, "compact");
            fileNameArr.AddIf(settings.DarkTheme, "dark");
            fileNameArr.AddIf(!primaryColor.IsNullOrWhiteSpace(), primaryColor);
            if (!fileNameArr.IsNullOrEmpty())
            {
                var fileName = string.Join("-", fileNameArr);
                _themeUrl = $"/_content/Zero.Abp.AntBlazor.Layout/theme/{fileName}.css";
            }
            return await Task.FromResult(_themeUrl);
        }
    }

    public static class LayoutConfigProviderExtensions
    {
        public static async ValueTask UpdateSettingAsync<TValue>(
         this ILayoutConfigProvider provider,
          Expression<Func<LayoutSettings, TValue>> propertySelector,
          TValue newValue,
          Func<TValue> currentValue = null)
        {
            var settings = (await provider.GetSettingsAsync()) ?? new LayoutSettings();
            if (currentValue?.Invoke()?.Equals(newValue) ?? false) { return; }
            ObjectHelper.TrySetProperty(settings, propertySelector, () => newValue);
            await provider.UpdateSettingsAsync(settings);
        }
    }
}
