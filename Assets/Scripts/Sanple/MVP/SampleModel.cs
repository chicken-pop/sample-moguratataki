using System;
using UniRx;

public class SampleModel
{
    private ReactiveProperty<int> _score;
    public IReadOnlyReactiveProperty<int> Score => _score;

    private int _countDown = 3;
    public event Action<int> CountUpdate;

    public SampleModel()
    {
        _score = new ReactiveProperty<int>(0);
    }

    public void AddScore()
    {
        _score.Value++;
    }

    public void TimeLapse()
    {
        _countDown--;
        CountUpdate(_countDown);
    }
}
