using AntDesign;
using AntDesign.JsInterop;
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
        [Inject] protected IServiceProvider ServiceProvider { get; set; }

        protected SettingComponentCreationContext SettingComponentCreationContext { get; set; }

        [Inject] protected IOptions<SettingManagementComponentOptions> _options { get; set; }

        [Inject] protected IStringLocalizer<AbpSettingManagementResource> L { get; set; }

        protected SettingManagementComponentOptions Options => _options.Value;

        protected List<(string key, RenderFragment render)> SettingItemRenders { get; set; } = new();

        protected string SelectedGroup;
        protected List<BreadcrumbItem> BreadcrumbItems = new();

        protected MenuMode Mode = MenuMode.Inline;

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

        protected async override Task OnInitializedAsync()
        {
            SettingComponentCreationContext = new SettingComponentCreationContext(ServiceProvider);

            foreach (var contributor in Options.Contributors)
            {
                await contributor.ConfigureAsync(SettingComponentCreationContext);
            }

            SettingItemRenders.Clear();
            foreach (var group in SettingComponentCreationContext.Groups)
            {
                SettingItemRenders.Add((GetNormalizedString(group.Id), builder =>
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
    }
}