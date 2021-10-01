using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zero.Abp.AntdesignUI.Layout
{
    public abstract class AntProComponentBase : AntDomComponentBase, IPureSettings//, IRenderSetting
    {
        [Parameter]
        public MenuTheme NavTheme
        {
            get
            {
                return SettingState.Value.NavTheme switch
                {
                    "light" => MenuTheme.Light,
                    "dark" => MenuTheme.Dark,
                    _ => MenuTheme.Dark
                };
            }
            set => SettingState.Value.NavTheme = value.Name;
        }

        [Parameter]
        public int HeaderHeight
        {
            get => SettingState.Value.HeaderHeight;
            set => SettingState.Value.HeaderHeight = value;
        }

        [Parameter]
        public Layout Layout
        {
            get
            {
                return SettingState.Value.Layout switch
                {
                    "mix" => Layout.Mix,
                    "side" => Layout.Side,
                    "top" => Layout.Top,
                    _ => Layout.Mix
                };
            }
            set => SettingState.Value.Layout = value.Name;
        }

        [Parameter]
        public string ContentWidth
        {
            get => SettingState.Value.ContentWidth;
            set => SettingState.Value.ContentWidth = value;
        }

        [Parameter]
        public bool FixedHeader
        {
            get => SettingState.Value.FixedHeader;
            set => SettingState.Value.FixedHeader = value;
        }

        [Parameter]
        public bool FixSiderbar
        {
            get => SettingState.Value.FixSiderbar;
            set => SettingState.Value.FixSiderbar = value;
        }

        [Parameter]
        public string IconfontUrl
        {
            get => SettingState.Value.IconfontUrl;
            set => SettingState.Value.IconfontUrl = value;
        }

        [Parameter]
        public string PrimaryColor
        {
            get => SettingState.Value.PrimaryColor;
            set => SettingState.Value.PrimaryColor = value;
        }

        [Parameter]
        public bool ColorWeak
        {
            get => SettingState.Value.ColorWeak;
            set => SettingState.Value.ColorWeak = value;
        }

        [Parameter]
        public bool SplitMenus
        {
            get => SettingState.Value.SplitMenus;
            set => SettingState.Value.SplitMenus = value;
        }

        [Parameter]
        public bool HeaderRender
        {
            get => SettingState.Value.HeaderRender;
            set => SettingState.Value.HeaderRender = value;
        }

        [Parameter]
        public bool FooterRender
        {
            get => SettingState.Value.FooterRender;
            set => SettingState.Value.FooterRender = value;
        }

        [Parameter]
        public bool MenuRender
        {
            get => SettingState.Value.MenuRender;
            set => SettingState.Value.MenuRender = value;
        }

        [Parameter]
        public bool MenuHeaderRender
        {
            get => SettingState.Value.MenuHeaderRender;
            set => SettingState.Value.MenuHeaderRender = value;
        }

        [Parameter]
        public RenderFragment FooterContent { get; set; }



        [Parameter]
        public MenuSettings Menu { get; set; } = new MenuSettings();




        #region MyRegion

        [Parameter] public string PrefixCls { get; set; } = "ant-pro";

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
            => string.Join(" ", StyleOrClassNames(classNames));

        protected static string StyleValues(params OneOf<string, (string s, bool b), (Func<string> func, bool b)>[] styleValues)
            => string.Join(";", StyleOrClassNames(styleValues)?.Select(s => s.TrimEnd(';')));

        private static IEnumerable<string> StyleOrClassNames(params OneOf<string, (string s, bool b), (Func<string> func, bool b)>[] values)
        {
            var tempClassNames = values?.Select(s => s.Match(
                m0 => m0,
                m1 => m1.b ? m1.s : null,
                m2 => m2.b ? m2.func?.Invoke() : null
                ));
            tempClassNames = tempClassNames?.Where(w => !w.IsNullOrWhiteSpace())?.Distinct()?.ToArray();
            return tempClassNames ?? Array.Empty<string>();
        }
        #endregion

        [Inject]
        protected IOptions<ProSettings> SettingState { get; set; }

        protected virtual void OnStateChanged()
        {
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SettingState.Value.OnStateChange += OnStateChanged;
        }

        protected override void Dispose(bool disposing)
        {
            SettingState.Value.OnStateChange -= OnStateChanged;
            base.Dispose(disposing);
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
