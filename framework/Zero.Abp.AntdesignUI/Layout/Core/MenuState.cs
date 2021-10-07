using System;
using Volo.Abp.DependencyInjection;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class LayoutState : IScopedDependency
    {
        private LayoutSettings _settings;

        public LayoutSettings Settings
        {
            get => _settings??new LayoutSettings();
            set => UpdateSettings(value);
        }

        public event Action OnChange;

        public void UpdateSettings(LayoutSettings settings)
        {
            _settings = settings;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
