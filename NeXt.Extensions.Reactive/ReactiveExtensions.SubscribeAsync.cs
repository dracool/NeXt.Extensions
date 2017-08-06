using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.Extensions.Reactive
{
    public static class ReactiveExtensions
    {
        public static IDisposable SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext, Action<Exception> onError, Action onCompleted)
        {
            return observable
                .SelectMany(async v =>
                {
                    await onNext(v);
                    return Unit.Default;
                })
                .Subscribe(
                    _ => { },
                    onError,
                    onCompleted
                );
        }

        public static IDisposable SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext, Action onCompleted)
        {
            return observable
                .SelectMany(async v =>
                {
                    await onNext(v);
                    return Unit.Default;
                })
                .Subscribe(
                    _ => { },
                    onCompleted
                );
        }

        public static IDisposable SubscribeAsync<T>(this IObservable<T> observable, Func<T, Task> onNext)
        {
            return observable
                .SelectMany(async v =>
                {
                    await onNext(v);
                    return Unit.Default;
                })
                .Subscribe(
                    _ => { }
                );
        }
    }
}
