using Microsoft.AspNetCore.Components;
using OneOf;

namespace Zero.Abp.AntBlazor.Layout
{
    public class LinkItem
    {
        public string Key { get; set; }

        public OneOf<string, RenderFragment> Title { get; set; }

        public string Href { get; set; }

        /// <summary>
        /// "_blank" or "_self"
        /// </summary>
        public string Target { get; set; } = "_blank";
    }
}