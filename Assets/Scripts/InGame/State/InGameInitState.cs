using Utility;

namespace GameState
{
    public class InGameInitState : InGameState
    {
        private InGamePresenter _inGamePresenter;
        private InGameStateMachine _stateMachine;

        public InGameInitState(
            InGamePresenter inGamePresenter,
            InGameStateMachine inGameStateMachine)
            : base(inGamePresenter, inGameStateMachine)
        {
            _inGamePresenter = inGamePresenter;
            _stateMachine = inGameStateMachine;
        }

        public override void Enter()
        {
            DebugUtility.Log("Start InitState");
            // �^�C�}�[�A�J�E���g�_�E���̏�����
            _inGamePresenter.TimerPresenter.Initialize();

            //TODO : �X�R�A�̏������A�����L���O�E�{�^���ނ̔�\��

            // StartState��
            _stateMachine.ChangeState(_inGamePresenter.InGameStartState);
        }

        public override void Exit()
        {
            DebugUtility.Log("End InitState");
        }
    }
}


