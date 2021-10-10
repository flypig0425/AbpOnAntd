
using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;
using Zero.Abp.AntdesignUI.Localization;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class SettingDrawerBase : AntLayoutComponentBase
    {

        [Inject] public MessageService Message { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected string _themeUrl;
        protected ElementReference _themeRef;
        protected async Task UpdateSettingAsync<TValue>(
            Expression<Func<LayoutSettings, TValue>> propertySelector,
           Func<TValue> valueFactory, TValue value)
        {
            if (valueFactory.Invoke()?.Equals(value) ?? false) { return; }
            ObjectHelper.TrySetProperty(Settings, propertySelector, () => value);

            var fieldName = (propertySelector.Body as MemberExpression)?.Member?.Name;
            var themeFieldNames = new List<string> { nameof(LayoutSettings.PrimaryColor), nameof(LayoutSettings.DarkTheme), nameof(LayoutSettings.CompactTheme) };
            if (themeFieldNames.Contains(fieldName))
            {
                var fileNameArr = new List<string>();
                fileNameArr.AddIf(Settings.CompactTheme, "compact");
                fileNameArr.AddIf(Settings.DarkTheme, "dark");
                fileNameArr.AddIf(!Settings.PrimaryColor.IsNullOrWhiteSpace(), Settings.PrimaryColor);
                var fileName = string.Join("-", fileNameArr);
                _themeUrl = $"/_content/{typeof(SettingDrawer).Assembly.GetName().Name}/theme/{fileName}.css";
                await JsInvokeAsync(JSInteropConstants.AddElementToBody, _themeRef);
            }
            Settings.HasChanged();
        }
    }

    public class SettingItem
    {
        public bool Disabled { get; set; }
        public string Title { get; set; }
        public RenderFragment Action { get; set; }
    }
}
