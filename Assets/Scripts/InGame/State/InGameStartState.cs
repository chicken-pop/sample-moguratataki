using GameState;
using Utility;

public class InGameStartState : InGameState
{
    public InGameStartState(
        InGamePresenter inGamePresenter,
        InGameStateMachine inGameStateMachine)
        : base(inGamePresenter, inGameStateMachine)
    {
    }

    public override void Enter()
    {
        DebugUtility.Log("Start StartState");
        //TODO : カウントダウンの開始
    }

    public override void Update()
    {
        //TODO : カウントダウン
    }

    public override void Exit()
    {
        DebugUtility.Log("End StartState");
        //TODO : MainStateへ
    }

   
}
