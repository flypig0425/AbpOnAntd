using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Zero.Abp.AspNetCore.Components.Progression
{
    public class NullUiPageProgressService : IUiPageProgressService, ISingletonDependency
    {
#pragma warning disable CS0067 // 从不使用事件“NullUiPageProgressService.ProgressChanged”
        public event EventHandler<UiPageProgressEventArgs> ProgressChanged;
#pragma warning restore CS0067 // 从不使用事件“NullUiPageProgressService.ProgressChanged”

        public Task Go(int? percentage, Action<UiPageProgressOptions> options = null)
        {
            return Task.CompletedTask;
        }
    }
}
