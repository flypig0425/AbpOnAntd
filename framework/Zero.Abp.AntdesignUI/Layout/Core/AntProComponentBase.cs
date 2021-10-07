using AntDesign;
using Microsoft.AspNetCore.Components;
using OneOf;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Abp.AntdesignUI.Layout
{
    public abstract class AntProComponentBase : AntComponentBase//, IPureSettings//, IRenderSetting
    {
        [Parameter]
        public MenuTheme NavTheme
        {
            get
            {
                return LayoutState.Settings.NavTheme switch
                {
                    "light" => MenuTheme.Light,
                    "dark" => MenuTheme.Dark,
                    _ => MenuTheme.Dark
                };
            }
            set => LayoutState.Settings.NavTheme = value.Name;
        }

        [Parameter]
        public int HeaderHeight
        {
            get => LayoutState.Settings.HeaderHeight;
            set => LayoutState.Settings.HeaderHeight = value;
        }

        [Parameter]
        public Layout Layout
        {
            get
            {
                return LayoutState.Settings.Layout switch
                {
                    "mix" => Layout.Mix,
                    "side" => Layout.Side,
                    "top" => Layout.Top,
                    _ => Layout.Mix
                };
            }
            set => LayoutState.Settings.Layout = value.Name;
        }

        [Parameter]
        public string ContentWidth
        {
            get => LayoutState.Settings.ContentWidth;
            set => LayoutState.Settings.ContentWidth = value;
        }

        [Parameter]
        public bool FixedHeader
        {
            get => LayoutState.Settings.FixedHeader;
            set => LayoutState.Settings.FixedHeader = value;
        }

        [Parameter]
        public bool FixSiderbar
        {
            get => LayoutState.Settings.FixSiderbar;
            set => LayoutState.Settings.FixSiderbar = value;
        }

        [Parameter]
        public string IconfontUrl
        {
            get => LayoutState.Settings.IconfontUrl;
            set => LayoutState.Settings.IconfontUrl = value;
        }

        [Parameter]
        public string PrimaryColor
        {
            get => LayoutState.Settings.PrimaryColor;
            set => LayoutState.Settings.PrimaryColor = value;
        }

        [Parameter]
        public bool ColorWeak
        {
            get => LayoutState.Settings.ColorWeak;
            set => LayoutState.Settings.ColorWeak = value;
        }

        [Parameter]
        public bool SplitMenus
        {
            get => LayoutState.Settings.SplitMenus;
            set => LayoutState.Settings.SplitMenus = value;
        }

        [Parameter]
        public bool HeaderRender
        {
            get => LayoutState.Settings.HeaderRender;
            set => LayoutState.Settings.HeaderRender = value;
        }

        [Parameter]
        public bool FooterRender
        {
            get => LayoutState.Settings.FooterRender;
            set => LayoutState.Settings.FooterRender = value;
        }

        [Parameter]
        public bool MenuRender
        {
            get => LayoutState.Settings.MenuRender;
            set => LayoutState.Settings.MenuRender = value;
        }

        [Parameter]
        public bool MenuHeaderRender
        {
            get => LayoutState.Settings.MenuHeaderRender;
            set => LayoutState.Settings.MenuHeaderRender = value;
        }

        [Parameter]
        public MenuSettings Menu { get; set; } = new MenuSettings();

        #region MyRegion

        [Parameter] public string PrefixCls { get; set; } = "ant-pro";

        //[Parameter] public RenderFragment HeaderContent { get; set; }
        //[Parameter] public RenderFragment RightContentRender { get; set; }
        //[Parameter] public RenderFragment FooterContent { get; set; }
        //[Parameter] public RenderFragment MenuContent { get; set; }
        //[Parameter] public RenderFragment MenuExtraRender { get; set; }

        [Parameter] public string Class { get; set; }
        [Parameter] public string Style { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Example:
        /// ClassNames(className
        ///  ,(className,true|flase)
        ///  ,(()=>className,true|flase)
        /// )
        /// </summary>
        /// <param name="classNames"></param>
        /// <returns></returns>
        protected static string ClassNames(params OneOf<string, (string s, bool b), (Func<string> func, bool b)>[] classNames)
            => string.Join(" ", Utils.StyleOrClassNames(classNames));

        protected static string StyleValues(params OneOf<string, (string s, bool b), (Func<string> func, bool b)>[] styleValues)
            => string.Join(";", Utils.StyleOrClassNames(styleValues)?.Select(s => s.TrimEnd(';')));

        #endregion

        //[Inject]
        //protected IOptions<ProSettings> SettingState { get; set; }

        [Inject] protected LayoutState LayoutState { get; set; }
        [Inject] protected ILayoutConfigProvider LayoutConfigProvider { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            LayoutState.Settings = await LayoutConfigProvider.GetSettingsAsync();
            LayoutState.OnChange += OnStateChanged;
        }

        protected override void Dispose(bool disposing)
        {
            LayoutState.OnChange -= OnStateChanged;
            base.Dispose(disposing);
        }

        protected virtual void OnStateChanged()
        {
            StateHasChanged();
        }
    }





    public class MenuSettings
    {
        /// <summary>
        /// 'sub' | 'group'
        /// </summary>
        public string Type { get; set; }
    }
}
