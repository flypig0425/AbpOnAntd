using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Threading;
using Zero.Abp.AntdesignUI.Localization;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class SettingDrawerBase : AntDomComponentBase
    {

        protected LayoutSettings Settings => AsyncHelper.RunSync(async () => await LayoutConfigProvider.GetSettingsAsync());

        [Inject] protected ILayoutConfigProvider LayoutConfigProvider { get; set; }

        [Inject] protected IStringLocalizer<AbpAntdesignUIResource> L { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected async Task UpdateSettingAsync<TValue>(
            Expression<Func<LayoutSettings, TValue>> propertySelector,
            Func<TValue> valueFactory)
        {
            ObjectHelper.TrySetProperty(Settings, propertySelector, valueFactory);
            await Task.CompletedTask;
        }

    }

    public class SettingItem
    {
        public bool Disabled { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public Expression<Func<LayoutSettings, string>> PropertySelector { get; set; }
        public Func<string> ValueFactory { get; set; }


        public List<(string label, string value)> Options { get; set; }


        public RenderFragment Action { get; set; }
        public Func<object> Value { get; set; }
        public Action<object> OnChange { get; set; }
        //public Action<object> OnChanged { get; set; }
        //public RenderFragment Action { get; set; }
    }
}
