
using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;

namespace Zero.Abp.AntdesignUI.Layout
{
    public partial class SettingDrawerBase : AntLayoutComponentBase
    {
        [Inject] public MessageService Message { get; set; }

        protected string _themeUrl;
        protected ElementReference _themeRef;
        protected async Task UpdateSettingAsync<TValue>(
            Expression<Func<LayoutSettings, TValue>> propertySelector,
           Func<TValue> currentValue, TValue newValue)
        {
            if (currentValue?.Invoke()?.Equals(newValue) ?? false) { return; }
            ObjectHelper.TrySetProperty(Settings, propertySelector, () => newValue);

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
                    Settings.MenuRender = false;
                    Settings.MenuHeaderRender = false;
                }
                else {
                    Settings.MenuRender = true;
                    Settings.MenuHeaderRender = true;
                }

                if (Settings.Layout == Layout.Mix.Name)
                {
                    Settings.FixedHeader = true;
                }
            }
            var themeFieldNames = new List<string> { nameof(LayoutSettings.PrimaryColor), nameof(LayoutSettings.DarkTheme), nameof(LayoutSettings.CompactTheme) };
            if (themeFieldNames.Contains(fieldName))
            {
                var primaryColor = Settings.PrimaryColor == "default" ? null : Settings.PrimaryColor;
                var fileNameArr = new List<string>();
                fileNameArr.AddIf(Settings.CompactTheme, "compact");
                fileNameArr.AddIf(Settings.DarkTheme, "dark");
                fileNameArr.AddIf(!primaryColor.IsNullOrWhiteSpace(), primaryColor);
                if (fileNameArr.IsNullOrEmpty()) { _themeUrl = ""; }
                else
                {
                    var fileName = string.Join("-", fileNameArr);
                    _themeUrl = $"/_content/{typeof(SettingDrawer).Assembly.GetName().Name}/theme/{fileName}.css";
                }
                await JsInvokeAsync(JSInteropConstants.AddElementToBody, _themeRef);
            }
            Settings.HasChanged();
        }
    }

    public class SettingItem
    {
        public Func<bool> Disabled { get; set; }
        public string Title { get; set; }
        public RenderFragment Action { get; set; }
    }
}
