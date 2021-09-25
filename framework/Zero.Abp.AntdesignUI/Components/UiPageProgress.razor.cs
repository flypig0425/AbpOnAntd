using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using Zero.Abp.AspNetCore.Components.Progression;

namespace Zero.Abp.AntdesignUI.Components
{
    public partial class UiPageProgress : ComponentBase, IDisposable
    {
        protected double Percent { get; set; }

        protected bool Visible { get; set; }

        protected ProgressStatus Status { get; set; }

        [Inject] protected IUiPageProgressService UiPageProgressService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            UiPageProgressService.ProgressChanged += OnProgressChanged;
        }

        private async void OnProgressChanged(object sender, UiPageProgressEventArgs e)
        {
            Percent = e.Percentage??0;
            Visible = e.Percentage == null || (e.Percentage >= 0 && e.Percentage <= 100);
            Status = GetStatus(e.Options.Type);
            await InvokeAsync(StateHasChanged);
        }

        public virtual void Dispose()
        {
            if (UiPageProgressService != null)
            {
                UiPageProgressService.ProgressChanged -= OnProgressChanged;
            }
        }

        protected virtual ProgressStatus GetStatus(UiPageProgressType pageProgressType)
        {
            return pageProgressType switch
            {
                UiPageProgressType.Info => ProgressStatus.Active,
                UiPageProgressType.Success => ProgressStatus.Success,
                UiPageProgressType.Warning => ProgressStatus.Exception,
                UiPageProgressType.Error => ProgressStatus.Exception,
                _ => ProgressStatus.Normal,
            };
        }
    }
}
