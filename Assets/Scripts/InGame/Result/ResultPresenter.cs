using Cysharp.Threading.Tasks;
using System;
using UniRx;

public class ResultPresenter
{
    private ResultModel _model;
    private ResultView _view;

    private Subject<Unit> _retryButtonSubject = new Subject<Unit>();
    public IObservable<Unit> RetryButtonObservable => _retryButtonSubject;
    private Subject<Unit> _titleButtonSubject = new Subject<Unit>();
    public IObservable<Unit> TitleButtonObservable => _titleButtonSubject;

    private readonly CompositeDisposable _disposable;
    public CompositeDisposable Disposable => _disposable;

    public ResultPresenter(ResultModel model, ResultView view)
    {
        _model = model;
        _view = view;

        _disposable = new CompositeDisposable();

        SubscribeViewObservable();
    }

    private void SubscribeViewObservable()
    {
        _view.RetryButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _retryButtonSubject.OnNext(Unit.Default);
            })
            .AddTo(_disposable);

        _view.TitleButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _titleButtonSubject.OnNext(Unit.Default);
            })
            .AddTo(_disposable);
    }

    public void Setup()
    {
        _view.Setup();
    }

    /// <summary>
    /// ƒŠƒUƒ‹ƒg‚ð•\Ž¦
    /// </summary>
    public void ShowResult()
    {
        _view.SetRanking(_model.GetRankingUserData());
        _view.SetButton(true);
    }

    public void Dispose()
    {
        _disposable?.Dispose();
    }
}
