using System;
using System.Collections.Generic;
using Android.Views;
using RxComponentization.NET;
using RxComponentization.NET.Events;
using SampleApp.Events;
using SampleApp.Model;

namespace SampleApp.Components.ResultsComponent
{
    public class ResultsComponent : UiComponent
    {
        private readonly ResultsView resultsView;

        public ResultsComponent(ViewGroup container)
        {
            resultsView = new ResultsView(container);
        }

        public override int ContainerId => resultsView.ContainerId;

        public override IObservable<UiEvent> UiEvents => resultsView.UiEvents;

        public override void StateEventReceived(StateEvent stateEvent)
        {
            if (stateEvent is ResultState<IEnumerable<Post>> results)
            {
                resultsView.Bind(results.Results);
                resultsView.Show();
            }
            else
                resultsView.Hide();
        }
    }
}