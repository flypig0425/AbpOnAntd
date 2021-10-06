using Volo.Abp.DependencyInjection;
using Zero.Abp.AspNetCore.Components.Alerts;

namespace Zero.Abp.AspNetCore.Components.Web.Alerts
{
    public class AlertManager : IAlertManager, IScopedDependency
    {
        public AlertList Alerts { get; }

        public AlertManager()
        {
            Alerts = new AlertList();
        }
    }
}