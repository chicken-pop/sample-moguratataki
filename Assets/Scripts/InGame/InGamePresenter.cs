using Cysharp.Threading.Tasks;
using GameState;
using System;
using UniRx;

public class InGamePresenter : IDisposable
{
    private InGameModel _inGameModel;
    private InGameView _inGameView;

    private TimerPresenter _timerPresenter;
    public TimerPresenter TimerPresenter => _timerPresenter;

    private ScorePresenter _scorePresenter;
    public ScorePresenter ScorePresenter => _scorePresenter;

    private MoleManager _moleManager;
    public MoleManager MoleManager => _moleManager;

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

    private readonly CompositeDisposable _disposable;
    public CompositeDisposable Disposable => _disposable;

    public InGamePresenter(
        InGameModel model,
        InGameView view,
        TimerPresenter timerPresenter,
        ScorePresenter scorePresenter,
        MoleManager moleManager)
    {
        _inGameModel = model;
        _inGameView = view;
        _timerPresenter = timerPresenter;
        _scorePresenter = scorePresenter;
        _moleManager = moleManager;

        _inGameStateMachine = new InGameStateMachine();

        _inGameInitState = new InGameInitState(this, _inGameStateMachine);
        _inGameStartState = new InGameStartState(this, _inGameStateMachine);
        _inGameMainState = new InGameMainState(this, _inGameStateMachine);
        _inGameResultState = new InGameResultState(this, _inGameStateMachine);

        _disposable = new CompositeDisposable();
    }

    public void Initialize()
    {
        _inGameStateMachine.InitializeGameState(_inGameInitState);
        _moleManager.Initialize();

        _timerPresenter.StartGameObservable
            .Subscribe(_ =>
            {
                // MainStateへ
                _inGameStateMachine.ChangeState(_inGameMainState);
            })
            .AddTo(_disposable);

        _timerPresenter.EndGameObservable
            .Subscribe(_ =>
            {
                // ResultStateへ
                _inGameStateMachine.ChangeState(_inGameResultState);
            })
            .AddTo(_disposable);
    }

    public void ManualUpdate()
    {
        _inGameStateMachine.CurrentGameState.Update();
    }

    public void Dispose()
    {
        _disposable?.Dispose();
    }
}
