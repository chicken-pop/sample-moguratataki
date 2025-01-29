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

        // �����炽�����J�n
        _inGamePresenter.MoleManager.SetCellObjects(true);
        await _inGamePresenter.MoleManager.RandomlyUpdateCells(_cancellationTokenSource.Token);
    }

    public override void Update()
    {
        // �^�C�}�[
        _inGamePresenter.TimerPresenter.TimerManualUpdate();
    }

    public override void Exit()
    {
        // �����炽�����I��
        _cancellationTokenSource.Cancel();
        _inGamePresenter.MoleManager.SetCellObjects(false);

        DebugUtility.Log("End MainState");
    }  
}
