using Cysharp.Threading.Tasks;

public class TitleSceneModel : ModelBase
{
    private GameStorage _gameStorage;
    public GameStorage GameStorage => _gameStorage;

    public TitleSceneModel()
    {
        _gameStorage = GameStore.Instance.SaveDataStore.CurrentGameStorage;
    }

    /// <summary>
    /// ���[�U�[�������͂���Ă��邩�ǂ���
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public bool HasUserName(string userName)
    {
        // �������ŋ�ɂ��Ă�Length���P��������ɂȂ邽�߁A��U�Q�ɂ��Ă���
        return userName.Length >= 2;
        /*
        if (userName.Length >= 1)
        {
            return true;
        }

        return false;

        // ����ȏ������A�݂Ȃ��񂵂Ă��܂��񂩁H
        */
    }

    /// <summary>
    /// ���[�U�[�f�[�^�̍쐬
    /// </summary>
    /// <param name="userName"></param>
    public void CreateUserData(string userName)
    {
        // �Q�[���O�̃X�R�A��0�Ƃ��č쐬
        _gameStorage.SetUserData(userName, 0);
    }

    /// <summary>
    /// �Q�[���V�[���̑J��
    /// </summary>
    /// <returns></returns>
    public async UniTask LoadSceneAsync()
    {
        // �V�[���J�ڑO�Ƀ��\�[�X�����
        TitleSceneManager.Instance.Dispose();

        await LoadSceneManager.Instance.LoadSceneAsync(ConstantData.INGAME_SCENE);
    }
}
