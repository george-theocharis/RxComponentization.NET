using System;
using Android.Views;
using RxComponentization.NET;
using RxComponentization.NET.Events;
using SampleApp.Events;

namespace SampleApp.Components.ErrorComponent
{
    public class ErrorComponent : UiComponent
    {
        private readonly ErrorView errorView;

        public ErrorComponent(ViewGroup container)
        {
            errorView = new ErrorView(container);
        }

        public override int ContainerId => errorView.ContainerId;

        public override IObservable<UiEvent> UiEvents => errorView.UiEvents;

        public override void StateEventReceived(StateEvent stateEvent)
        {
            if (stateEvent is ErrorState error)
                errorView.Show();
            else
                errorView.Hide();
        }
    }
}