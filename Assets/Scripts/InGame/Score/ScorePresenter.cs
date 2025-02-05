using System;
using UniRx;
using Utility;

public class ScorePresenter : PresenterBase
{
    private ScoreModel _model;
    private ScoreView _view;

    public ScorePresenter(ScoreModel model, ScoreView view)
    {
        _model = model;
        _view = view;

        SubscribeModelObservable();
    }

    private void SubscribeModelObservable()
    {
        _model.GameStorage.CurrentScoreRP
            .Subscribe(value =>
            {
                _view.SetScore(value);
            })
        .AddTo(Disposable);
    }

    public void SetUp()
    {
        _model.GameStorage.SetupCurrentScore(0);
    }
}
