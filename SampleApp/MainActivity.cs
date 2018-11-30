using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Refit;
using RxComponentization.NET;
using RxComponentization.NET.Events;
using SampleApp.Components.ErrorComponent;
using SampleApp.Components.LoadingComponent;
using SampleApp.Components.ResultsComponent;
using SampleApp.Events;
using SampleApp.Model;

namespace SampleApp
{
    public interface IFakeApi
    {
        [Get("/posts")]
        IObservable<IEnumerable<Post>> GetPosts();
    }

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private List<UiComponent> _components;

        public IObservable<StateEvent> UseCase { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var client = RestService.For<IFakeApi>("https://jsonplaceholder.typicode.com");

            UseCase = BuildExampleUseCase(client);

            InitializeUiComponents(FindViewById<ViewGroup>(Resource.Id.container));

            UseCase
                .Subscribe(OnStateChanged);
        }

        private IObservable<StateEvent> BuildExampleUseCase(IFakeApi client)
          =>  client.GetPosts()
                  .Select(posts => new ResultState<IEnumerable<Post>>(posts))
                  .StartWith<StateEvent>(new LoadingState())
                  .Catch<StateEvent, Exception>(e => Observable.Return(new ErrorState()))
                  .SubscribeOn(TaskPoolScheduler.Default)
                  .ObserveOn(SynchronizationContext.Current);

        private void InitializeUiComponents(ViewGroup container)
        {
            var loadingComponent = new LoadingComponent(container);
            var resultsComponent = new ResultsComponent(container);
            var errorComponent = new ErrorComponent(container);

            _components = new List<UiComponent>
            {
                loadingComponent,
                resultsComponent,
                errorComponent
            };

            // uiEvents should initiate the stream of usecases from a presenter
            // like mvi. not the scope of this sample
        }


        private void OnStateChanged(StateEvent stateEvent)
        {
            foreach (var component in _components)
                component.StateEventReceived(stateEvent);
        }

    }
}