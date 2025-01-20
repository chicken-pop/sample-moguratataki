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
            //TODO : オブジェクトの初期化など
        }

        public override void Exit()
        {
            DebugUtility.Log("End InitState");
            //TODO : GameStartStateへ
        }
    }
}


