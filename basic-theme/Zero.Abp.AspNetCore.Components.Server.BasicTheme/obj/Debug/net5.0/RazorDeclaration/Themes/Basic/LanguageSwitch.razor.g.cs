// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
