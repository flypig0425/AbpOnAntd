using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Zero.Abp.AntBlazor.Layout.LayoutConfig
{
    public class DefaultLayoutConfigProvider : ILayoutConfigProvider
    {
        protected AbpLayoutConfigOptions Options { get; }

        private LayoutSettings _settings;

        public DefaultLayoutConfigProvider(IOptions<AbpLayoutConfigOptions> options)
        {
            Options = options.Value;
            _settings = Options.Settings;
        }

        public event Action<string> ThemeChanged;
        public event Action SettingsChanged;

        public async Task<LayoutSettings> GetSettingsAsync()
        {
            return await Task.FromResult(_settings);
        }

        private string layoutKey;
        private string themeKey;
        public async Task UpdateSettingsAsync(LayoutSettings settings)
        {
            if (settings == null) { return; }
            _settings = settings;
            NotifyStateChanged();

            if (layoutKey != _settings.Layout)
            {
                layoutKey = _settings.Layout;
                _settings = LayoutConfigProviderHelper.NormalizeLayout(_settings);
            }
            var tempThemeKey = $"{_settings.PrimaryColor}{_settings.DarkTheme}{_settings.CompactTheme}";
            if (themeKey != tempThemeKey)
            {
                themeKey = tempThemeKey;
                await ChangedThemeAsync(_settings);
            }
        }

        public async Task UpdateThemeAsync()
        {
            await ChangedThemeAsync(_settings);
        }


        #region MyRegion
        //public async ValueTask UpdateSettingAsync<TValue>(
        //    Expression<Func<LayoutSettings, TValue>> propertySelector,
        //    TValue newValue,
        //    Func<TValue> currentValue = null)
        //{
        //    if (Settings == null) { return; }
        //    if (currentValue?.Invoke()?.Equals(newValue) ?? false) { return; }
        //    ObjectHelper.TrySetProperty(Settings, propertySelector, () => newValue);
        //    NotifyStateChanged();

        //    var fieldName = (propertySelector.Body as MemberExpression)?.Member?.Name;
        //    if (fieldName == nameof(LayoutSettings.Layout)) { Settings = LayoutConfigProviderHelper.NormalizeLayout(Settings); }
        //    var themeFieldNames = new List<string> { nameof(LayoutSettings.PrimaryColor), nameof(LayoutSettings.DarkTheme), nameof(LayoutSettings.CompactTheme) };
        //    if (themeFieldNames.Contains(fieldName)) { await ChangedThemeAsync(Settings); }
        //    await Task.CompletedTask;
        //} 
        #endregion


        private async ValueTask ChangedThemeAsync(LayoutSettings settings)
        {
            var _themeUrl = await LayoutConfigProviderHelper.GetThemeUrlAsync(settings);
            NotifyThemeChanged(_themeUrl);
        }

        private void NotifyThemeChanged(string themeUrl)
        {
            ThemeChanged?.Invoke(themeUrl);
        }

        private void NotifyStateChanged()
        {
            SettingsChanged?.Invoke();
        }

    }
}
