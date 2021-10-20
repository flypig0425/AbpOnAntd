using AntDesign;
using Microsoft.AspNetCore.Components;
using OneOf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zero.Abp.AntBlazor.Layout
{
    public partial class PageContainer
    {
        #region 
        private bool HasHeader => LayoutStateProvider?.HasHeader ?? false;
        private bool HasFooterToolbar => LayoutStateProvider?.HasPageFooterToolbar ?? false;
        private void SetHasPageContainer(bool hasPageContainer) {
            if (LayoutStateProvider != null) { LayoutStateProvider.HasPageContainer = hasPageContainer; }
        }
        #endregion

        [Parameter] public OneOf<bool, RenderFragment, SpinProps> Loading { get; set; } = false;

        [Parameter] public bool FixedHeader { get; set; }

        [Parameter] public PageHeaderProps Header { get; set; }


        [Parameter] public IList<TabPaneItem> TabList { get; set; }
        [Parameter] public string TabActiveKey { get; set; }
        [Parameter] public EventCallback<string> OnTabChange { get; set; }

        [Parameter] public RenderFragment TabBarExtraContent { get; set; }

        [Parameter] public TabProps TabProps { get; set; } = new TabProps();

        protected async Task HandleTabClick(string key)
        {
            // Do not use TabChange/KeyChange will cause an endless loop
            if (key != TabActiveKey && OnTabChange.HasDelegate)
            {
                await OnTabChange.InvokeAsync(key);
            }
        }

        #region PageHeaderProps
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment TitleTemplate { get; set; }
        [Parameter] public bool Ghost { get; set; }
        [Parameter] public RenderFragment Extra { get; set; }
        [Parameter] public RenderFragment BreadcrumbContent { get; set; }
        #endregion

        [Parameter] public RenderFragment Content { get; set; }
        [Parameter] public RenderFragment ExtraContent { get; set; }
        [Parameter] public RenderFragment Footer { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            SetHasPageContainer(true);
        }

        protected override void Dispose(bool disposing)
        {
            SetHasPageContainer(false);
            base.Dispose(disposing);
        }

        private string PrefixedClassName => $"{PrefixCls}-page-container";
        private string ContainerClassName => ClassNames(PrefixedClassName, Class
            , ($"{PrefixCls}-page-container-ghost", Header?.Ghost ?? Ghost)
            , ($"{PrefixCls}-page-container-with-footer", HasFooter)
        );
    }

    public class TabProps
    {
        public TabType Type { get; set; }
        public TabSize Size { get; set; }
        public bool HideAdd { get; set; }
        public Func<string, string, Task<bool>> OnEdit { get; set; } = (key, action) => Task.FromResult(true);
    }

    public class TabPaneItem
    {
        public string Key { get; set; }
        public string Tab { get; set; }
        public bool Closable { get; set; } = true;
        public bool Disabled { get; set; } 
    }

    public class SpinProps
    {
        public string Size { get; set; }

        public string Tip { get; set; }

        public int Delay { get; set; }

        public bool Spinning { get; set; }
    }

    public class PageHeaderProps
    {
        public OneOf<string, RenderFragment> Title { get; set; }
        public bool? Ghost { get; set; }

        public RenderFragment Breadcrumb { get; set; }

        public RenderFragment Extra { get; set; }
    }

    //public class BreadcrumbProps
    //{
    //    [Parameter] public Route[] Routes { get; set; }
    //}

    //public class Route
    //{
    //    [Parameter] public string Path { get; set; }

    //    [Parameter] public string BreadcrumbName { get; set; }
    //}
}
