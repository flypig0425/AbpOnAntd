using Microsoft.AspNetCore.Components.Routing;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class MenuDataItem : ApplicationMenuItem
    {
        public MenuDataItem([NotNull] string name, [NotNull] string displayName, string url = null, string icon = null, int order = DefaultOrder, object customData = null, string target = null, string elementId = null, string cssClass = null) :
            base(name, displayName, url, icon, order, customData, target, elementId, cssClass)
        { }


        public NavLinkMatch Match { get; set; }
    }
}
