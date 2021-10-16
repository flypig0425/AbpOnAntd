using System;
using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.MessageBoxs
{
    public class UiMessageBoxEventArgs : EventArgs
    {
        public UiMessageBoxEventArgs(UiMessageBoxType messageType, string message, string title, UiMessageBoxOptions options)
        {
            MessageType = messageType;
            Message = message;
            Title = title;
            Options = options;
        }

        public UiMessageBoxEventArgs(UiMessageBoxType messageType, string message, string title, UiMessageBoxOptions options, TaskCompletionSource<bool> callback)
        {
            MessageType = messageType;
            Message = message;
            Title = title;
            Options = options;
            Callback = callback;
        }

        public UiMessageBoxType MessageType { get; set; }

        public string Message { get; }

        public string Title { get; }

        public UiMessageBoxOptions Options { get; }

        public TaskCompletionSource<bool> Callback { get; }
    }
}
