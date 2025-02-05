using System;
using UniRx;

public class PresenterBase : IDisposable
{
    private readonly CompositeDisposable _disposable;
    public CompositeDisposable Disposable => _disposable;

    public PresenterBase()
    {
        _disposable = new CompositeDisposable();
    }

    public virtual void Dispose()
    {
        _disposable?.Dispose();
    }
}
