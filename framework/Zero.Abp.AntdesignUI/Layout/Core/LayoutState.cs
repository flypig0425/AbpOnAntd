using System;
using Volo.Abp.DependencyInjection;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class LayoutState : IScopedDependency
    {
        public LayoutSettings Settings { get; internal set; }

        public LayoutState() {
            Settings = new LayoutSettings();
        }

        public void UpdateSettings(LayoutSettings settings)
        {
            Settings = settings;
            NotifyStateChanged();
        }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
