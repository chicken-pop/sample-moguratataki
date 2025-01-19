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
    /// �Q�[���X�g���[�W�̏���������
    /// </summary>
    private void InitializeGameStorageData()
    {
        _currentGameStorage = _saveDataRepository.GetInitGameStorageData();
    }

    /// <summary>
    /// �Q�[���X�g���[�W��ۑ�
    /// </summary>
    /// <param name="gameStorage"></param>
    public void SaveGameStorage(GameStorage gameStorage)
    {
        _saveDataRepository.SaveGameStorageData(gameStorage);
    }

    /// <summary>
    /// �Q�[���X�g���[�W��ǂݍ���
    /// </summary>
    public void LoadGameStorage()
    {
        _currentGameStorage = _saveDataRepository.FetchGameStorageData();
    }
}
