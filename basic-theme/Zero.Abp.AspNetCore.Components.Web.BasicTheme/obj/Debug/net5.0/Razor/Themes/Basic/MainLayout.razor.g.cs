#pragma checksum "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96ddd605100eec532c590a7c78a7f41573ecc39d"
// <auto-generated/>
#pragma warning disable 1591
namespace Zero.Abp.AspNetCore.Components.Web.BasicTheme.Themes.Basic
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\_Imports.razor"
using AntDesign;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\_Imports.razor"
using Zero.Abp.AntdesignUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\_Imports.razor"
using Zero.Abp.AntdesignUI.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\_Imports.razor"
using Zero.Abp.AntdesignLayout;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\MainLayout.razor"
using Volo.Abp.Ui.Branding;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Zero.Abp.AntdesignLayout.BasicLayout>(0);
            __builder.AddAttribute(1, "Title", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 6 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\MainLayout.razor"
                     BrandingProvider.AppName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "Logo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<OneOf.OneOf<System.String, Microsoft.AspNetCore.Components.RenderFragment>>(
#nullable restore
#line 6 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\MainLayout.razor"
                                                      BrandingProvider.LogoUrl

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "RightContentRender", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Zero.Abp.AspNetCore.Components.Web.BasicTheme.Themes.Basic.NavToolbar>(4);
                __builder2.CloseComponent();
            }
            ));
            __builder.AddAttribute(5, "MenuExtraRender", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
            }
            ));
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Zero.Abp.AntdesignUI.Components.PageAlert>(7);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(8, "\r\n        ");
                __builder2.AddContent(9, 
#nullable restore
#line 15 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Web.BasicTheme\Themes\Basic\MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
                );
            }
            ));
            __builder.AddAttribute(10, "FooterRender", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(11, "\r\n");
            __builder.OpenComponent<AntDesign.AntContainer>(12);
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IBrandingProvider BrandingProvider { get; set; }
    }
}
#pragma warning restore 1591
