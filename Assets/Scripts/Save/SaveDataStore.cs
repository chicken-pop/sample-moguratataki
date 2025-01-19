public class SaveDataStore
{
    private SaveDataRepository _saveDataRepository;
    private GameStorage _currentGameStorage;
    public GameStorage CurrentGameStorage => _currentGameStorage;

    public SaveDataStore()
    {
        _saveDataRepository = new SaveDataRepository();
        InitializeGameStorageData();
    }

    /// <summary>
    /// ゲームストレージの初期化処理
    /// </summary>
    private void InitializeGameStorageData()
    {
        _currentGameStorage = _saveDataRepository.GetInitGameStorageData();
    }

    /// <summary>
    /// ゲームストレージを保存
    /// </summary>
    /// <param name="gameStorage"></param>
    public void SaveGameStorage(GameStorage gameStorage)
    {
        _saveDataRepository.SaveGameStorageData(gameStorage);
    }

    /// <summary>
    /// ゲームストレージを読み込み
    /// </summary>
    public void LoadGameStorage()
    {
        _currentGameStorage = _saveDataRepository.FetchGameStorageData();
    }
}
