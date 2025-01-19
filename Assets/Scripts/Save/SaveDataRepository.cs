using UnityEngine;

public class SaveDataRepository
{
    private const string C_GAME_STORAGE_DATA_SAVE_KEY_NAME = "GameStorageData";�@// �Z�[�u�f�[�^�𕡐���肽���ꍇ�́AKey�𕡐��쐬

    /// <summary>
    /// �Q�[���X�g���[�W�̏����l���擾
    /// </summary>
    /// <returns></returns>
    public GameStorage GetInitGameStorageData()
    {
        GameStorage gameStorage = new GameStorage();
        return gameStorage;
    }

    /// <summary>
    /// �Q�[���X�g���[�W�̃f�[�^��ۑ�
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
