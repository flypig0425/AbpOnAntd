using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Zero.Abp.AspNetCore.Components.Messages;
using static Volo.Abp.BlazoriseUI.AntdesignUiMessageBoxService;

namespace Volo.Abp.AntBlazorUI
{
    [Dependency(ReplaceServices = true)]
    public class AntBlazorUiMessageService : IUiMessageService, IScopedDependency
    {
        private MessageService MessageService { get; set; }
        public AntBlazorUiMessageService(MessageService messageService)
        {
            MessageService = messageService;
        }
        public Task Info(string message, Action<UiMessageOptions> options = null)
        {
            var messageConfig = CreateMessageConfig(UiMessageType.Info, message, options);
            return MessageService.Info(messageConfig);
        }

        public Task Success(string message, Action<UiMessageOptions> options = null)
        {
            var messageConfig = CreateMessageConfig(UiMessageType.Success, message, options);
            return MessageService.Success(messageConfig);
        }

        public Task Warn(string message, Action<UiMessageOptions> options = null)
        {
            var messageConfig = CreateMessageConfig(UiMessageType.Warning, message, options);
            return MessageService.Warn(messageConfig);
        }

        public Task Error(string message, Action<UiMessageOptions> options = null)
        {
            var messageConfig = CreateMessageConfig(UiMessageType.Error, message, options);
            return MessageService.Error(messageConfig);
        }

        public Task Loading(string message, Action<UiMessageOptions> options = null)
        {
            var messageConfig = CreateMessageConfig(UiMessageType.Loading, message, options);
            return MessageService.Loading(messageConfig);
        }

        protected virtual UiMessageOptions CreateDefaultOptions()
        {
            return new UiMessageOptions { };
        }

        protected MessageConfig CreateMessageConfig(UiMessageType type, string message, Action<UiMessageOptions> options = null)
        {
            var uiMessageOptions = CreateDefaultOptions();
            options?.Invoke(uiMessageOptions);
            var args = new UiMessageEventArgs(type, message, uiMessageOptions);

            var messageType = args.MessageType switch
            {
                UiMessageType.Info => MessageType.Info,
                UiMessageType.Warning => MessageType.Warning,
                UiMessageType.Error => MessageType.Error,
                UiMessageType.Success => MessageType.Success,
                UiMessageType.Loading => MessageType.Loading,
                _ => MessageType.Info,
            };
            var opt = new MessageConfig
            {
                Content = args.Message,
                Key = args.Options.Key,
                Duration = args.Options.Duration,
                Type = messageType,
            };
            if (args.Options.Icon != null)
            {
                if (args.Options.Icon is RenderFragment fIcon)
                {
                    opt.Icon = fIcon;
                }
                if (args.Options.Icon is string sIcon)
                {
                    opt.Icon = IconRenderFragments.GetByConfirmIcon(sIcon);
                }
            }
            return opt;
        }

    }
}
