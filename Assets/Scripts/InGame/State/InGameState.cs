namespace GameState
{
    public abstract class InGameState
    {
        protected InGamePresenter InGamePresenter;

        protected InGameStateMachine InGameStateMachine;

        public InGameState(InGamePresenter inGamePresenter, InGameStateMachine inGameStateMachine)
        {
            InGamePresenter = inGamePresenter;
            InGameStateMachine = inGameStateMachine;
        }

        /// <summary>
        /// �X�e�[�g�ɓ������u�ԂɎ��s��������
        /// </summary>
        public virtual void Enter() { }

        /// <summary>
        /// ���̃X�e�[�g�̊ԁA���s��������
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// �X�e�[�g�𔲂���Ƃ��Ɏ��s��������
        /// </summary>
        public virtual void Exit() { }
    }
}


