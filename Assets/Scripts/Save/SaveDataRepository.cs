using UnityEngine;

public class SaveDataRepository
{
    private const string C_GAME_STORAGE_DATA_SAVE_KEY_NAME = "GameStorageData";　// セーブデータを複数作りたい場合は、Keyを複数作成

    /// <summary>
    /// ゲームストレージの初期値を取得
    /// </summary>
    /// <returns></returns>
    public GameStorage GetInitGameStorageData()
    {
        GameStorage gameStorage = new GameStorage();
        return gameStorage;
    }

    /// <summary>
    /// ゲームストレージのデータを保存
    /// </summary>
    /// <param name="gameStorage"></param>
    public void SaveGameStorageData(GameStorage gameStorage)
    {
        string json = gameStorage.GetGameStorageStrJson();
        PlayerPrefs.SetString(C_GAME_STORAGE_DATA_SAVE_KEY_NAME, json);
        PlayerPrefs.Save();
    }

    public GameStorage FetchGameStorageData()
    {
        string jsonString = null;
        jsonString = PlayerPrefs.GetString(C_GAME_STORAGE_DATA_SAVE_KEY_NAME);
        GameStorage loadedGameStorage = JsonUtility.FromJson<GameStorage>(jsonString);

        return loadedGameStorage;

    }
}
