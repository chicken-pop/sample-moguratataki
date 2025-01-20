using Utility;

public class GameStore : SingletonMonoBehaviour<GameStore>
{
    public SaveDataStore SaveDataStore { get; private set; }

    /// <summary>
    /// ゲーム開始時にセーブデータシステムの初期化を行う
    /// </summary>
    public void Initialize()
    {
        SaveDataStore = new SaveDataStore();
    }
}
