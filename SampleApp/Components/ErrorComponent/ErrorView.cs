using System;
using System.Linq;
using System.Reactive.Linq;
using Android.Views;
using RxComponentization.NET;
using RxComponentization.NET.Events;
using SampleApp.Events;

namespace SampleApp.Components.ErrorComponent
{
    public class ErrorView : UiView
    {
        View _view;

        IObservable<UiEvent> _uiEvents;

        public ErrorView(ViewGroup container)
        {
            _view = LayoutInflater
                    .From(container.Context)
                    .Inflate(Resource.Layout.error, container, true)
                    .FindViewById(Resource.Id.error_container);

            _uiEvents = Observable.FromEventPattern(handler => _view.Click += handler, handler => _view.Click -= handler)
                                  .Select(_ => new ErrorClicked());
        }

        public override int ContainerId => Resource.Id.error_container;

        public override IObservable<UiEvent> UiEvents => _uiEvents;

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