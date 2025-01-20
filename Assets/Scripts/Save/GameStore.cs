using Utility;

public class GameStore : SingletonMonoBehaviour<GameStore>
{
    public SaveDataStore SaveDataStore { get; private set; }

    /// <summary>
    /// �Q�[���J�n���ɃZ�[�u�f�[�^�V�X�e���̏��������s��
    /// </summary>
    public void Initialize()
    {
        SaveDataStore = new SaveDataStore();
    }
}
