using AntDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Abp.AntBlazorUI.Components;
using Zero.Abp.AspNetCore.Components.Web.Extensibility.TableToolbar;

namespace Zero.Abp.AspNetCore.Components.Web.Theming.Extensibility
{
    public static class TableToolbarExtensions
    {
        public static List<TableToolbarItem> AddComponent<TComponent>(
            this List<TableToolbarItem> toolbar,
            Dictionary<string, object> arguments = null,
            int order = 0,
             Func<bool> visible = null)
        {
            return toolbar.AddComponent(
                typeof(TComponent),
                arguments,
                order,
                visible
            );
        }

        public static List<TableToolbarItem> AddComponent(
            this List<TableToolbarItem> toolbar,
            Type componentType,
            Dictionary<string, object> arguments = null,
            int order = 0,
            Func<bool> visible = null)
        {
            if (visible?.Invoke() ?? true)
            {
                toolbar.Add(new TableToolbarItem(componentType, arguments, order));
            }
            return toolbar;
        }

        public static List<TableToolbarItem> AddButton(
            this List<TableToolbarItem> toolbar,
            string text,
            Func<Task> clicked,
            string icon = null,
            string type = null,
            Color color = Color.None,
            bool disabled = false,
            int order = 0,
             Func<bool> visible = null)
        {
            toolbar.AddComponent<ToolbarButton>(
                new Dictionary<string, object>
                {
                    { nameof(ToolbarButton.Type), type},
                    { nameof(ToolbarButton.Color), color},
                    { nameof(ToolbarButton.Text), text},
                    { nameof(ToolbarButton.Disabled), disabled},
                    { nameof(ToolbarButton.Icon), icon},
                    { nameof(ToolbarButton.Clicked),clicked},
                },
                order,
                visible
            );

            return toolbar;
        }
    }
}
