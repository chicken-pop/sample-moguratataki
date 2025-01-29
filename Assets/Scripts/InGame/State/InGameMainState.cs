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

        // ‚à‚®‚ç‚½‚½‚«ŠJŽn
        await _inGamePresenter.MoleManager.RandomlyUpdateCells(_cancellationTokenSource.Token);
    }

    public override void Exit()
    {
        _cancellationTokenSource.Cancel();

        DebugUtility.Log("End MainState");
    }  
}
