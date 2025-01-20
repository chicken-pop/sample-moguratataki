using GameState;

public class InGamePresenter
{
    private InGameModel _model;
    private InGameView _view;

    /// <summary>
    /// ステートマシン
    /// </summary>
    private InGameStateMachine _inGameStateMachine;
    public InGameStateMachine InGameStateMachine => _inGameStateMachine;

    /// <summary>
    /// 各ステート
    /// </summary>
    #region　State
    private InGameInitState _inGameInitState;
    public InGameInitState InGameInitState => _inGameInitState;
    private InGameStartState _inGameStartState;
    public InGameStartState InGameStartState => _inGameStartState;
    private InGameMainState _inGameMainState;
    public InGameMainState InGameMainState => _inGameMainState;
    private InGameResultState _inGameResultState;
    public InGameResultState InGameResultState => _inGameResultState;
    #endregion

    public InGamePresenter(InGameModel model, InGameView view)
    {
        _model = model;
        _view = view;

        _inGameStateMachine = new InGameStateMachine();

        _inGameInitState = new InGameInitState(this, _inGameStateMachine);
        _inGameStartState = new InGameStartState(this, _inGameStateMachine);
        _inGameMainState = new InGameMainState(this, _inGameStateMachine);
        _inGameResultState = new InGameResultState(this, _inGameStateMachine);
    }

    public void Initialize()
    {
        _inGameStateMachine.InitializeGameState(_inGameInitState);
    }

    public void ManualUpdate()
    {
        _inGameStateMachine.CurrentGameState.Update();
    }
}
