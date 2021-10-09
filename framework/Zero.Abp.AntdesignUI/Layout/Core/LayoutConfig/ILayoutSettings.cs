using System;

namespace Zero.Abp.AntdesignUI.Layout
{
    public interface ILayoutSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string SiderbarTheme { get; set; }

        public string HeaderTheme { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Layout { get; set; }
        public string PrimaryColor { get; set; }
        public bool FixedHeader { get; set; }

        public bool FixedSiderbar { get; set; }
        public bool SplitMenus { get; set; }
        public bool ColorWeak { get; set; }

        public bool HeaderRender { get; set; }

        public bool FooterRender { get; set; }

        public bool MenuRender { get; set; }

        public bool MenuHeaderRender { get; set; }

        public int HeaderHeight { get; set; }

        public string ContentWidth { get; set; }

        public string IconfontUrl { get; set; }
    }
}