using System;
using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.Messages
{
    public class UiMessageEventArgs : EventArgs
    {
        public UiMessageEventArgs(UiMessageType messageType, string message, UiMessageOptions options)
        {
            MessageType = messageType;
            Message = message;
            Options = options;
        }

        public UiMessageType MessageType { get; set; }

        public string Message { get; }

        public UiMessageOptions Options { get; }
    }
}
