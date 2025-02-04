public class InGameModel : ModelBase
{
    private GameStorage _gameStorage;

    public InGameModel()
    {
        _gameStorage = GameStore.Instance.SaveDataStore.CurrentGameStorage; ;
    }

    /// <summary>
    /// ゲームデータを保存
    /// </summary>
    public void SaveGameStorageData()
    {
        // 前の自分のスコアよりもよかった場合セーブ
        if (_gameStorage.IsScoreUpdate())
        {
            GameStore.Instance.SaveDataStore.SaveDataRepository.SaveGameStorageData(_gameStorage);
        }       
    }
}
