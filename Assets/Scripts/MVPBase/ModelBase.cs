using System;
using UniRx;

public class ModelBase : IDisposable
{
    private readonly CompositeDisposable _disposable;
    public CompositeDisposable Disposable => _disposable;

    public ModelBase()
    {
        _disposable = new CompositeDisposable();
    }

    public virtual void Dispose()
    {
        _disposable?.Dispose();
    }
}
