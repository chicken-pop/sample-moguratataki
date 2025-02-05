using Cysharp.Threading.Tasks;
using GameState;
using System;
using UniRx;

public class InGamePresenter : PresenterBase
{
    private InGameModel _inGameModel;

    private TimerPresenter _timerPresenter;
    public TimerPresenter TimerPresenter => _timerPresenter;

    private ScorePresenter _scorePresenter;
    public ScorePresenter ScorePresenter => _scorePresenter;

    private ResultPresenter _resultPresenter;
    public ResultPresenter ResultPresenter => _resultPresenter;

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

    public InGamePresenter(
        InGameModel model,
        TimerPresenter timerPresenter,
        ScorePresenter scorePresenter,
        ResultPresenter resultPresenter,
        MoleManager moleManager)
    {
        _inGameModel = model;
        _timerPresenter = timerPresenter;
        _scorePresenter = scorePresenter;
        _resultPresenter = resultPresenter;
        _moleManager = moleManager;

        _inGameStateMachine = new InGameStateMachine();

        _inGameInitState = new InGameInitState(this, _inGameStateMachine);
        _inGameStartState = new InGameStartState(this, _inGameStateMachine);
        _inGameMainState = new InGameMainState(this, _inGameStateMachine);
        _inGameResultState = new InGameResultState(this, _inGameStateMachine);
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
            .AddTo(Disposable);

        _timerPresenter.EndGameObservable
            .Subscribe(_ =>
            {
                // ResultStateへ
                _inGameStateMachine.ChangeState(_inGameResultState);
            })
            .AddTo(Disposable);

        _resultPresenter.RetryButtonObservable
            .Subscribe(_ =>
            {
                // StartStateへ
                _inGameStateMachine.ChangeState(_inGameStartState);
            })
            .AddTo(Disposable);

        _resultPresenter.TitleButtonObservable
            .Subscribe(async _ =>
            {
                InGameManager.Instance.Dispose();
                // タイトルに戻る
                await LoadSceneManager.Instance.LoadSceneAsync(ConstantData.TITLE_SCENE);
            })
            .AddTo(Disposable);
    }

    public void ManualUpdate()
    {
        _inGameStateMachine.CurrentGameState.Update();
    }

    public void SaveGameStorageData()
    {
        _inGameModel.SaveGameStorageData();
    }
}
