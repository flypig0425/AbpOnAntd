using Microsoft.AspNetCore.Components;

namespace Zero.Abp.AntdesignUI.Layout
{
    internal interface IGlobalHeader : IPureSettings
    {
        bool Collapsed { get; }
        bool IsMobile { get; }

        // todo:oneof
        bool MenuRender { get; }

        bool HeaderRender { get; }
    }

    public partial class GlobalHeader : AntProComponentBase, IGlobalHeader
    {
        public string BaseClassName => $"{PrefixCls}-global-header";

        //[Parameter] public string PrefixCls { get; set; } = "ant-pro";

        [Parameter] public bool Collapsed { get; set; }

        [Parameter] public bool IsMobile { get; set; }

        [Parameter] public EventCallback<bool> OnCollapse { get; set; }

        [Parameter] public RenderFragment CollapsedButtonRender { get; set; }

        [CascadingParameter(Name = nameof(RightContentRender))]
        public RenderFragment RightContentRender { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add(BaseClassName)
                .If($"{BaseClassName}-layout-mix", () => Layout == Layout.Mix)
                .If($"{BaseClassName}-layout-side", () => Layout == Layout.Side)
                .If($"{BaseClassName}-layout-top", () => Layout == Layout.Top);
        }
    }
}