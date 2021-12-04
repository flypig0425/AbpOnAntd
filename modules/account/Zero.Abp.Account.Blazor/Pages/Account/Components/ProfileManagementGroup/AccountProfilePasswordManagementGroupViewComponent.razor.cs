using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Zero.Abp.Account.Blazor.Pages.Account.Components.ProfileManagementGroup
{
    public partial class AccountProfilePasswordManagementGroupViewComponent
    {
        protected Form<ChangePasswordInfoModel> ChangePasswordForm;
        protected ChangePasswordInfoModel ChangePasswordModel;

        [Inject] protected IProfileAppService ProfileAppService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var user = await ProfileAppService.GetAsync();
            ChangePasswordModel = new ChangePasswordInfoModel
            {
                HideOldPasswordInput = !user.HasPassword
            };
        }

        protected bool ChangePasswordSubmiting { get; set; }
        protected async Task ChangePasswordAsync()
        {
            if (!(ChangePasswordForm?.Validate() ?? true)) { return; }
            if (string.IsNullOrWhiteSpace(ChangePasswordModel.CurrentPassword)) { return; }
            if (ChangePasswordModel.NewPassword != ChangePasswordModel.NewPasswordConfirm)
            {
                await Message.Warn(L["NewPasswordConfirmFailed"]);
                return;
            }
            await TryActionAsync(async () =>
            {
                ChangePasswordSubmiting = true;
                await ProfileAppService.ChangePasswordAsync(new ChangePasswordInput
                {
                    CurrentPassword = ChangePasswordModel.CurrentPassword,
                    NewPassword = ChangePasswordModel.NewPassword
                });
                _ = Message.Success(L["PasswordChanged"]);

            }, () => ChangePasswordSubmiting = false);

            //try
            //{
            //    ChangePasswordSubmiting = true;
            //    await ProfileAppService.ChangePasswordAsync(new ChangePasswordInput
            //    {
            //        CurrentPassword = ChangePasswordModel.CurrentPassword,
            //        NewPassword = ChangePasswordModel.NewPassword
            //    });
            //    _ = Message.Success(L["PasswordChanged"]);
            //}
            //catch (Exception ex)
            //{
            //    await HandleErrorAsync(ex);
            //}
            //finally
            //{
            //    ChangePasswordSubmiting = false;
            //    await InvokeAsync(StateHasChanged);
            //}
        }

        public class ChangePasswordInfoModel
        {
            [Required]
            [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
            [Display(Name = "DisplayName:CurrentPassword")]
            [DataType(DataType.Password)]
            [DisableAuditing]
            public string CurrentPassword { get; set; }

            [Required]
            [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
            [Display(Name = "DisplayName:NewPassword")]
            [DataType(DataType.Password)]
            [DisableAuditing]
            public string NewPassword { get; set; }

            [Required]
            [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
            [Display(Name = "DisplayName:NewPasswordConfirm")]
            [DataType(DataType.Password)]
            [DisableAuditing]
            public string NewPasswordConfirm { get; set; }

            public bool HideOldPasswordInput { get; set; }
        }
    }
}
