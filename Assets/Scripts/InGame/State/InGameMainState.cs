using GameState;
using System.Threading;
using Utility;

public class InGameMainState : InGameState
{
    private InGamePresenter _inGamePresenter;
    private InGameStateMachine _stateMachine;

    private CancellationTokenSource _cancellationTokenSource;

    public InGameMainState(
        InGamePresenter inGamePresenter,
        InGameStateMachine inGameStateMachine)
        : base(inGamePresenter, inGameStateMachine)
    {
        _inGamePresenter = inGamePresenter;
        _stateMachine = inGameStateMachine;
    }

    public override async void Enter()
    {
        DebugUtility.Log("Start MainState");

        _cancellationTokenSource = new CancellationTokenSource();

        // もぐらたたき開始
        _inGamePresenter.MoleManager.SetCellObjects(true);
        await _inGamePresenter.MoleManager.RandomlyUpdateCells(_cancellationTokenSource.Token);
    }

    public override void Update()
    {
        // タイマー
        _inGamePresenter.TimerPresenter.TimerManualUpdate();
    }

    public override void Exit()
    {
        // もぐらたたき終了
        _cancellationTokenSource.Cancel();
        _inGamePresenter.MoleManager.SetCellObjects(false);

        DebugUtility.Log("End MainState");
    }  
}
