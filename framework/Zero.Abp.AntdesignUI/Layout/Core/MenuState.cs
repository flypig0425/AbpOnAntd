using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class MenuState : IScopedDependency
    {
        public string[] MatchMenuKeys { get; internal set; }= Array.Empty<string>();

        // Lets components receive change notifications
        public event Action OnChange;

        public void UpdateMatchMenuKeys(string[] keys)
        {
            MatchMenuKeys = keys;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
