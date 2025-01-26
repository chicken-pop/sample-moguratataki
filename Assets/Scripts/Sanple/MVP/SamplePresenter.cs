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

        // UniRx�iReactiveProperty�j���g�p
        // Score�̒l���ύX����邲�Ƃ�Subscribe���̏��������s
        // ����������͎����I�ɂ��Ȃ���΂Ȃ�Ȃ��A���̗�ł͂���GameObject���j�󂳂ꂽ���Ƀ��������
        // Where�Ȃ�Subscribe�O�ɐF�X�ȏ������ł���

        _sampleModel.Score
            .Where(value => value != 0)
            .Subscribe(value =>
            {
                _sampleView.SetScoreText(value);
            })
            .AddTo(this);

        // UniRx�𖢎g�p
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
