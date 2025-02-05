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
        _titleSceneModel = new TitleSceneModel();
        _titleScenePresenter = new TitleScenePresenter(_titleSceneModel, _titleSceneView);
    }

    public void Dispose()
    {
        _titleScenePresenter.Dispose();
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
