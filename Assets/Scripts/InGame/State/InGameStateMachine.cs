namespace GameState
{
    public class InGameStateMachine
    {
        /// <summary>
        /// ���݂̃X�e�[�g
        /// </summary>
        private InGameState _currentGameState;
        public InGameState CurrentGameState => _currentGameState;

        /// <summary>
        /// �X�e�[�g�̏�����
        /// </summary>
        /// <param name="initializeGameState"></param>
        public void InitializeGameState(InGameState initializeGameState)
        {
            _currentGameState = initializeGameState;
            _currentGameState.Enter();
        }

        /// <summary>
        /// �X�e�[�g�̕ύX
        /// </summary>
        /// <param name="nextState"></param>
        public void ChangeState(InGameState nextState)
        {
            _currentGameState.Exit();
            _currentGameState = nextState;
            _currentGameState.Enter();
        }
    }
}


