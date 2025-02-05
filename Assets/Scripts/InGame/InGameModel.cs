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
    /// �Q�[���f�[�^��ۑ�
    /// </summary>
    public void SaveGameStorageData()
    {
        // �O�̎����̃X�R�A�����悩�����ꍇ�Z�[�u
        if (_gameStorage.IsScoreUpdate())
        {
            _gameStorage.SetScore(_gameStorage.CurrentScoreRP.Value);
            _saveDataRepository.SaveGameStorageData(_gameStorage);
        }
    }
}
