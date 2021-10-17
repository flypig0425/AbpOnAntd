using System;
using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.Messages
{
    public interface IUiMessageService
    {
        Task Info(string message, Action<UiMessageOptions> options = null);

        Task Success(string message, Action<UiMessageOptions> options = null);

        Task Warn(string message, Action<UiMessageOptions> options = null);

        Task Error(string message, Action<UiMessageOptions> options = null);

        Task Loading(string message, Action<UiMessageOptions> options = null);
    }
}
