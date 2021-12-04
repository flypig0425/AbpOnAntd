using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Zero.Abp.AntBlazor.Layout.LayoutConfig;
using Zero.Abp.AntBlazor.Layout.Localization;
using Zero.Abp.AntBlazorUI;

namespace Zero.Abp.AntBlazor.Layout
{
    public abstract class AntLayoutComponentBase : AntUIComponentBase
    {
        //[CascadingParameter]
        //private LayoutContextProvider LayoutContextProvider { get; set; }

        #region LayoutContextProvider
        //protected bool IsMobile => LayoutContextProvider?.IsMobile ?? false;

        //protected bool HasHeader
        //{
        //    get { return LayoutContextProvider?.HasHeader ?? false; }
        //    set { if (LayoutContextProvider != null) { LayoutContextProvider.HasHeader = value; } }
        //}
        //protected bool HasSider
        //{
        //    get { return LayoutContextProvider?.HasSider ?? false; }
        //    set { if (LayoutContextProvider != null) { LayoutContextProvider.HasSider = value; } }
        //}

        //protected void SetDisableMobile(bool disableMobile)
        //{
        //    if (LayoutContextProvider != null) { LayoutContextProvider.DisableMobile = disableMobile; }
        //}
        #endregion

        [Parameter] public string PrefixCls { get; set; } = $"ant-pro";

        [Inject] protected IStringLocalizer<AntBlazorLayoutResource> L { get; set; }

        [Inject] protected ILayoutConfigProvider LayoutConfigProvider { get; set; }

        #region ILayoutConfigProvider
        protected LayoutSettings Settings { get; private set; }
        protected bool IsSideLayout => Settings.Layout == Layout.Side.Name;
        protected bool IsTopLayout => Settings.Layout == Layout.Top.Name;
        protected bool IsMixLayout => Settings.Layout == Layout.Mix.Name;

        protected int SiderWidth => Settings.SiderWidth;
        protected int CollapsedWidth => Settings.CollapsedWidth;

        protected async ValueTask UpdateSettingAsync<TValue>(
         Expression<Func<LayoutSettings, TValue>> propertySelector,
         TValue newValue, Func<TValue> currentValue = null)
        {
            if (LayoutConfigProvider == null) { return; }
            await LayoutConfigProvider.UpdateSettingAsync(propertySelector, newValue, currentValue);
        }
        #endregion

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Settings = await LayoutConfigProvider.GetSettingsAsync();
        }


        protected void OnSettingsChanged()
        {
            //AsyncHelper.RunSync(async () => Settings = await LayoutConfigProvider.GetSettingsAsync());
            InvokeStateHasChanged();
        }
    }

    public sealed class Layout : EnumValue<Layout>
    {
        public static readonly Layout Side = new(nameof(Side).ToLowerInvariant(), 1);
        public static readonly Layout Top = new(nameof(Top).ToLowerInvariant(), 2);
        public static readonly Layout Mix = new(nameof(Mix).ToLowerInvariant(), 3);
        private Layout(string name, int value) : base(name, value) { }
    }
}
