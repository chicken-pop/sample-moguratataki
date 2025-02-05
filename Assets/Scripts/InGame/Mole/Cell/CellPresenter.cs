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
                // キャラ画像時のみ、ボタン有効
                _view.SetInteractable(newState);

                List<UniTask> tasks = new List<UniTask>();

                // 初期値はなし、キャラのステートで表示、ボーナス時は一定時間で消える
                tasks.Add(_view.SetCharacterImage(newState, _cancellationTokenSource.Token));
                // 初期値はなし、ボーナスのステートで表示し、一定時間で消える
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
