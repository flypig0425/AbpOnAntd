using Microsoft.AspNetCore.Components;

namespace Zero.Abp.Identity.Blazor.Pages.Identity
{
    public partial class RoleNameComponent : ComponentBase
    {
        [Parameter] public object Data { get; set; }
    }
}