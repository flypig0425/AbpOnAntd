#pragma checksum "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "691b7643091c8fe83d5873b2e131e4551d9f7642"
// <auto-generated/>
#pragma warning disable 1591
namespace Zero.Abp.AspNetCore.Components.Server.BasicTheme.Themes.Basic
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\_Imports.razor"
using AntDesign;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\_Imports.razor"
using Zero.Abp.AntdesignUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
using Volo.Abp.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
using System.Collections.Immutable;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
using Microsoft.AspNetCore.RequestLocalization;

#line default
#line hidden
#nullable disable
    public partial class LanguageSwitch : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 8 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
 if (_otherLanguages != null && _otherLanguages.Any())
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<AntDesign.Dropdown>(0);
            __builder.AddAttribute(1, "Trigger", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<AntDesign.Trigger[]>(
#nullable restore
#line 10 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
                     new Trigger[] { Trigger.Click }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "Placement", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<AntDesign.Placement>(
#nullable restore
#line 11 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
                     Placement.BottomRight

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "Overlay", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<AntDesign.Menu>(4);
                __builder2.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 14 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
             foreach (var language in _otherLanguages)
            {

#line default
#line hidden
#nullable disable
                    __builder3.OpenComponent<AntDesign.MenuItem>(6);
                    __builder3.AddAttribute(7, "Key", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 16 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
                                language.CultureName

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(8, "OnClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
                                   () => ChangeLanguage(language)

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenElement(10, "span");
                        __builder4.AddAttribute(11, "role", "img");
                        __builder4.AddAttribute(12, "aria-label", 
#nullable restore
#line 18 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
                                                  language.DisplayName

#line default
#line hidden
#nullable disable
                        );
                        __builder4.AddContent(13, 
#nullable restore
#line 19 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
                         language.FlagIcon

#line default
#line hidden
#nullable disable
                        );
                        __builder4.CloseElement();
                        __builder4.AddMarkupContent(14, "\r\n                    ");
                        __builder4.AddContent(15, 
#nullable restore
#line 21 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
                     language.DisplayName

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
#nullable restore
#line 23 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
            }

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.AddAttribute(16, "Unbound", (Microsoft.AspNetCore.Components.RenderFragment<AntDesign.ForwardRef>)((context) => (__builder2) => {
                __builder2.OpenElement(17, "a");
                __builder2.AddAttribute(18, "class", "anticon");
                __builder2.AddElementReferenceCapture(19, (__value) => {
#nullable restore
#line 27 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
                  context.Current = __value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.OpenComponent<AntDesign.Icon>(20);
                __builder2.AddAttribute(21, "Type", "global");
                __builder2.AddAttribute(22, "Theme", "outline");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(23, "\r\n            ");
                __builder2.AddContent(24, 
#nullable restore
#line 29 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
             _currentLanguage.DisplayName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 33 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 34 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.Server.BasicTheme\Themes\Basic\LanguageSwitch.razor"
       
    private IReadOnlyList<LanguageInfo> _otherLanguages;
    private LanguageInfo _currentLanguage;

    protected override async Task OnInitializedAsync()
    {
        var languages = await LanguageProvider.GetLanguagesAsync();
        var currentLanguage = languages.FindByCulture(
            CultureInfo.CurrentCulture.Name,
            CultureInfo.CurrentUICulture.Name
            );

        if (currentLanguage == null)
        {
            var localizationOptions = await RequestLocalizationOptionsProvider.GetLocalizationOptionsAsync();
            if (localizationOptions.DefaultRequestCulture != null)
            {
                currentLanguage = new LanguageInfo(
                    localizationOptions.DefaultRequestCulture.Culture.Name,
                    localizationOptions.DefaultRequestCulture.UICulture.Name,
                    localizationOptions.DefaultRequestCulture.UICulture.DisplayName);
            }
            else
            {
                currentLanguage = new LanguageInfo(
                    CultureInfo.CurrentCulture.Name,
                    CultureInfo.CurrentUICulture.Name,
                    CultureInfo.CurrentUICulture.DisplayName);
            }
        }

        _currentLanguage = currentLanguage;
        _otherLanguages = languages.Where(l => l != _currentLanguage).ToImmutableList();
    }

    private void ChangeLanguage(LanguageInfo language)
    {
        var relativeUrl = NavigationManager.Uri.RemovePreFix(NavigationManager.BaseUri).EnsureStartsWith('/');

        NavigationManager.NavigateTo(
            $"/Abp/Languages/Switch?culture={language.CultureName}&uiCulture={language.UiCultureName}&returnUrl={relativeUrl}",
            forceLoad: true
        );
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAbpRequestLocalizationOptionsProvider RequestLocalizationOptionsProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILanguageProvider LanguageProvider { get; set; }
    }
}
#pragma warning restore 1591
