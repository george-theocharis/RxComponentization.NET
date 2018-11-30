using RxComponentization.NET.Events;

namespace SampleApp.Events
{
    public sealed class ResultState<T> : StateEvent
    {
        public T Results { get; }

        public ResultState(T results)
        {
            Results = results;
        }
    }
}