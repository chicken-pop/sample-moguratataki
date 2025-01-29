using System;
using UniRx;
using Utility;

public class ScorePresenter : IDisposable
{
    private ScoreModel _model;
    private ScoreView _view;

    private readonly CompositeDisposable _disposable;
    public CompositeDisposable Disposable => _disposable;

    public ScorePresenter(ScoreModel model, ScoreView view)
    {
        _model = model;
        _view = view;

        _disposable = new CompositeDisposable();

        SubscribeModelObservable();
    }

    private void SubscribeModelObservable()
    {
        _model.GameStorage.CurrentScoreRP
            .Subscribe(value =>
            {
                _view.SetScore(value);
            })
        .AddTo(_disposable);
    }

    public void SetUp()
    {
        _model.GameStorage.SetupCurrentScore(0);
    }

    public void Dispose()
    {
        _disposable?.Dispose();
    }
}
