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

        // �^�C�}�[�A�J�E���g�_�E���̕\�L��ݒ�
        _inGamePresenter.TimerPresenter.SetUp();
    }

    public override void Update()
    {
        // �J�E���g�_�E��
        _inGamePresenter.TimerPresenter.CountDownManualUpdate();
    }

    public override void Exit()
    {
        DebugUtility.Log("End StartState");
    }


}
