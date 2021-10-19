using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;
using Zero.Abp.AntBlazor.Layout.Core.LayoutConfig;

namespace Zero.Abp.AntBlazor.Layout
{
    public partial class LayoutStateProvider
    {

        public LayoutSettings Settings { get; internal set; }


        public event Action OnChange;

        public event Func<string, Task> OnThemeChangedAsync;



        [Inject] protected ILayoutConfigProvider LayoutConfigProvider { get; set; }

        private bool isLoaded;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Settings = await LayoutConfigProvider.GetSettingsAsync();
            isLoaded = true;
        }

        //public async Task SaveChangesAsync()
        //{
        //    await ProtectedSessionStore.SetAsync("count", CurrentCount);
        //}

        public async Task UpdateSettingAsync<TValue>(Expression<Func<LayoutSettings, TValue>> propertySelector, TValue newValue, Func<TValue> currentValue = null)
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
                    Settings.SidebarTheme = "dark";
                    Settings.SplitMenus = false;
                }
                if (Settings.Layout == Layout.Top.Name)
                {
                    Settings.SplitMenus = false;
                    Settings.HeaderTheme = "dark";

                    //Settings.SidebarTheme = "light";//
                    //Settings.FixedSidebar = false;//
                    //Settings.MenuRender = false;
                    //Settings.MenuHeaderRender = false;
                }
                if (Settings.Layout == Layout.Mix.Name)
                {
                    Settings.FixedHeader = true;
                    Settings.HeaderTheme = "dark";
                    Settings.SidebarTheme = "light";
                }
            }
            var themeFieldNames = new List<string> { nameof(LayoutSettings.PrimaryColor), nameof(LayoutSettings.DarkTheme), nameof(LayoutSettings.CompactTheme) };
            if (themeFieldNames.Contains(fieldName)) { await UpdateThemeAsync(); }
            await Task.CompletedTask;
        }

        protected string _themeUrl;
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
