using AntDesign;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Abp.AntBlazorUI.Components.ExtensibleDataTable
{
    public partial class DataTableEntityActionsColumn<TItem> : Column<TItem>
    {
        [Inject]
        public IStringLocalizer<AbpUiResource> UiLocalizer { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await SetDefaultValuesAsync();
        }

        protected virtual ValueTask SetDefaultValuesAsync()
        {
            Title = UiLocalizer["Actions"];
            Width = "150px";
            Sortable = false;
            DataIndex = typeof(TItem).GetProperties().First().Name;
            return ValueTask.CompletedTask;
        }
    }
}
