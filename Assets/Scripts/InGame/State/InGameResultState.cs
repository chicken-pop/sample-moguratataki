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
        DebugUtility.Log("Start MainState");
        //TODO : ���ʂ�\��
    }

    public override void Exit()
    {

    }
}
