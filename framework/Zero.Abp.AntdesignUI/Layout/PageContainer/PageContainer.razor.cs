using Microsoft.AspNetCore.Components;
using OneOf;

namespace Zero.Abp.AntdesignUI.Layout
{
    public partial class PageContainer
    {
        [CascadingParameter(Name = "LayoutContext")]
        public BasicLayout Value { get; set; } = new BasicLayout();

        [Parameter] public OneOf<bool, RenderFragment> Loading { get; set; } = false;

        [Parameter] public bool FixedHeader { get; set; }

        #region PageHeaderProps

        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment TitleTemplate { get; set; }
        #endregion

        [Parameter] public RenderFragment Content { get; set; }
        [Parameter] public RenderFragment ExtraContent { get; set; }
        [Parameter] public RenderFragment Footer { get; set; }

        /// <summary>
        /// 是否显示背景色
        /// </summary>
        [Parameter] public bool Ghost { get; set; }

        private string PrefixedClassName => $"{PrefixCls}-page-container";
        private string ContainerClassName => ClassNames(PrefixedClassName, Class
            , ($"{PrefixCls}-page-container-ghost", Ghost)
            , ($"{PrefixCls}-page-container-with-footer", HasFooter)
        );


    }
}
