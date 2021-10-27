using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Zero.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
using Zero.Abp.AspNetCore.Components.Web.Extensibility.TableToolbar;

namespace Zero.Abp.AntBlazorUI.Components.ExtensibleDataTable
{
    public partial class AbpExtensibleDataTable<TItem> : ComponentBase
    {
        protected const string DataFieldAttributeName = "Data";

        //protected Dictionary<string, DataTableEntityActionsColumn<TItem>> ActionColumns = new();

        protected Regex ExtensionPropertiesRegex = new(@"ExtraProperties\[(.*?)\]");

        [Parameter] public IEnumerable<TItem> Data { get; set; }

        [Parameter] public EventCallback<QueryModel<TItem>> ReadData { get; set; }

        [Parameter] public int? TotalItems { get; set; }

        [Parameter] public bool ShowPager { get; set; }

        [Parameter] public int PageSize { get; set; }

        [Parameter] public IEnumerable<TableColumn> Columns { get; set; }
        [Parameter] public IEnumerable<TableToolbarItem> Toolbar { get; set; }

        [Parameter] public int CurrentPage { get; set; } = 1;

        [Inject]
        public IStringLocalizerFactory StringLocalizerFactory { get; set; }

        protected virtual RenderFragment RenderTableToolbarComponent(TableToolbarItem item)
        {
            var sequence = 0;
            return (builder) =>
            {
                builder.OpenComponent(sequence, item.ComponentType);
                if (item.Arguments != null)
                {
                    foreach (var argument in item.Arguments)
                    {
                        sequence++;
                        builder.AddAttribute(sequence, argument.Key, argument.Value);
                    }
                }
                builder.CloseComponent();
            };
        }

        protected virtual RenderFragment RenderCustomTableColumnComponent(Type type, object data)
        {
            return (builder) =>
            {
                builder.OpenComponent(0, type);
                builder.AddAttribute(0, DataFieldAttributeName, data);
                builder.CloseComponent();
            };
        }

        protected virtual string GetConvertedFieldValue(TItem item, TableColumn columnDefinition)
        {
            var convertedValue = columnDefinition.ValueConverter.Invoke(item);
            if (!columnDefinition.DisplayFormat.IsNullOrEmpty())
            {
                return string.Format(columnDefinition.DisplayFormatProvider, columnDefinition.DisplayFormat, convertedValue);
            }

            return convertedValue;
        }
    }
}