// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme.Themes.Basic
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\_Imports.razor"
using Zero.Abp.AspNetCore.Components.WebAssembly;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\_Imports.razor"
using AntDesign;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\_Imports.razor"
using Zero.Abp.AntdesignUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\_Imports.razor"
using Zero.Abp.AntdesignUI.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\LanguageSwitch.razor"
using Volo.Abp.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\LanguageSwitch.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\LanguageSwitch.razor"
using System.Collections.Immutable;

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
#line 23 "F:\_MyCode\AbpZero\basic-theme\Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme\Themes\Basic\LanguageSwitch.razor"
       
    private IReadOnlyList<LanguageInfo> _otherLanguages;
    private LanguageInfo _currentLanguage;

    protected override async Task OnInitializedAsync()
    {
        var selectedLanguageName = await JsRuntime.InvokeAsync<string>(
            "localStorage.getItem",
            "Abp.SelectedLanguage"
            );

        _otherLanguages = await LanguageProvider.GetLanguagesAsync();

        if (!_otherLanguages.Any())
        {
            return;
        }

        if (!selectedLanguageName.IsNullOrWhiteSpace())
        {
            _currentLanguage = _otherLanguages.FirstOrDefault(l => l.UiCultureName == selectedLanguageName);
        }

        if (_currentLanguage == null)
        {
            _currentLanguage = _otherLanguages.FirstOrDefault(l => l.UiCultureName == CultureInfo.CurrentUICulture.Name);
        }

        if (_currentLanguage == null)
        {
            _currentLanguage = _otherLanguages.FirstOrDefault();
        }

        _otherLanguages = _otherLanguages.Where(l => l != _currentLanguage).ToImmutableList();
    }

    private async Task ChangeLanguageAsync(LanguageInfo language)
    {
        await JsRuntime.InvokeVoidAsync(
            "localStorage.setItem",
            "Abp.SelectedLanguage", language.UiCultureName
            );

        await JsRuntime.InvokeVoidAsync("location.reload");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILanguageProvider LanguageProvider { get; set; }
    }
}
#pragma warning restore 1591
