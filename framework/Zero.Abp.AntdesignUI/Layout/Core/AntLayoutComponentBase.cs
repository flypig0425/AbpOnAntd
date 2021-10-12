using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OneOf;
using System;
using System.Linq;
using Zero.Abp.AntdesignUI.Localization;

namespace Zero.Abp.AntdesignUI.Layout
{
    public abstract class AntLayoutComponentBase : AntDomComponentBase
    {
        #region 
        [Parameter] public RenderFragment ChildContent { get; set; }
        //[Parameter] public RenderFragment HeaderContent { get; set; }
        //[Parameter] public RenderFragment RightContentRender { get; set; }
        //[Parameter] public RenderFragment FooterContent { get; set; }
        //[Parameter] public RenderFragment MenuContent { get; set; }
        //[Parameter] public RenderFragment MenuExtraRender { get; set; }
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
