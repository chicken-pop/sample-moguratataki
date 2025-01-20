using Utility;

namespace GameState
{
    public class InGameInitState : InGameState
    {
        public InGameInitState(
            InGamePresenter inGamePresenter,
            InGameStateMachine inGameStateMachine)
            : base(inGamePresenter, inGameStateMachine)
        {
        }

        public override void Enter()
        {
            DebugUtility.Log("Start InitState");
            //TODO : �I�u�W�F�N�g�̏������Ȃ�
        }

        public override void Exit()
        {
            DebugUtility.Log("End InitState");
            //TODO : GameStartState��
        }
    }
}


