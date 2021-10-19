using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Zero.Abp.AntBlazor.Layout.Core;
using Zero.Abp.AntBlazor.Layout.Core.LayoutConfig;
using Zero.Abp.AntBlazor.Layout.Localization;
using Zero.Abp.AntBlazorUI;

namespace Zero.Abp.AntBlazor.Layout
{
    public abstract class AntLayoutComponentBase : AntUIComponentBase
    {
        #region MyRegion
        [CascadingParameter]
        protected LayoutStateProvider LayoutStateProvider { get; set; }

        protected LayoutSettings Settings => LayoutStateProvider?.Settings ?? new LayoutSettings();

        protected bool IsSideLayout => Settings.Layout == Layout.Side.Name;
        protected bool IsTopLayout => Settings.Layout == Layout.Top.Name;
        protected bool IsMixLayout => Settings.Layout == Layout.Mix.Name;
        #endregion

        [Parameter] public string LayoutPrefixCls { get; set; } = $"ant-pro";

        #region 
        //[Parameter] public RenderFragment HeaderContent { get; set; }
        //[Parameter] public RenderFragment RightContentRender { get; set; }
        //[Parameter] public RenderFragment FooterContent { get; set; }
        //[Parameter] public RenderFragment MenuContent { get; set; }
        //[Parameter] public RenderFragment MenuExtraRender { get; set; }
        #endregion

        //[Inject] protected LayoutState LayoutState { get; set; }
        //protected LayoutSettings Settings => LayoutState.Settings;

        //protected bool IsSideLayout => Settings.Layout == Layout.Side.Name;
        //protected bool IsTopLayout => Settings.Layout == Layout.Top.Name;
        //protected bool IsMixLayout => Settings.Layout == Layout.Mix.Name;

        [Inject] protected IStringLocalizer<AntBlazorLayoutResource> L { get; set; }
        protected virtual void OnSettingsChanged()
        {
            InvokeStateHasChangedAsync();
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
