using GameState;
using Utility;

public class InGameStartState : InGameState
{
    private InGamePresenter _inGamePresenter;
    private InGameStateMachine _stateMachine;

    public InGameStartState(
        InGamePresenter inGamePresenter,
        InGameStateMachine inGameStateMachine)
        : base(inGamePresenter, inGameStateMachine)
    {
        _inGamePresenter = inGamePresenter;
        _stateMachine = inGameStateMachine;
    }

    public override void Enter()
    {
        DebugUtility.Log("Start StartState");

        // タイマー、カウントダウンの表記を設定
        _inGamePresenter.TimerPresenter.SetUp();
        _inGamePresenter.ScorePresenter.SetUp();
        // リザルトの表記を設定
        _inGamePresenter.ResultPresenter.Setup();
    }

    public override void Update()
    {
        // カウントダウン
        _inGamePresenter.TimerPresenter.CountDownManualUpdate();
    }

    public override void Exit()
    {
        DebugUtility.Log("End StartState");
    }


}
