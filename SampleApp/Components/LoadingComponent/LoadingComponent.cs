using System;
using Android.Views;
using RxComponentization.NET;
using RxComponentization.NET.Events;
using SampleApp.Events;

namespace SampleApp.Components.LoadingComponent
{
    public class LoadingComponent : UiComponent
    {
        private readonly LoadingView loadingView;

        public LoadingComponent(ViewGroup container)
        {
            loadingView = new LoadingView(container);
        }

        public override int ContainerId => loadingView.ContainerId;

        public override IObservable<UiEvent> UiEvents => loadingView.UiEvents;

        public override void StateEventReceived(StateEvent stateEvent)
        {
            if (stateEvent is LoadingState loading)
                loadingView.Show();
            else
                loadingView.Hide();
        }
    }
}