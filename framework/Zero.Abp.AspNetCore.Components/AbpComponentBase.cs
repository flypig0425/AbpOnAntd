using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Guids;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;
using Zero.Abp.AspNetCore.Components.Alerts;
using Zero.Abp.AspNetCore.Components.ExceptionHandling;
using Zero.Abp.AspNetCore.Components.MessageBoxs;
using Zero.Abp.AspNetCore.Components.Messages;
using Zero.Abp.AspNetCore.Components.Notifications;

namespace Zero.Abp.AspNetCore.Components
{
    public abstract class AbpComponentBase : OwningComponentBase
    {
        protected IStringLocalizerFactory StringLocalizerFactory => LazyGetRequiredService(ref _stringLocalizerFactory);
        private IStringLocalizerFactory _stringLocalizerFactory;

        protected IStringLocalizer L
        {
            get
            {
                if (_localizer == null) { _localizer = CreateLocalizer(); }
                return _localizer;
            }
        }
        private IStringLocalizer _localizer;

        protected Type LocalizationResource
        {
            get => _localizationResource;
            set
            {
                _localizationResource = value;
                _localizer = null;
            }
        }
        private Type _localizationResource = typeof(DefaultResource);

        protected ILogger Logger => _lazyLogger.Value;
        private Lazy<ILogger> _lazyLogger => new(() => LoggerFactory?.CreateLogger(GetType().FullName) ?? NullLogger.Instance, true);

        protected ILoggerFactory LoggerFactory => LazyGetRequiredService(ref _loggerFactory);
        private ILoggerFactory _loggerFactory;

        protected IAuthorizationService AuthorizationService => LazyGetRequiredService(ref _authorizationService);
        private IAuthorizationService _authorizationService;

        protected ICurrentUser CurrentUser => LazyGetRequiredService(ref _currentUser);
        private ICurrentUser _currentUser;

        protected ICurrentTenant CurrentTenant => LazyGetRequiredService(ref _currentTenant);
        private ICurrentTenant _currentTenant;

        protected IGuidGenerator GuidGenerator => LazyGetRequiredService(ref _guidGenerator);
        private IGuidGenerator _guidGenerator;

        #region 
        protected IUiMessageBoxService MessageBox => LazyGetNonScopedRequiredService(ref _messageBox);
        private IUiMessageBoxService _messageBox;

        protected IUiNotificationService Notify => LazyGetNonScopedRequiredService(ref _notify);
        private IUiNotificationService _notify;

        protected IUiMessageService Message => LazyGetNonScopedRequiredService(ref _message);
        private IUiMessageService _message;

        protected IAlertManager AlertManager => LazyGetNonScopedRequiredService(ref _alertManager);
        private IAlertManager _alertManager;
        protected AlertList Alerts => AlertManager.Alerts;
        #endregion

        protected IUserExceptionInformer UserExceptionInformer => LazyGetNonScopedRequiredService(ref _userExceptionInformer);
        private IUserExceptionInformer _userExceptionInformer;

        protected IObjectMapper ObjectMapper
        {
            get
            {
                if (_objectMapper != null) { return _objectMapper; }
                if (ObjectMapperContext == null) { return LazyGetRequiredService(ref _objectMapper); }
                return LazyGetRequiredService(
                    typeof(IObjectMapper<>).MakeGenericType(ObjectMapperContext),
                    ref _objectMapper
                );
            }
        }

        private IObjectMapper _objectMapper;

        protected Type ObjectMapperContext { get; set; }

        protected TService LazyGetRequiredService<TService>(ref TService reference) => LazyGetRequiredService(typeof(TService), ref reference);

        protected TRef LazyGetRequiredService<TRef>(Type serviceType, ref TRef reference)
        {
            if (reference == null)
            {
                reference = (TRef)ScopedServices.GetRequiredService(serviceType);
            }
            return reference;
        }

        protected TService LazyGetService<TService>(ref TService reference) => LazyGetService(typeof(TService), ref reference);

        protected TRef LazyGetService<TRef>(Type serviceType, ref TRef reference)
        {
            if (reference == null)
            {
                reference = (TRef)ScopedServices.GetService(serviceType);
            }
            return reference;
        }

        protected TService LazyGetNonScopedRequiredService<TService>(ref TService reference) => LazyGetNonScopedRequiredService(typeof(TService), ref reference);

        protected TRef LazyGetNonScopedRequiredService<TRef>(Type serviceType, ref TRef reference)
        {
            if (reference == null)
            {
                reference = (TRef)NonScopedServices.GetRequiredService(serviceType);
            }

            return reference;
        }

        protected TService LazyGetNonScopedService<TService>(ref TService reference) => LazyGetNonScopedService(typeof(TService), ref reference);

        protected TRef LazyGetNonScopedService<TRef>(Type serviceType, ref TRef reference)
        {
            if (reference == null)
            {
                reference = (TRef)NonScopedServices.GetService(serviceType);
            }

            return reference;
        }

        [Inject] protected IServiceProvider NonScopedServices { get; set; }

        protected virtual IStringLocalizer CreateLocalizer()
        {
            if (LocalizationResource != null)
            {
                return StringLocalizerFactory.Create(LocalizationResource);
            }

            var localizer = StringLocalizerFactory.CreateDefaultOrNull();
            if (localizer == null)
            {
                throw new AbpException($"Set {nameof(LocalizationResource)} or define the default localization resource type (by configuring the {nameof(AbpLocalizationOptions)}.{nameof(AbpLocalizationOptions.DefaultResourceType)}) to be able to use the {nameof(L)} object!");
            }

            return localizer;
        }

        protected async Task HandleErrorAsync(Exception exception)
        {
            Logger.LogException(exception);
            await InvokeAsync(async () =>
            {
                await UserExceptionInformer.InformAsync(new UserExceptionInformerContext(exception));
                await InvokeAsync(StateHasChanged);
            });
        }

        protected async Task TryActionAsync(Action tryAction, Action finallyAction=null)
        {
            try
            {
                tryAction?.Invoke();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
            finally
            {
                if (finallyAction != null)
                {
                    finallyAction.Invoke();
                    await InvokeAsync(StateHasChanged);
                }
            }
        }
    }
}
