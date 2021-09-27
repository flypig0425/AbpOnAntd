using Microsoft.AspNetCore.Components;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class SettingItem
    {
        public string Title { get; set; }
        public bool Disabled { get; set; }
        public RenderFragment Action { get; set; }
    }

    public partial class LayoutSetting
    {
    }
}