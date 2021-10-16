using System;
using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.Messages
{
    public interface IUiMessageBoxService
    {
        Task<bool> Info(string message, string title = null, Action<UiMessageBoxOptions> options = null);

        Task<bool> Success(string message, string title = null, Action<UiMessageBoxOptions> options = null);

        Task<bool> Warn(string message, string title = null, Action<UiMessageBoxOptions> options = null);

        Task<bool> Error(string message, string title = null, Action<UiMessageBoxOptions> options = null);

        Task<bool> Confirm(string message, string title = null, Action<UiMessageBoxOptions> options = null);
    }
}
