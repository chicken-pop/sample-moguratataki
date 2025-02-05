public class InGameModel
{
    private GameStorage _gameStorage;
    private SaveDataRepository _saveDataRepository;

    public InGameModel()
    {
        _gameStorage = GameStore.Instance.SaveDataStore.CurrentGameStorage;
        _saveDataRepository = GameStore.Instance.SaveDataStore.SaveDataRepository;
    }

    /// <summary>
    /// ゲームデータを保存
    /// </summary>
    public void SaveGameStorageData()
    {
        // 前の自分のスコアよりもよかった場合セーブ
        if (_gameStorage.IsScoreUpdate())
        {
            _gameStorage.SetScore(_gameStorage.CurrentScoreRP.Value);
            _saveDataRepository.SaveGameStorageData(_gameStorage);
        }
    }
}
