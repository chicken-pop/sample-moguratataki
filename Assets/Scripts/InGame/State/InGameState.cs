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
        /// ステートに入った瞬間に実行されるもの
        /// </summary>
        public virtual void Enter() { }

        /// <summary>
        /// そのステートの間、実行されるもの
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// ステートを抜けるときに実行されるもの
        /// </summary>
        public virtual void Exit() { }
    }
}


