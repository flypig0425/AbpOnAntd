using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class LayoutState : IScopedDependency
    {
        public LayoutSettings Settings { get; internal set; }

        protected ILayoutConfigProvider LayoutConfigProvider { get; set; }

        public LayoutState(ILayoutConfigProvider layoutConfigProvider)
        {
            LayoutConfigProvider = layoutConfigProvider;
            AsyncHelper.RunSync(async () =>
            {
                Settings = await LayoutConfigProvider.GetSettingsAsync();
            });
        }

        protected string _themeUrl;
        public async Task UpdateSettingAsync<TValue>(
            Expression<Func<LayoutSettings, TValue>> propertySelector
            , TValue newValue, Func<TValue> currentValue = null)
        {
            if (currentValue?.Invoke()?.Equals(newValue) ?? false) { return; }
            ObjectHelper.TrySetProperty(Settings, propertySelector, () => newValue);
            NotifyStateChanged();

            var fieldName = (propertySelector.Body as MemberExpression)?.Member?.Name;
            if (fieldName == nameof(LayoutSettings.Layout))
            {
                if (Settings.Layout == Layout.Side.Name)
                {
                    Settings.HeaderTheme = "light";
                    Settings.SplitMenus = false;
                }
                if (Settings.Layout == Layout.Top.Name)
                {
                    Settings.SplitMenus = false;
                    //Settings.SidebarTheme = "light";//
                    //Settings.FixedSidebar = false;//
                    //Settings.MenuRender = false;
                    //Settings.MenuHeaderRender = false;
                }
                if (Settings.Layout == Layout.Mix.Name)
                {
                    Settings.FixedHeader = true;
                }
            }
            var themeFieldNames = new List<string> { nameof(LayoutSettings.PrimaryColor), nameof(LayoutSettings.DarkTheme), nameof(LayoutSettings.CompactTheme) };
            if (themeFieldNames.Contains(fieldName)) { await UpdateThemeAsync(); }
            await Task.CompletedTask;
        }

        public async Task UpdateThemeAsync()
        {
            var primaryColor = Settings.PrimaryColor == "default" ? null : Settings.PrimaryColor;
            var fileNameArr = new List<string>();
            fileNameArr.AddIf(Settings.CompactTheme, "compact");
            fileNameArr.AddIf(Settings.DarkTheme, "dark");
            fileNameArr.AddIf(!primaryColor.IsNullOrWhiteSpace(), primaryColor);
            if (fileNameArr.IsNullOrEmpty()) { _themeUrl = "#"; }
            else
            {
                var fileName = string.Join("-", fileNameArr);
                _themeUrl = $"/_content/{typeof(SettingDrawer).Assembly.GetName().Name}/theme/{fileName}.css";
            }
            await NotifyThemeChanged(_themeUrl);
        }

        public event Action OnChange;

        public event Func<string, Task> OnThemeChangedAsync;

        private void NotifyStateChanged() => OnChange?.Invoke();
        private async Task NotifyThemeChanged(string _themeUrl)
        {
            if (OnThemeChangedAsync != null)
            {
                await OnThemeChangedAsync?.Invoke(_themeUrl);
            }
        }
    }
}
