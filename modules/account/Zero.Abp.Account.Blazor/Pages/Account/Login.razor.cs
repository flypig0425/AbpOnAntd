using AntDesign;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account.Settings;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Security.Claims;
using Volo.Abp.Settings;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace Zero.Abp.Account.Blazor.Pages.Account
{
    public partial class Login
    {
        private object RedirectSafely(string returnUrl, string returnUrlHash)
        {
            throw new NotImplementedException();
        }
        private object RedirectToPage(string v, object p = null)
        {
            throw new NotImplementedException();
        }



        public string ReturnUrl { get; set; }
        public string ReturnUrlHash { get; set; }


        protected Form<LoginInputModel> LoginFormRef;
        protected LoginInputModel LoginInput { get; set; }

        protected bool IsSelfRegistrationEnabled { get; set; }
        protected bool EnableLocalLogin { get; set; }
        protected bool ShowCancelButton { get; set; }

        public IEnumerable<ExternalProviderModel> ExternalProviders { get; set; }
        public IEnumerable<ExternalProviderModel> VisibleExternalProviders => ExternalProviders.Where(x => !x.DisplayName.IsNullOrWhiteSpace());
        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;


        protected AbpAccountOptions AccountOptions { get; }
        protected IAuthenticationSchemeProvider SchemeProvider { get; }

        [Inject] protected NavigationManager NavigationManager { get; set; }

        public Login(
               IAuthenticationSchemeProvider schemeProvider,
               IOptions<AbpAccountOptions> accountOptions,
               IOptions<IdentityOptions> identityOptions)
        {
            SchemeProvider = schemeProvider;
            IdentityOptions = identityOptions;
            AccountOptions = accountOptions.Value;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            LoginInput = new LoginInputModel();
            ExternalProviders = await GetExternalProviders();
            EnableLocalLogin = await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin);
            IsSelfRegistrationEnabled = await SettingProvider.IsTrueAsync(AccountSettingNames.IsSelfRegistrationEnabled);
            if (IsExternalLoginOnly)
            {
                //return await ExternalLogin(vm.ExternalLoginScheme, returnUrl);
                throw new NotImplementedException();
            }
        }
        public virtual async Task<object> OnLoginAsync()
        {
            await CheckLocalLoginAsync();
            if (!(LoginFormRef?.Validate() ?? true)) { return null; }

            ExternalProviders = await GetExternalProviders();
            EnableLocalLogin = await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin);

            await ReplaceEmailToUsernameOfInputIfNeeds();
            await IdentityOptions.SetAsync();

            var result = await SignInManager.PasswordSignInAsync(
                LoginInput.UserNameOrEmailAddress,
                LoginInput.Password,
                LoginInput.RememberMe,
                true
            );

            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
            {
                Identity = IdentitySecurityLogIdentityConsts.Identity,
                Action = result.ToIdentitySecurityLogAction(),
                UserName = LoginInput.UserNameOrEmailAddress
            });
            if (result.RequiresTwoFactor) { await TwoFactorLoginResultAsync(); return null; }
            if (result.IsLockedOut) { Alerts.Warning(L["UserLockedOutMessage"]); return null; }
            if (result.IsNotAllowed) { Alerts.Warning(L["LoginIsNotAllowed"]); return null; }
            if (!result.Succeeded) { Alerts.Danger(L["InvalidUserNameOrPassword"]); return null; }

            ////TODO: Find a way of getting user's id from the logged in user and do not query it again like that!
            //var user = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress) ??
            //           await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);

            //Debug.Assert(user != null, nameof(user) + " != null");
            //NavigationManager.NavigateTo(ReturnUrl);
            return RedirectSafely(ReturnUrl, ReturnUrlHash);

        }

        protected virtual Task<object> TwoFactorLoginResultAsync()
        {
            throw new NotImplementedException();
        }

        protected virtual async Task<List<ExternalProviderModel>> GetExternalProviders()
        {
            var schemes = await SchemeProvider.GetAllSchemesAsync();

            return schemes
                .Where(x => x.DisplayName != null || x.Name.Equals(AccountOptions.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase))
                .Select(x => new ExternalProviderModel
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                })
                .ToList();
        }

        public virtual async Task<object> OnExternalLogin(string provider)
        {
            //var redirectUrl = Url.Page("./Login", pageHandler: "ExternalLoginCallback", values: new { ReturnUrl, ReturnUrlHash });
            //var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            //properties.Items["scheme"] = provider;

            //return await Task.FromResult(Challenge(properties, provider));
            return await Task.FromResult(new object());

        }

        public virtual async Task<object> OnGetExternalLoginCallbackAsync(string returnUrl = "", string returnUrlHash = "", string remoteError = null)
        {
            //TODO: Did not implemented Identity Server 4 sample for this method (see ExternalLoginCallback in Quickstart of IDS4 sample)
            /* Also did not implement these:
             * - Logout(string logoutId)
             */

            if (remoteError != null)
            {
                Logger.LogWarning($"External login callback error: {remoteError}");
                return RedirectToPage("./Login");
            }

            await IdentityOptions.SetAsync();

            var loginInfo = await SignInManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                Logger.LogWarning("External login info is not available");
                return RedirectToPage("./Login");
            }

            var result = await SignInManager.ExternalLoginSignInAsync(
                loginInfo.LoginProvider,
                loginInfo.ProviderKey,
                isPersistent: false,
                bypassTwoFactor: true
            );

            if (!result.Succeeded)
            {
                await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
                {
                    Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
                    Action = "Login" + result
                });
            }

            if (result.IsLockedOut)
            {
                Logger.LogWarning($"External login callback error: user is locked out!");
                throw new UserFriendlyException("Cannot proceed because user is locked out!");
            }

            if (result.IsNotAllowed)
            {
                Logger.LogWarning($"External login callback error: user is not allowed!");
                throw new UserFriendlyException("Cannot proceed because user is not allowed!");
            }

            if (result.Succeeded)
            {
                return RedirectSafely(returnUrl, returnUrlHash);
            }

            //TODO: Handle other cases for result!

            var email = loginInfo.Principal.FindFirstValue(AbpClaimTypes.Email);
            if (email.IsNullOrWhiteSpace())
            {
                return RedirectToPage("./Register", new
                {
                    IsExternalLogin = true,
                    ExternalLoginAuthSchema = loginInfo.LoginProvider,
                    ReturnUrl = returnUrl
                });
            }

            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = await CreateExternalUserAsync(loginInfo);
            }
            else
            {
                if (await UserManager.FindByLoginAsync(loginInfo.LoginProvider, loginInfo.ProviderKey) == null)
                {
                    CheckIdentityErrors(await UserManager.AddLoginAsync(user, loginInfo));
                }
            }

            await SignInManager.SignInAsync(user, false);

            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
            {
                Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
                Action = result.ToIdentitySecurityLogAction(),
                UserName = user.Name
            });

            return RedirectSafely(returnUrl, returnUrlHash);
        }

        protected virtual async Task<IdentityUser> CreateExternalUserAsync(ExternalLoginInfo info)
        {
            await IdentityOptions.SetAsync();
            var emailAddress = info.Principal.FindFirstValue(AbpClaimTypes.Email);
            var user = new IdentityUser(GuidGenerator.Create(), emailAddress, emailAddress, CurrentTenant.Id);
            CheckIdentityErrors(await UserManager.CreateAsync(user));
            CheckIdentityErrors(await UserManager.SetEmailAsync(user, emailAddress));
            CheckIdentityErrors(await UserManager.AddLoginAsync(user, info));
            CheckIdentityErrors(await UserManager.AddDefaultRolesAsync(user));
            return user;
        }

        protected virtual async Task ReplaceEmailToUsernameOfInputIfNeeds()
        {
            if (!ValidationHelper.IsValidEmailAddress(LoginInput.UserNameOrEmailAddress)) { return; }
            var userByUsername = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress);
            if (userByUsername != null) { return; }
            var userByEmail = await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);
            if (userByEmail == null) { return; }
            LoginInput.UserNameOrEmailAddress = userByEmail.UserName;
        }

        protected virtual async Task CheckLocalLoginAsync()
        {
            if (!await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin))
            {
                throw new UserFriendlyException(L["LocalLoginDisabledMessage"]);
            }
        }


        public class LoginInputModel
        {
            [Required]
            [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxEmailLength))]
            public string UserNameOrEmailAddress { get; set; }

            [Required]
            [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
            [DataType(DataType.Password)]
            [DisableAuditing]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }

        public class ExternalProviderModel
        {
            public string DisplayName { get; set; }
            public string AuthenticationScheme { get; set; }
        }
    }
}
