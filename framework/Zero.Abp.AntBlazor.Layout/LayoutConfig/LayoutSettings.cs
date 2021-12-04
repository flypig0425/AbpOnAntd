using System;

namespace Zero.Abp.AntBlazor.Layout.LayoutConfig
{
    [Serializable]
    public class LayoutSettings : ILayoutSettings
    {
        public string PrimaryColor { get; set; } = "default";
        public string Layout { get; set; } = "mix";
        public string HeaderTheme { get; set; } = "dark";
        public string SidebarTheme { get; set; } = "light";

        public bool DarkTheme { get; set; }
        public bool CompactTheme { get; set; }

        public bool FixedHeader { get; set; }
        public bool FixedSidebar { get; set; }
        public bool SplitMenus { get; set; }
        public bool ColorWeak { get; set; }

        public bool HeaderRender { get; set; } = true;
        public bool FooterRender { get; set; } = true;
        public bool MenuRender { get; set; } = true;
        public bool MenuHeaderRender { get; set; } = true;


        public int HeaderHeight { get; set; } = 48;
        public int CollapsedWidth { get; set; } = 48;
        public int SiderWidth { get; set; } = 208;

        /// <summary>
        /// fluid || fixed
        /// </summary>
        public string ContentWidth { get; set; } = "fluid";
        public string IconfontUrl { get; set; }

        ///// <summary>
        ///// Event raised after the theme options has changed.
        ///// </summary>
        //public event EventHandler<EventArgs> Changed;

        ///// <summary>
        ///// Must be called to rebuild the theme.
        ///// </summary>
        //public void HasChanged()
        //{
        //    Changed?.Invoke(this, EventArgs.Empty);
        //}
    }
}