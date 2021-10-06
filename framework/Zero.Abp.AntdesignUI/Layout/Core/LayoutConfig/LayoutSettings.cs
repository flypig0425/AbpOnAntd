using System;

namespace Zero.Abp.AntdesignUI.Layout
{
    [Serializable]
    public class LayoutSettings : ILayoutSettings
    {
        public string NavTheme { get; set; } 
        public string Layout { get; set; } 
        public string PrimaryColor { get; set; }
        public bool FixedHeader { get; set; }
        public bool FixSiderbar { get; set; }
        public bool SplitMenus { get; set; }
        public bool ColorWeak { get; set; }
        public bool HeaderRender { get; set; } = true;
        public bool FooterRender { get; set; } = true;
        public bool MenuRender { get; set; } = true;
        public bool MenuHeaderRender { get; set; } = true;
        public int HeaderHeight { get; set; } = 48;
        public string ContentWidth { get; set; } 
        public string IconfontUrl { get; set; }

        public LayoutSettings()
        {

        }
    }
}