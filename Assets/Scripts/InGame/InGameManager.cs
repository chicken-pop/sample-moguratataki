using System.Collections.Generic;
using UnityEngine;
using Utility;

public class InGameManager : SingletonMonoBehaviour<InGameManager>
{
    // Presenter
    private TimerPresenter _timerPresenter;

    // Model
    private TimerModel _timerModel;

    // View
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
        // テスト
        _timerModel.CountDownManualUpdate();
        _timerModel.TimerManualUpdate();
    }

    private void Initialize()
    {
        _modelBaseList = new List<ModelBase>();

        _timerModel = new TimerModel();
        _modelBaseList.Add(_timerModel);
        _timerPresenter = new TimerPresenter(ref _timerModel, _timerView);
    }

    public void Dispose()
    {
        foreach (var model in ModelBaseList)
        {
            model.Dispose();
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
