using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{
    private TitleScenePresenter _titleScenePresenter;

    [SerializeField]
    private TitleSceneView _titleSceneView;

    private void Awake()
    {
        GameStore.Instance.Initialize();

        if (GameStore.Instance.SaveDataStore.SaveDataRepository.HasSaveData())
        {
            GameStore.Instance.SaveDataStore.LoadGameStorage();
        }

        Initialize();
    }

    private void Initialize()
    {
        TitleSceneModel titleSceneModel = new TitleSceneModel();
        _titleScenePresenter = new TitleScenePresenter(titleSceneModel, _titleSceneView);
    }
}
