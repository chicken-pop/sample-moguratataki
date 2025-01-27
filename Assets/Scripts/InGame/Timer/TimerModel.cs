using UniRx;
using UnityEngine;

public class TimerModel : ModelBase
{
    private ReactiveProperty<float> _countDown;
    public IReadOnlyReactiveProperty<float> CountDown => _countDown;

    private ReactiveProperty<float> _timer;
    public IReadOnlyReactiveProperty<float> Timer => _timer;

    public void Initialize()
    {
        _countDown = new ReactiveProperty<float>();
        _timer = new ReactiveProperty<float>();
    }

    /// <summary>
    /// ílÇÃèâä˙ílÇê›íË
    /// </summary>
    public void SetUp()
    {
        _countDown.Value = ConstantData.COUNT_DOWN;
        _timer.Value = ConstantData.TIME;
    }

    public void CountDownManualUpdate()
    {
        _countDown.Value -= Time.deltaTime;
    }

    public void TimerManualUpdate()
    {
        _timer.Value -= Time.deltaTime;
    }
}
