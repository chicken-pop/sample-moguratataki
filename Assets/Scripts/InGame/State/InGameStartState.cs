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
        //TODO : �J�E���g�_�E���̊J�n
    }

    public override void Update()
    {
        //TODO : �J�E���g�_�E��
    }

    public override void Exit()
    {
        DebugUtility.Log("End StartState");
        //TODO : MainState��
    }

   
}
