using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OneOf;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Threading;
using Zero.Abp.AntdesignUI.Localization;

namespace Zero.Abp.AntdesignUI.Layout
{
    public abstract class AntLayoutComponentBase : AntComponentBase
    {
        [Parameter]
        public MenuSettings Menu { get; set; } = new MenuSettings();

        #region 

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

        [Inject] protected IStringLocalizer<AbpAntdesignUIResource> L { get; set; }

        protected LayoutSettings Settings => AsyncHelper.RunSync(() => LayoutConfigProvider.GetSettingsAsync());

        [Inject] protected ILayoutConfigProvider LayoutConfigProvider { get; set; }
        //protected override async Task OnInitializedAsync()
        //{
        //    await base.OnInitializedAsync();
        //    Settings = await LayoutConfigProvider.GetSettingsAsync();
        //    Settings.Changed += OnSettingsChanged;
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    Settings.Changed -= OnSettingsChanged;
        //    base.Dispose(disposing);
        //}

        protected virtual void OnSettingsChanged(object sender, EventArgs eventArgs)
        {
            InvokeStateHasChangedAsync();
            //InvokeAsync(StateHasChanged);
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
