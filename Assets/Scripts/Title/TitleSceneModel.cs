using Cysharp.Threading.Tasks;
using UniRx;
using Utility;

public class TitleSceneModel
{
    private GameStorage _gameStorage;
    public GameStorage GameStorage => _gameStorage;
    private CompositeDisposable _disposable;
    public CompositeDisposable Disposable => _disposable;

    public TitleSceneModel()
    {
        _gameStorage = GameStore.Instance.SaveDataStore.CurrentGameStorage;
        _disposable = new CompositeDisposable();
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
        Dispose();

        await LoadSceneManager.Instance.LoadSceneAsync(ConstantData.INGAME_SCENE);
    }

    private void Dispose()
    {
        _disposable?.Dispose();
    }
}
