using GameState;
using Utility;

public class InGameResultState : InGameState
{
    public InGameResultState(
        InGamePresenter inGamePresenter,
        InGameStateMachine inGameStateMachine)
        : base(inGamePresenter, inGameStateMachine)
    {
    }

    public override void Enter()
    {
        DebugUtility.Log("Start ResultState");
        //TODO : 結果を表示
    }

    public override void Exit()
    {

    }
}
