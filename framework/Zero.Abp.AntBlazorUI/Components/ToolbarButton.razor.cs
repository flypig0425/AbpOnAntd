using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Zero.Abp.AntBlazorUI.Components
{
    public partial class ToolbarButton : ComponentBase
    {
        [Parameter]
        public Color Color { get; set; }

        [Parameter]
        public string Type { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public Func<Task> Clicked { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public Func<string> ConfirmationMessage { get; set; }
    }
}
