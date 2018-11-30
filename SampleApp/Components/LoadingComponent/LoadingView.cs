using System;
using System.Reactive.Linq;
using Android.Views;
using Android.Widget;
using RxComponentization.NET;
using RxComponentization.NET.Events;

namespace SampleApp.Components.LoadingComponent
{
    public class LoadingView : UiView
    {
        View _view;

        public LoadingView(ViewGroup container)
        {
            _view = LayoutInflater
                        .From(container.Context)
                        .Inflate(Resource.Layout.loading, container, true)
                        .FindViewById<ProgressBar>(Resource.Id.loadingSpinner);
        }

        public override int ContainerId => Resource.Layout.loading;

        public override IObservable<UiEvent> UiEvents => Observable.Never<UiEvent>();

        public override void Hide()
        {
            _view.Visibility = ViewStates.Gone;
        }

        public override void Show()
        {
            _view.Visibility = ViewStates.Visible;
        }
    }
}