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
                return Settings.NavTheme switch
                {
                    "light" => MenuTheme.Light,
                    "dark" => MenuTheme.Dark,
                    _ => MenuTheme.Dark
                };
            }
            set => Settings.NavTheme = value.Name;
        }

        [Parameter]
        public int HeaderHeight
        {
            get => Settings.HeaderHeight;
            set => Settings.HeaderHeight = value;
        }

        [Parameter]
        public Layout Layout
        {
            get
            {
                return Settings.Layout switch
                {
                    "mix" => Layout.Mix,
                    "side" => Layout.Side,
                    "top" => Layout.Top,
                    _ => Layout.Mix
                };
            }
            set => Settings.Layout = value.Name;
        }

        [Parameter]
        public string ContentWidth
        {
            get => Settings.ContentWidth;
            set => Settings.ContentWidth = value;
        }

        [Parameter]
        public bool FixedHeader
        {
            get => Settings.FixedHeader;
            set => Settings.FixedHeader = value;
        }

        [Parameter]
        public bool FixSiderbar
        {
            get => Settings.FixSiderbar;
            set => Settings.FixSiderbar = value;
        }

        [Parameter]
        public string IconfontUrl
        {
            get => Settings.IconfontUrl;
            set => Settings.IconfontUrl = value;
        }

        [Parameter]
        public string PrimaryColor
        {
            get => Settings.PrimaryColor;
            set => Settings.PrimaryColor = value;
        }

        [Parameter]
        public bool ColorWeak
        {
            get => Settings.ColorWeak;
            set => Settings.ColorWeak = value;
        }

        [Parameter]
        public bool SplitMenus
        {
            get => Settings.SplitMenus;
            set => Settings.SplitMenus = value;
        }

        [Parameter]
        public bool HeaderRender
        {
            get => Settings.HeaderRender;
            set => Settings.HeaderRender = value;
        }

        [Parameter]
        public bool FooterRender
        {
            get => Settings.FooterRender;
            set => Settings.FooterRender = value;
        }

        [Parameter]
        public bool MenuRender
        {
            get => Settings.MenuRender;
            set => Settings.MenuRender = value;
        }

        [Parameter]
        public bool MenuHeaderRender
        {
            get => Settings.MenuHeaderRender;
            set => Settings.MenuHeaderRender = value;
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

        protected LayoutSettings Settings { get; set; }=new LayoutSettings();

        [Inject] protected ILayoutConfigProvider LayoutConfigProvider { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Settings = await LayoutConfigProvider.GetSettingsAsync();
            //Settings.OnStateChange += OnStateChanged;
        }

        protected override void Dispose(bool disposing)
        {
            //Settings.OnStateChange -= OnStateChanged;
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
