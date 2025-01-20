using System.Collections.Generic;
using UnityEngine;
using Utility;

public class TitleSceneManager : SingletonMonoBehaviour<TitleSceneManager>
{
    // Presenter
    private TitleScenePresenter _titleScenePresenter;

    // Model
    private TitleSceneModel _titleSceneModel;

    // View
    [SerializeField]
    private TitleSceneView _titleSceneView;


    private List<ModelBase> _modelBaseList;
    public List<ModelBase> ModelBaseList => _modelBaseList;

    public override void Awake()
    {
        _isSceneSingleton = true;

        GameStore.Instance.Initialize();

        if (GameStore.Instance.SaveDataStore.SaveDataRepository.HasSaveData())
        {
            GameStore.Instance.SaveDataStore.LoadGameStorage();
        }

        Initialize();
    }

    private void Initialize()
    {
        _modelBaseList = new List<ModelBase>();

        _titleSceneModel = new TitleSceneModel();
        _modelBaseList.Add(_titleSceneModel);
        _titleScenePresenter = new TitleScenePresenter(ref _titleSceneModel, _titleSceneView);
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
