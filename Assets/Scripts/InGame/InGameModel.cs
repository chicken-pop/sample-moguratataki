public class InGameModel : ModelBase
{
    private GameStorage _gameStorage;

    public InGameModel()
    {
        _gameStorage = GameStore.Instance.SaveDataStore.CurrentGameStorage; ;
    }

    /// <summary>
    /// �Q�[���f�[�^��ۑ�
    /// </summary>
    public void SaveGameStorageData()
    {
        // �O�̎����̃X�R�A�����悩�����ꍇ�Z�[�u
        if (_gameStorage.IsScoreUpdate())
        {
            GameStore.Instance.SaveDataStore.SaveDataRepository.SaveGameStorageData(_gameStorage);
        }       
    }
}
