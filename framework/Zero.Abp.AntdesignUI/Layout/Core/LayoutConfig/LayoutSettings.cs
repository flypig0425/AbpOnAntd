using System;

namespace Zero.Abp.AntdesignUI.Layout
{
    [Serializable]
    public class LayoutSettings : ILayoutSettings
    {
        private string _primaryColor;
        private string _navTheme = "light";     // light | dark
        private string _headerTheme = "light";  // light | dark
        private string _layout = "mix";         // side | top | mix
        private string _contentWidth = "Fluid"; // Fluid | Fixed
        private bool _fixedHeader = true;
        private bool _fixSiderbar = true;
        private bool _colorWeak;
        private bool _splitMenus = true;
        private bool _headerRender = true;
        private bool _footerRender = true;
        private bool _menuRender = true;
        private bool _menuHeaderRender = true;
        private int _headerHeight = 48;

        private string _iconfontUrl;

        public string NavTheme { get => _navTheme; set => Update(ref _navTheme, value); }

        public string HeaderTheme { get => _headerTheme; set => Update(ref _headerTheme, value); }

        public string Layout { get => _layout; set => Update(ref _layout, value); }
        public string PrimaryColor { get => _primaryColor; set => Update(ref _primaryColor, value); }
        public bool FixedHeader { get => _fixedHeader; set => Update(ref _fixedHeader, value); }
        public bool FixSiderbar { get => _fixSiderbar; set => Update(ref _fixSiderbar, value); }
        public bool SplitMenus { get => _splitMenus; set => Update(ref _splitMenus, value); }
        public bool ColorWeak { get => _colorWeak; set => Update(ref _colorWeak, value); }
        public int HeaderHeight { get => _headerHeight; set => Update(ref _headerHeight, value); }
        public string ContentWidth { get => _contentWidth; set => Update(ref _contentWidth, value); }

        public bool HeaderRender { get => _headerRender; set => Update(ref _headerRender, value); }
        public bool FooterRender { get => _footerRender; set => Update(ref _footerRender, value); }
        public bool MenuRender { get => _menuRender; set => Update(ref _menuRender, value); }
        public bool MenuHeaderRender { get => _menuHeaderRender; set => Update(ref _menuHeaderRender, value); }
        public string IconfontUrl { get => _iconfontUrl; set => Update(ref _iconfontUrl, value); }


        public event Action OnStateChange;
        protected void Update<T>(ref T oldValue, T newValue)
        {
            if (oldValue?.Equals(newValue) ?? false) return;
            oldValue = newValue;
            OnStateChange?.Invoke();
        }
    }
}