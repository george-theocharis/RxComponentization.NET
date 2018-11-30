using System;
using RxComponentization.NET.Events;

namespace RxComponentization.NET
{
    public abstract class UiComponent
    {
        public abstract int ContainerId { get; }
        public abstract IObservable<UiEvent> UiEvents { get; }
    }
}
