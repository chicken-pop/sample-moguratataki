namespace GameState
{
    public class InGameStateMachine
    {
        /// <summary>
        /// 現在のステート
        /// </summary>
        private InGameState _currentGameState;
        public InGameState CurrentGameState => _currentGameState;

        /// <summary>
        /// ステートの初期化
        /// </summary>
        /// <param name="initializeGameState"></param>
        public void InitializeGameState(InGameState initializeGameState)
        {
            _currentGameState = initializeGameState;
            _currentGameState.Enter();
        }

        /// <summary>
        /// ステートの変更
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


