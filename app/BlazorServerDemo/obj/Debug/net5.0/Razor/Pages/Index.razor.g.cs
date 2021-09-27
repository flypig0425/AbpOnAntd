#pragma checksum "D:\DevCodes\AbpZero\app\BlazorServerDemo\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc48c9c8a73e304b1a32b4adf7fa6dfb3fd27b60"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorServerDemo.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using AntDesign;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Zero.Abp.AspNetCore.Components.Progression;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Zero.Abp.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\DevCodes\AbpZero\app\BlazorServerDemo\_Imports.razor"
using BlazorServerDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\DevCodes\AbpZero\app\BlazorServerDemo\Pages\Index.razor"
using Volo.Abp.UI.Navigation;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : AbpComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<AntDesign.Button>(0);
            __builder.AddAttribute(1, "Type", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 8 "D:\DevCodes\AbpZero\app\BlazorServerDemo\Pages\Index.razor"
               ButtonType.Primary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "D:\DevCodes\AbpZero\app\BlazorServerDemo\Pages\Index.razor"
                                             DeleteAsync

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(4, "\r\n    Open the notification box\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "D:\DevCodes\AbpZero\app\BlazorServerDemo\Pages\Index.razor"
      
    protected override void OnInitialized()
    {

        Alerts.Warning(
        "We will have a service interruption between 02:00 AM and 04:00 AM at October 23, 2023!",
        "Service Interruption");
        base.OnInitialized();
    }

    int? percentage = 0;

    public async Task DeleteAsync()
    {
        var dd= await MenuManager.GetMainMenuAsync();
        percentage = percentage + 10;
        await pageProgressService.Go(percentage);

        //await Message.Success( "The product 'Acme Atom Re-Arranger' has been successfully deleted."  );
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMenuManager MenuManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUiPageProgressService pageProgressService { get; set; }
    }
}
#pragma warning restore 1591
