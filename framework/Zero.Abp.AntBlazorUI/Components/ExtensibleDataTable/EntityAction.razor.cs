using AntDesign;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Zero.Abp.AspNetCore.Components.MessageBoxs;

namespace Zero.Abp.AntBlazorUI.Components.ExtensibleDataTable
{
    public partial class EntityAction<TItem> : ComponentBase
    {
        [Parameter]
        public bool Visible { get; set; } = true;

        internal bool HasPermission { get; set; } = true;

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public bool Primary { get; set; }

        [Parameter]
        public EventCallback Clicked { get; set; }

        [Parameter]
        [Obsolete("Use Visible to hide actions based on permissions. Check the permission yourself. It is more performant. This option might be removed in future versions.")]
        public string RequiredPolicy { get; set; }

        [Parameter]
        public string ButtonType { get; set; }

        [Parameter]
        public Func<string> ConfirmationMessage { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [CascadingParameter]
        public EntityActions<TItem> ParentActions { get; set; }

        [Inject]
        protected IAuthorizationService AuthorizationService { get; set; }

        [Inject]
        protected IUiMessageBoxService UiMessageService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await SetDefaultValuesAsync();

            if (!RequiredPolicy.IsNullOrEmpty())
            {
                HasPermission = await AuthorizationService.IsGrantedAsync(RequiredPolicy);
            }
            ParentActions.AddAction(this);
        }

        protected internal virtual async Task ActionClickedAsync()
        {
            var confirmationMessage = ConfirmationMessage?.Invoke();
            if (!confirmationMessage.IsNullOrWhiteSpace())
            {
                if (await UiMessageService.Confirm(confirmationMessage))
                {
                    await InvokeAsync(async () => await Clicked.InvokeAsync());
                }
            }
            else
            {
                await Clicked.InvokeAsync();
            }
        }

        protected virtual ValueTask SetDefaultValuesAsync()
        {
            ButtonType = AntDesign.ButtonType.Primary;
            return ValueTask.CompletedTask;
        }
    }
}
