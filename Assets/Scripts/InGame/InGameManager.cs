using System.Collections.Generic;
using UnityEngine;
using Utility;

public class InGameManager : SingletonMonoBehaviour<InGameManager>
{
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
        Initialize();
    }

    private void Update()
    {
        _gamePresenter.ManualUpdate();
    }

    private void Initialize()
    {
        _modelBaseList = new List<ModelBase>();

        _timerModel = new TimerModel();
        _modelBaseList.Add(_timerModel);
        _timerPresenter = new TimerPresenter(ref _timerModel, _timerView);

        _gameModel = new InGameModel();
        _modelBaseList.Add(_gameModel);
        _gamePresenter = new InGamePresenter(_gameModel, _gameView, _timerPresenter);

        _gamePresenter.Initialize();
    }

    public void Dispose()
    {
        foreach (var model in ModelBaseList)
        {
            model.Dispose();
        }

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
