using System;
using System.Reactive.Linq;
using Android.Views;
using Android.Widget;
using RxComponentization.NET;
using RxComponentization.NET.Events;


namespace SampleApp.Components.ResultsComponent
{
    public class ResultsView : UiView
    {
        View _view;

        public ResultsView(ViewGroup container)
        {
            _view = LayoutInflater
                        .From(container.Context)
                        .Inflate(Resource.Layout.results, container, true)
                        .FindViewById<TextView>(Resource.Id.tv_success);
        }

        public override int ContainerId => Resource.Layout.loading;

        public override IObservable<UiEvent> UiEvents => Observable.Never<UiEvent>();

        public override void Show()
        {
            _view.Visibility = ViewStates.Visible;
        }

        public override void Hide()
        {
            _view.Visibility = ViewStates.Gone;
        }    
    }
}