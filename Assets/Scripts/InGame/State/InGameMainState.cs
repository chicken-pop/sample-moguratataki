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
        //TODO : �����炽�����J�n
    }

    public override void Exit()
    {
        DebugUtility.Log("End MainState");
        //TODO : ResultState��
    }  
}
