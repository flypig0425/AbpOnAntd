using AntDesign;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Zero.Abp.AspNetCore.Components.MessageBoxs;

namespace Volo.Abp.BlazoriseUI
{
    [Dependency(ReplaceServices = true)]
    public class AntdesignUiMessageBoxService : IUiMessageBoxService, IScopedDependency
    {
        public ILogger<AntdesignUiMessageBoxService> Logger { get; set; }

        private ModalService ModalService { get; set; }

        public AntdesignUiMessageBoxService(
            ModalService modalService)
        {
            ModalService = modalService;
            Logger = NullLogger<AntdesignUiMessageBoxService>.Instance;
        }
        public Task Info(string message, string title = null, Action<UiMessageBoxOptions> options = null)
        {
            var confirmOptions = CreateConfirmOptions(UiMessageBoxType.Info, message, title, options);
            return ModalService.InfoAsync(confirmOptions);
        }

        public Task Success(string message, string title = null, Action<UiMessageBoxOptions> options = null)
        {
            var confirmOptions = CreateConfirmOptions(UiMessageBoxType.Success, message, title, options);
            return ModalService.SuccessAsync(confirmOptions);
        }

        public Task Warn(string message, string title = null, Action<UiMessageBoxOptions> options = null)
        {
            var confirmOptions = CreateConfirmOptions(UiMessageBoxType.Warning, message, title, options);
            return ModalService.WarningAsync(confirmOptions);
        }

        public Task Error(string message, string title = null, Action<UiMessageBoxOptions> options = null)
        {
            var confirmOptions = CreateConfirmOptions(UiMessageBoxType.Error, message, title, options);
            return ModalService.ErrorAsync(confirmOptions);
        }

        public Task<bool> Confirm(string message, string title = null, Action<UiMessageBoxOptions> options = null)
        {
            var confirmOptions = CreateConfirmOptions(UiMessageBoxType.Confirmation, message, title, options);
            return ModalService.ConfirmAsync(confirmOptions);
        }

        protected virtual UiMessageBoxOptions CreateDefaultOptions()
        {
            return new UiMessageBoxOptions
            {
                CenterMessage = true,
                ShowMessageIcon = true,
                OkButtonText = null,
                CancelButtonText = null,
            };
        }

        protected ConfirmOptions CreateConfirmOptions(UiMessageBoxType type, string message, string title = null, Action<UiMessageBoxOptions> options = null)
        {
            var uiMessageOptions = CreateDefaultOptions();
            options?.Invoke(uiMessageOptions);
            var args = new UiMessageBoxEventArgs(type, message, title, uiMessageOptions);

            var isConfirmation = args.MessageType == UiMessageBoxType.Confirmation;
            var opt = new ConfirmOptions
            {
                Title = args.Title,
                Content = args.Message,
                OkCancel = isConfirmation,
                Centered = args.Options.CenterMessage,
            };
            if (args.Options.ShowMessageIcon)
            {
                if (args.Options.MessageIcon == null)
                {
                    opt.Icon = IconRenderFragments.GetByConfirmIcon(args.MessageType);
                }
                else
                {
                    if (args.Options.MessageIcon is RenderFragment fIcon)
                    {
                        opt.Icon = fIcon;
                    }
                    if (args.Options.MessageIcon is string sIcon)
                    {
                        opt.Icon = IconRenderFragments.GetByConfirmIcon(sIcon);
                    }
                }
            }
            var OkButtonText = args.Options.OkButtonText;
            var CancelButtonText = args.Options.CancelButtonText;
            if (OkButtonText != null) { opt.OkText = OkButtonText; }
            if (CancelButtonText != null) { opt.CancelText = CancelButtonText; }
            var OnOk = args.Options.OnOk;
            var OnCancel = args.Options.OnCancel;
            if (OnOk != null) { opt.OnOk = async e => { e.Cancel = !await OnOk.Invoke(); }; }
            if (OnCancel != null && isConfirmation) { opt.OnCancel = async e => { e.Cancel = !await OnCancel.Invoke(); }; }
            var okIcon = args.Options.OkButtonIcon;
            var cancelIcon = args.Options.CancelButtonIcon;
            if (okIcon != null && okIcon is string okIconStr)
            {
                opt.OkButtonProps = new ButtonProps { Icon = okIconStr, };
            }
            if (cancelIcon != null && cancelIcon is string cancelIconStr)
            {
                opt.CancelButtonProps = new ButtonProps { Icon = cancelIconStr, };
            }
            return opt;
        }
        internal static class IconRenderFragments
        {
            public static RenderFragment Info = (builder) =>
            {
                builder.OpenComponent<Icon>(0);
                builder.AddAttribute(1, "Type", "info-circle");
                builder.AddAttribute(2, "Theme", "outline");
                builder.CloseComponent();
            };

            public static RenderFragment Warning = (builder) =>
            {
                builder.OpenComponent<Icon>(0);
                builder.AddAttribute(1, "Type", "exclamation-circle");
                builder.AddAttribute(2, "Theme", "outline");
                builder.CloseComponent();
            };

            public static RenderFragment Error = (builder) =>
            {
                builder.OpenComponent<Icon>(0);
                builder.AddAttribute(1, "Type", "close-circle");
                builder.AddAttribute(2, "Theme", "outline");
                builder.CloseComponent();
            };

            public static RenderFragment Success = (builder) =>
            {
                builder.OpenComponent<Icon>(0);
                builder.AddAttribute(1, "Type", "check-circle");
                builder.AddAttribute(2, "Theme", "outline");
                builder.CloseComponent();
            };

            public static RenderFragment Question = (builder) =>
            {
                builder.OpenComponent<Icon>(0);
                builder.AddAttribute(1, "Type", "question-circle");
                builder.AddAttribute(2, "Theme", "outline");
                builder.CloseComponent();
            };

            public static RenderFragment GetByConfirmIcon(UiMessageBoxType type)
            {
                return type switch
                {
                    UiMessageBoxType.Info => Info,
                    UiMessageBoxType.Warning => Warning,
                    UiMessageBoxType.Error => Error,
                    UiMessageBoxType.Success => Success,
                    UiMessageBoxType.Confirmation => Question,
                    _ => null,
                };
            }
            public static RenderFragment GetByConfirmIcon(string iconType)
            {
                return (builder) =>
                {
                    builder.OpenComponent<Icon>(0);
                    builder.AddAttribute(1, "Type", iconType);
                    builder.AddAttribute(2, "Theme", "outline");
                    builder.CloseComponent();
                };
            }
        }
    }
}