// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorServerDemo.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using AntDesign;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Zero.Abp.AspNetCore.Components.Progression;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using Zero.Abp.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "F:\_MyCode\AbpZero\app\BlazorServerDemo\_Imports.razor"
using BlazorServerDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\_MyCode\AbpZero\app\BlazorServerDemo\Pages\Index.razor"
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
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "F:\_MyCode\AbpZero\app\BlazorServerDemo\Pages\Index.razor"
      
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
