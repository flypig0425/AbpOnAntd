using System;

namespace Zero.Abp.AntdesignUI.Layout
{
    [Serializable]
    public class LayoutSettings : ILayoutSettings
    {
        public string SiderbarTheme { get; set; }
        public string HeaderTheme { get; set; }
        public bool DarkTheme { get; set; }
        public bool CompactTheme { get; set; }
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

        /// <summary>
        /// Event raised after the theme options has changed.
        /// </summary>
        public event EventHandler<EventArgs> Changed;

        /// <summary>
        /// Must be called to rebuild the theme.
        /// </summary>
        public void HasChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }

    }
}