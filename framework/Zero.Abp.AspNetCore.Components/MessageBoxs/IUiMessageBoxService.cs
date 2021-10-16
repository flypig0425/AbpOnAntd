using System;
using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.MessageBoxs
{
    public interface IUiMessageBoxService
    {
        Task Info(string message, string title = null, Action<UiMessageBoxOptions> options = null);

        Task Success(string message, string title = null, Action<UiMessageBoxOptions> options = null);

        Task Warn(string message, string title = null, Action<UiMessageBoxOptions> options = null);

        Task Error(string message, string title = null, Action<UiMessageBoxOptions> options = null);

        Task<bool> Confirm(string message, string title = null, Action<UiMessageBoxOptions> options = null);
    }
}
