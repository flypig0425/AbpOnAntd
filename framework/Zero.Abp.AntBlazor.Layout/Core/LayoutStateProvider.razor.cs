using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Zero.Abp.AntBlazor.Layout.Core
{
    public partial class LayoutStateProvider
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Inject] protected ILayoutConfigProvider LayoutConfigProvider { get; set; }


        public LayoutSettings Settings { get; internal set; }


        private bool isLoaded;
        protected override async Task OnInitializedAsync()
        {
            Settings = await LayoutConfigProvider.GetSettingsAsync();
            isLoaded = true;
        }

        //public async Task SaveChangesAsync()
        //{
        //    await ProtectedSessionStore.SetAsync("count", CurrentCount);
        //}
    }
}
}
