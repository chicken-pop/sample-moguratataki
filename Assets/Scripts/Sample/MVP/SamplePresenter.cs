using UniRx;
using UnityEngine;

public class SamplePresenter : MonoBehaviour
{
    [SerializeField]
    private SampleView _sampleView;
    private SampleModel _sampleModel;

    private void Start()
    {
        _sampleModel = new SampleModel();

        // UniRx（ReactiveProperty）を使用
        // Scoreの値が変更されるごとにSubscribe内の処理が実行
        // メモリ解放は自発的にしなければならない、この例ではこのGameObjectが破壊された時にメモリ解放
        // WhereなどSubscribe前に色々な処理ができる

        _sampleModel.Score
            .Where(value => value != 0)
            .Subscribe(value =>
            {
                _sampleView.SetScoreText(value);
            })
            .AddTo(this);

        // UniRxを未使用
        _sampleModel.CountUpdate += _sampleView.SetCountDownText;

        InputProvider.Instance.OnClickAsObservable
            .Subscribe(_ =>
            {
                _sampleModel.AddScore();
                _sampleModel.TimeLapse();
            })
            .AddTo(this);
    }

    private void OnDestroy()
    {
        _sampleModel.CountUpdate -= _sampleView.SetCountDownText;
    }

}
