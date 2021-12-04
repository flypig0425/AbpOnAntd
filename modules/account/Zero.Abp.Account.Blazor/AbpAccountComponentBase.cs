using Volo.Abp.Account.Localization;
using Zero.Abp.AspNetCore.Components;

namespace Zero.Abp.Account.Blazor
{
    public abstract class AbpAccountComponentBase : AbpComponentBase
    {
        protected AbpAccountComponentBase()
        {
            LocalizationResource = typeof(AccountResource);
            ObjectMapperContext = typeof(AbpAccountBlazorModule);
        }

        //[Inject] public IAccountAppService AccountAppService { get; set; }
        //[Inject] public SignInManager<IdentityUser> SignInManager { get; set; }
        //[Inject] public IdentityUserManager UserManager { get; set; }
        //[Inject] public IdentitySecurityLogManager IdentitySecurityLogManager { get; set; }
        //[Inject] public IOptions<IdentityOptions> IdentityOptions { get; set; }
        //[Inject] public IExceptionToErrorInfoConverter ExceptionToErrorInfoConverter { get; set; }

        //protected virtual void CheckCurrentTenant(Guid? tenantId)
        //{
        //    if (CurrentTenant.Id != tenantId)
        //    {
        //        throw new ApplicationException($"Current tenant is different than given tenant. CurrentTenant.Id: {CurrentTenant.Id}, given tenantId: {tenantId}");
        //    }
        //}

        //protected virtual void CheckIdentityErrors(IdentityResult identityResult)
        //{
        //    if (!identityResult.Succeeded)
        //    {
        //        throw new UserFriendlyException("Operation failed: " + identityResult.Errors.Select(e => $"[{e.Code}] {e.Description}").JoinAsString(", "));
        //    }

        //    //identityResult.CheckErrors(LocalizationManager); //TODO: Get from old Abp
        //}

        //    protected virtual string GetLocalizeExceptionMessage(Exception exception)
        //    {
        //        if (exception is ILocalizeErrorMessage || exception is IHasErrorCode)
        //        {
        //            return ExceptionToErrorInfoConverter.Convert(exception, false).Message;
        //        }

        //        return exception.Message;
        //    }
    }
}
