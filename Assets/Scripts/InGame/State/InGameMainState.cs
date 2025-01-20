using GameState;
using Utility;

public class InGameMainState : InGameState
{
    public InGameMainState(
        InGamePresenter inGamePresenter,
        InGameStateMachine inGameStateMachine)
        : base(inGamePresenter, inGameStateMachine)
    {
    }

    public override void Enter()
    {
        DebugUtility.Log("Start MainState");
        //TODO : もぐらたたき開始
    }

    public override void Exit()
    {
        DebugUtility.Log("End MainState");
        //TODO : ResultStateへ
    }  
}
