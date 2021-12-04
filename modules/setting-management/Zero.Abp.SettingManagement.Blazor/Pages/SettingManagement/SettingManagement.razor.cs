using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement.Localization;

namespace Zero.Abp.SettingManagement.Blazor.Pages.SettingManagement
{
    public partial class SettingManagement
    {
        protected SettingManagementComponentOptions Options { get; }

        public SettingManagement(IOptions<SettingManagementComponentOptions> options)
        {
            Options = options.Value;
        }

        protected List<BreadcrumbItem> BreadcrumbItems = new();
     
        [Inject] protected IServiceProvider ServiceProvider { get; set; }
        [Inject] protected IStringLocalizer<AbpSettingManagementResource> L { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await SetItemRendersAsync();
        }

        #region  [SetItemRendersAsync]
        protected SettingComponentCreationContext SettingComponentCreationContext { get; set; }

        protected string SelectedGroup;
        protected List<(string Key, string DisplayName, RenderFragment Component)> ItemRenders { get; set; } = new();

        protected virtual async Task SetItemRendersAsync()
        {
            SettingComponentCreationContext = new SettingComponentCreationContext(ServiceProvider);
            foreach (var contributor in Options.Contributors)
            {
                await contributor.ConfigureAsync(SettingComponentCreationContext);
            }

            ItemRenders.Clear();
            foreach (var group in SettingComponentCreationContext.Groups)
            {
                ItemRenders.Add((GetNormalizedString(group.Id), group.DisplayName, builder =>
                {
                    builder.OpenComponent(0, group.ComponentType);
                    builder.CloseComponent();
                }
                ));
            }
            SelectedGroup = GetNormalizedString(SettingComponentCreationContext.Groups.First().Id);
        }

        protected virtual string GetNormalizedString(string value)
        {
            return value.Replace('.', '_');
        } 
        #endregion

        //protected async Task ResizeAsync()
        //{
        //    if (element.Context == null) { return; }
        //    Mode = MenuMode.Inline;
        //    //var window = await JsInvokeAsync<Window>(JSInteropConstants.GetWindow);
        //    //var dom = await Js.InvokeAsync<HtmlElement>(JSInteropConstants.GetDomInfo, element);

        //    var window = new Window();
        //    var dom = new HtmlElement();
        //    if (dom.OffsetWidth<641 && dom.OffsetWidth > 400)
        //    {
        //        Mode = MenuMode.Horizontal;
        //    }
        //    if (window.InnerWidth < 768 && dom.OffsetWidth > 400)
        //    {
        //        Mode = MenuMode.Horizontal;
        //    }
        //}
    }
}