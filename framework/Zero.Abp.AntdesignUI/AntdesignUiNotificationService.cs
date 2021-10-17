using AntDesign;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Zero.Abp.AspNetCore.Components.Notifications;

namespace Volo.Abp.BlazoriseUI
{
    [Dependency(ReplaceServices = true)]
    public class AntdesignUiNotificationService : IUiNotificationService, IScopedDependency
    {
        private NotificationService NotificationService { get; set; }

        public AntdesignUiNotificationService(
            NotificationService notificationService)
        {
            NotificationService = notificationService;
        }

        protected NotificationConfig CreateNotificationConfig(UiNotificationType type, string message, string title = null, Action<UiNotificationOptions> options = null)
        {
            var uiNotificationOptions = CreateDefaultOptions();
            options?.Invoke(uiNotificationOptions);
            var args = new UiNotificationEventArgs(type, message, title, uiNotificationOptions);
            var notificationType = args.NotificationType switch
            {
                UiNotificationType.Info => NotificationType.Info,
                UiNotificationType.Warning => NotificationType.Warning,
                UiNotificationType.Error => NotificationType.Error,
                UiNotificationType.Success => NotificationType.Success,
                _ => NotificationType.None,
            };
            var opt = new NotificationConfig()
            {
                Message = args.Title,
                Description = args.Message,
                NotificationType = notificationType,
                Key = args.Options.Key,
            };
            return opt;
        }

        public Task Info(string message, string title = null, Action<UiNotificationOptions> options = null)
        {
            var notificatioConfig = CreateNotificationConfig(UiNotificationType.Info, message, title, options);
            return NotificationService.Info(notificatioConfig);
        }

        public Task Success(string message, string title = null, Action<UiNotificationOptions> options = null)
        {
            var notificatioConfig = CreateNotificationConfig(UiNotificationType.Success, message, title, options);
            return NotificationService.Success(notificatioConfig);
        }

        public Task Warn(string message, string title = null, Action<UiNotificationOptions> options = null)
        {
            var notificatioConfig = CreateNotificationConfig(UiNotificationType.Warning, message, title, options);
            return NotificationService.Warn(notificatioConfig);
        }

        public Task Error(string message, string title = null, Action<UiNotificationOptions> options = null)
        {
            var notificatioConfig = CreateNotificationConfig(UiNotificationType.Error, message, title, options);
            return NotificationService.Error(notificatioConfig);
        }

        protected virtual UiNotificationOptions CreateDefaultOptions()
        {
            return new UiNotificationOptions();
        }
    }
}
