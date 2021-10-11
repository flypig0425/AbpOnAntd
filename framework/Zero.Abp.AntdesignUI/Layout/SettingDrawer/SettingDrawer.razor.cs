using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zero.Abp.AntdesignUI.Layout
{
    public partial class SettingDrawer
    {
        private bool _show;
        private string BaseClassName => $"{PrefixCls}-setting";
        private CheckboxItem[] LayoutList =>new CheckboxItem[]
        {
            new CheckboxItem
            {
                Key = "side",
                Url = "https://gw.alipayobjects.com/zos/antfincdn/XwFOFbLkSM/LCkqqYNmvBEbokSDscrm.svg",
                Title =L["SideMenuLayout"] 
            },
            new CheckboxItem
            {
                Key = "top",
                Url = "https://gw.alipayobjects.com/zos/antfincdn/URETY8%24STp/KDNDBbriJhLwuqMoxcAr.svg",
                Title = L["TopMenuLayout"]
            },
            new CheckboxItem
            {
                Key = "mix",
                Url = "https://gw.alipayobjects.com/zos/antfincdn/x8Ob%26B8cy8/LCkqqYNmvBEbokSDscrm.svg",
                Title = L["MixMenuLayout"]
            }
        };

        [Parameter] public bool HideHintAlert { get; set; }
        [Parameter] public bool HideCopyButton { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private void SetShow(MouseEventArgs args)
        {
            _show = !_show;
        }

        private async Task CopySetting(MouseEventArgs args)
        {
            var json = JsonSerializer.Serialize(Settings);
            await JsInvokeAsync<object>(JSInteropConstants.Copy, json);
            await Message.Success("copy success, please replace defaultSettings in appsettings.json");
        }
    }
}