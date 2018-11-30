using System;
using RxComponentization.NET.Events;

namespace RxComponentization.NET
{
    public abstract class UiView
    {
        public abstract int ContainerId { get; }
        public abstract void Show();
        public abstract void Hide();
        public abstract IObservable<UiEvent> UiEvents { get; }
    }
}
