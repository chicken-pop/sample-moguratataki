using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using UniRx;

public class CellPresenter : PresenterBase
{
    private CellModel _model;
    public CellModel Model => _model;
    private CellView _view;

    private CancellationTokenSource _cancellationTokenSource;

    public CellPresenter(CellModel model, CellView view)
    {
        _model = model;
        _view = view;

        _cancellationTokenSource = new CancellationTokenSource();

        SubscribeModelObservable();
        SubscribeViewObservable();
    }

    private void SubscribeModelObservable()
    {
        _model.CurrentCellState
            .Subscribe(async newState =>
            {
                // �L�����摜���̂݁A�{�^���L��
                _view.SetInteractable(newState);

                List<UniTask> tasks = new List<UniTask>();

                // �����l�͂Ȃ��A�L�����̃X�e�[�g�ŕ\���A�{�[�i�X���͈�莞�Ԃŏ�����
                tasks.Add(_view.SetCharacterImage(newState, _cancellationTokenSource.Token));
                // �����l�͂Ȃ��A�{�[�i�X�̃X�e�[�g�ŕ\�����A��莞�Ԃŏ�����
                tasks.Add(_view.SetPointImage(newState, _cancellationTokenSource.Token));

                await UniTask.WhenAll(tasks);

                _model.SetPressValue(false);
            })
            .AddTo(Disposable);
    }

    private void SubscribeViewObservable()
    {
        _view.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _model.SetBonusState();
            })
            .AddTo(Disposable);
    }
    public void SetState(CellState cellState)
    {
        _model.SetState(cellState);
    }
}
