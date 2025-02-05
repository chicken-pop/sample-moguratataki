using System.Collections.Generic;
using UnityEngine;
using Utility;

public class InGameManager : SingletonMonoBehaviour<InGameManager>
{
    [SerializeField]
    private MoleManager _moleManager;

    // Presenter
    private InGamePresenter _gamePresenter;
    private TimerPresenter _timerPresenter;
    private ScorePresenter _scorePresenter;
    private ResultPresenter _resultPresenter;

    // Model
    private InGameModel _gameModel;
    private TimerModel _timerModel;
    private ScoreModel _scoreModel;
    private ResultModel _resultModel;

    // View
    [SerializeField]
    private TimerView _timerView;
    [SerializeField]
    private ScoreView _scoreView;
    [SerializeField]
    private ResultView _resultView;

    public override void Awake()
    {
        _isSceneSingleton = true;

        // ゲームデータの初期化
        GameStore.Instance.Initialize();
        if (GameStore.Instance.SaveDataStore.SaveDataRepository.HasSaveData())
        {
            GameStore.Instance.SaveDataStore.LoadGameStorage();
        }

        Initialize();
    }

    private void Update()
    {
        _gamePresenter.ManualUpdate();
    }

    /// <summary>
    /// 各MVPの初期化
    /// </summary>
    private void Initialize()
    {
        _timerModel = new TimerModel();
        _timerPresenter = new TimerPresenter(ref _timerModel, _timerView);

        _scoreModel = new ScoreModel();
        _scorePresenter = new ScorePresenter(_scoreModel, _scoreView);

        _resultModel = new ResultModel();
        _resultPresenter = new ResultPresenter(_resultModel, _resultView);

        _gameModel = new InGameModel();
        _gamePresenter = new InGamePresenter(_gameModel, _timerPresenter, _scorePresenter, _resultPresenter, _moleManager);

        _gamePresenter.Initialize();
    }

    public void Dispose()
    {
        _timerPresenter.Dispose();
        _scorePresenter.Dispose();
        _resultPresenter.Dispose();
        _gamePresenter.Dispose();
    }

    void OnEnable()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
#else
        Application.quitting += OnApplicationQuit;
#endif
    }

    void OnDisable()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
#else
        Application.quitting -= OnApplicationQuit;
#endif
    }

    void OnApplicationQuit()
    {
        Dispose();
        DebugUtility.Log("アプリケーションが終了しました。");
    }

#if UNITY_EDITOR
    private void OnPlayModeStateChanged(UnityEditor.PlayModeStateChange state)
    {
        if (state == UnityEditor.PlayModeStateChange.ExitingPlayMode)
        {
            Dispose();
            DebugUtility.Log("エディタで再生モードが終了しました。");
        }
    }
#endif
}
