using System;
using UniRx;

public class TimerPresenter
{
    private TimerModel _model;
    private TimerView _view;

    private Subject<Unit> _startGameSubject = new Subject<Unit>();
    public IObservable<Unit> StartGameObservable => _startGameSubject;

    private Subject<Unit> _endGameSubject = new Subject<Unit>();
    public IObservable<Unit> EndGameObservable => _endGameSubject;

    public TimerPresenter(ref TimerModel model, TimerView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        _model.Initialize();

        SubscribeModelObservable();
    }

    private void SubscribeModelObservable()
    {
        _model.CountDown
            .Subscribe(value =>
            {
                _view.SetCountDownText(value);
                if (value < 0)
                {
                    _startGameSubject.OnNext(Unit.Default);
                    _view.IsCountDownTextActive(false);
                }
            })
            .AddTo(_model.Disposable);

        _model.Timer
            .Subscribe(value =>
            {
                _view.SetTimerText(value);
                if (value < 0)
                {
                    _endGameSubject.OnNext(Unit.Default);
                }
            })
            .AddTo(_model.Disposable);
    }

    /// <summary>
    /// タイマー、カウントダウンの値を設定
    /// </summary>
    public void SetUp()
    {
        _model.SetUp();
    }

    public void CountDownManualUpdate()
    {
        _model.CountDownManualUpdate();
    }

    public void TimerManualUpdate()
    {
        _model.TimerManualUpdate();
    }
}
