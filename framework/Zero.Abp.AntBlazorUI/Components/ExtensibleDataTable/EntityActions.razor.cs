﻿using AntDesign;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zero.Abp.AntBlazorUI.Components.ExtensibleDataTable
{
    public partial class EntityActions<TItem> : ComponentBase
    {
        protected readonly List<EntityAction<TItem>> Actions = new();
        protected bool HasPrimaryAction => Actions.Any(t => t.Primary);
        protected EntityAction<TItem> PrimaryAction => Actions.FirstOrDefault(t => t.Primary);

        [Parameter]
        public string ToggleType { get; set; } = ButtonType.Primary;

        [Parameter]
        public string ToggleText { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public DataTableEntityActionsColumn<TItem> EntityActionsColumn { get; set; }

        [Parameter]
        public ActionType Type { get; set; } = ActionType.Dropdown;

        [CascadingParameter]
        public DataTableEntityActionsColumn<TItem> ParentEntityActionsColumn { get; set; }

        [Inject]
        public IStringLocalizer<AbpUiResource> UiLocalizer { get; set; }

        internal void AddAction(EntityAction<TItem> action)
        {
            Actions.Add(action);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ToggleText = UiLocalizer["Actions"];
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (ParentEntityActionsColumn != null)
                {
                    ParentEntityActionsColumn.Hidden = Actions.All(t => !t.Visible || !t.HasPermission);
                }
                await InvokeAsync(StateHasChanged);
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
