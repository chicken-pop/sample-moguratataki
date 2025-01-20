using UniRx;

public class TimerPresenter
{
    private TimerModel _model;
    private TimerView _view;

    public TimerPresenter(ref TimerModel model, TimerView view)
    {
        _model = model;
        _view = view;

        _model.Initialize();

        SubscribeModelObservable();

    }

    private void SubscribeModelObservable()
    {
        _model.CountDown
            .Subscribe(value =>
            {
                _view.SetCountDownText(value);
            })
            .AddTo(_model.Disposable);

        _model.Timer
            .Subscribe(value =>
            {
                _view.SetTimerText(value);
            })
            .AddTo(_model.Disposable);
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
