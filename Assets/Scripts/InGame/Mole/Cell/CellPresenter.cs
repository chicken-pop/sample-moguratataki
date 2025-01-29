using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using UniRx;

public class CellPresenter
{
    private CellModel _model;
    public CellModel Model => _model;

    private CellView _view;

    private CancellationTokenSource _cancellationTokenSource;

    private readonly CompositeDisposable _disposable;
    public CompositeDisposable Disposable => _disposable;

    public CellPresenter(CellModel model, CellView view)
    {
        _model = model;
        _view = view;

        _cancellationTokenSource = new CancellationTokenSource();
        _disposable = new CompositeDisposable();

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
            .AddTo(_disposable);
    }

    private void SubscribeViewObservable()
    {
        _view.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _model.SetBonusState();
            })
            .AddTo(_disposable);
    }
    public void SetState(CellState cellState)
    {
        _model.SetState(cellState);
    }

    public void Dispose()
    {
        _disposable?.Dispose();
    }
}
