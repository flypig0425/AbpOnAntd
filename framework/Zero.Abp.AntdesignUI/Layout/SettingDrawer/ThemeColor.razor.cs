using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zero.Abp.AntdesignUI.Layout
{
    public partial class ThemeColor : AntUIComponentBase
    {
        private string _value;
        [Parameter] public string Title { get; set; }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public EventCallback<string> OnChange { get; set; }
        [Parameter] public string Value { get => _value; set { if (_value == value) return; _value = value; } }

        public static readonly Dictionary<string, string> ThemeColors = new()
        {
            { "default", "#1890ff" },
            { "dust", "#F5222D" },
            { "volcano", "#FA541C" },
            { "sunset", "#FAAD14" },
            { "cyan", "#13C2C2" },
            { "green", "#52C41A" },
            { "geekblue", "#2F54EB" },
            { "purple", "#722ED1" }
        };

        private async Task HandleClickAsync(string value)
        {
            _value = value;
            if (ValueChanged.HasDelegate)
            {
                await ValueChanged.InvokeAsync(value);
            }
            if (OnChange.HasDelegate)
            {
                await OnChange.InvokeAsync(value);
            }
        }
    }
}