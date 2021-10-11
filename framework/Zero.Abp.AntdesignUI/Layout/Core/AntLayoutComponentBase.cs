using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OneOf;
using System;
using System.Linq;
using Zero.Abp.AntdesignUI.Localization;

namespace Zero.Abp.AntdesignUI.Layout
{
    public abstract class AntLayoutComponentBase : AntComponentBase
    {
        #region 
        [Parameter] public string PrefixCls { get; set; } = "ant-pro";
        [Parameter] public string Class { get; set; }
        [Parameter] public string Style { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        //[Parameter] public RenderFragment HeaderContent { get; set; }
        //[Parameter] public RenderFragment RightContentRender { get; set; }
        //[Parameter] public RenderFragment FooterContent { get; set; }
        //[Parameter] public RenderFragment MenuContent { get; set; }
        //[Parameter] public RenderFragment MenuExtraRender { get; set; }

        /// <summary>
        /// Example: ClassNames(className ,(className,true|flase) ,(()=>className,true|flase))
        /// </summary>
        protected static string ClassNames(params OneOf<string, (string s, bool b), (Func<string> func, bool b)
                    , (string s, Func<bool> b), (Func<string> func, Func<bool> b)>[] classNames)
            => string.Join(" ", Utils.StyleOrClassNames(classNames));

        /// <summary>
        /// Example: StyleValues(style ,(style,true|flase) ,(()=>style,true|flase))
        /// </summary>
        protected static string StyleValues(params OneOf<string, (string s, bool b), (Func<string> func, bool b)
                    , (string s, Func<bool> b), (Func<string> func, Func<bool> b)>[] styleValues)
            => string.Join(";", Utils.StyleOrClassNames(styleValues)?.Select(s => s.TrimEnd(';')));

        #endregion

        [Inject] public MessageService Message { get; set; }
        [Inject] protected LayoutState LayoutState { get; set; }
        [Inject] protected IStringLocalizer<AbpAntdesignUIResource> L { get; set; }
        protected LayoutSettings Settings => LayoutState.Settings;

        protected virtual void OnSettingsChanged()
        {
            InvokeStateHasChangedAsync();
        }
    }
}
