using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using RxComponentization.NET;
using RxComponentization.NET.Events;
using SampleApp.Model;

namespace SampleApp.Components.ResultsComponent
{
    public class ResultsView : UiView
    {
        RecyclerView _view;
        private PostAdapter _postsAdapter;

        public ResultsView(ViewGroup container)
        {
            _view = LayoutInflater
                        .From(container.Context)
                        .Inflate(Resource.Layout.results, container, true)
                        .FindViewById<RecyclerView>(Resource.Id.results);

            _postsAdapter = new PostAdapter();

            _view.SetLayoutManager(new LinearLayoutManager(container.Context, LinearLayoutManager.Vertical, false));
            _view.SetAdapter(_postsAdapter);
        }

        public override int ContainerId => Resource.Layout.loading;

        public override IObservable<UiEvent> UiEvents => Observable.Never<UiEvent>();

        public override void Show()
        {
            _view.Visibility = ViewStates.Visible;
        }

        internal void Bind(IEnumerable<Post> results)
        {
            _postsAdapter.Update(results);
        }

        public override void Hide()
        {
            _view.Visibility = ViewStates.Gone;
        }    
    }
}