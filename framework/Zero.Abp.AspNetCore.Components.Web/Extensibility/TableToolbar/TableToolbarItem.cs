using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Volo.Abp;

namespace Zero.Abp.AspNetCore.Components.Web.Extensibility.TableToolbar
{
    public class TableToolbarItem
    {
        [NotNull]
        public Type ComponentType { get; }

        [CanBeNull]
        public Dictionary<string, object> Arguments { get; set; }

        public int Order { get; set; }

        public TableToolbarItem(
            [NotNull] Type componentType,
            [CanBeNull] Dictionary<string, object> arguments = null,
            int order = 0)
        {
            ComponentType = Check.NotNull(componentType, nameof(componentType));
            Arguments = arguments;
            Order = order;
        }
    }
}
