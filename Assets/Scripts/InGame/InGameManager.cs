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

    // Model
    private InGameModel _gameModel;
    private TimerModel _timerModel;

    // View
    [SerializeField]
    private InGameView _gameView;
    [SerializeField]
    private TimerView _timerView;

    private List<ModelBase> _modelBaseList;
    public List<ModelBase> ModelBaseList => _modelBaseList;

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
        _modelBaseList = new List<ModelBase>();

        _timerModel = new TimerModel();
        _timerPresenter = new TimerPresenter(ref _timerModel, _timerView);
        _modelBaseList.Add(_timerModel);

        _gameModel = new InGameModel();
        _gamePresenter = new InGamePresenter(_gameModel, _gameView, _timerPresenter, _moleManager);
        _modelBaseList.Add(_gameModel);

        _gamePresenter.Initialize();
    }

    public void Dispose()
    {
        foreach (var model in ModelBaseList)
        {
            model.Dispose();
        }

        _gamePresenter.Dispose();

        foreach (var presenter in _moleManager.CellPresenter)
        {
            presenter.Dispose();
        }
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
