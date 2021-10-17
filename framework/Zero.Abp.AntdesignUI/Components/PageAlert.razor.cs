using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Zero.Abp.AspNetCore.Components.Alerts;
using AntAlertType = AntDesign.AlertType;

namespace Zero.Abp.AntdesignUI.Components
{
    public partial class PageAlert : ComponentBase, IDisposable
    {
        private readonly List<AlertWrapper> Alerts = new();

        [Inject]
        protected IAlertManager AlertManager { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            NavigationManager.LocationChanged += NavigationManager_LocationChanged;
            AlertManager.Alerts.CollectionChanged += Alerts_CollectionChanged;

            Alerts.AddRange(AlertManager.Alerts.Select(t => new AlertWrapper
            {
                AlertMessage = t,
                IsVisible = true
            }));
        }

        //Since Blazor WASM doesn't support scoped dependency, we need to clear alerts on each location changed event.
        private void NavigationManager_LocationChanged(object sender, LocationChangedEventArgs e)
        {
            AlertManager.Alerts.Clear();
            Alerts.Clear();
        }

        private void Alerts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    Alerts.Add(new AlertWrapper
                    {
                        AlertMessage = (AlertMessage)item,
                        IsVisible = true
                    });
                }
            }
            InvokeAsync(StateHasChanged);
        }

        protected virtual string GetAlertType(AlertType alertType)
        {
            var color = alertType switch
            {
                AlertType.Info => AntAlertType.Info,
                AlertType.Success => AntAlertType.Success,
                AlertType.Warning => AntAlertType.Warning,
                AlertType.Danger => AntAlertType.Error,
                AlertType.Default => AntAlertType.Default,
                _ => AntAlertType.Default
            };

            return color;
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= NavigationManager_LocationChanged;
            AlertManager.Alerts.CollectionChanged -= Alerts_CollectionChanged;
        }
    }

    internal class AlertWrapper
    {
        public AlertMessage AlertMessage { get; set; }
        public bool IsVisible { get; set; }
    }
}