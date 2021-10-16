using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http;
using Zero.Abp.AspNetCore.Components.ExceptionHandling;
using Zero.Abp.AspNetCore.Components.MessageBoxs;

namespace Zero.Abp.AspNetCore.Components.Web.ExceptionHandling
{
    [Dependency(ReplaceServices = true)]
    public class UserExceptionInformer : IUserExceptionInformer, IScopedDependency
    {
        public ILogger<UserExceptionInformer> Logger { get; set; }
        protected IUiMessageBoxService MessageService { get; }
        protected IExceptionToErrorInfoConverter ExceptionToErrorInfoConverter { get; }

        protected AbpExceptionHandlingOptions Options { get; }

        public UserExceptionInformer(
            IUiMessageBoxService messageService,
            IExceptionToErrorInfoConverter exceptionToErrorInfoConverter,
            IOptions<AbpExceptionHandlingOptions> options)
        {
            MessageService = messageService;
            ExceptionToErrorInfoConverter = exceptionToErrorInfoConverter;
            Options = options.Value;
            Logger = NullLogger<UserExceptionInformer>.Instance;
        }

        public void Inform(UserExceptionInformerContext context)
        {
            //TODO: Create sync versions of the MessageService APIs.

            var errorInfo = GetErrorInfo(context);

            if (errorInfo.Details.IsNullOrEmpty())
            {
                MessageService.Error(errorInfo.Message);
            }
            else
            {
                MessageService.Error(errorInfo.Details, errorInfo.Message);
            }
        }

        public async Task InformAsync(UserExceptionInformerContext context)
        {
            var errorInfo = GetErrorInfo(context);

            if (errorInfo.Details.IsNullOrEmpty())
            {
                await MessageService.Error(errorInfo.Message);
            }
            else
            {
                await MessageService.Error(errorInfo.Details, errorInfo.Message);
            }
        }

        protected virtual RemoteServiceErrorInfo GetErrorInfo(UserExceptionInformerContext context)
        {
            return ExceptionToErrorInfoConverter.Convert(context.Exception, Options.SendExceptionsDetailsToClients);
        }
    }
}
