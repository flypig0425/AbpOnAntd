using System;
using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.Messages
{
    /// <summary>
    /// Options to override message dialog appearance.
    /// </summary>
    public class UiMessageOptions
    {
        public double? Duration { get; set; }

        public object Icon { get; set; }

        public string Key { get; set; }

    }
}
