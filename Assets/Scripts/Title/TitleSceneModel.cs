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
    /// ユーザー名が入力されているかどうか
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public bool HasUserName(string userName)
    {
        // 初期化で空にしてもLengthが１文字判定になるため、一旦２にしておく
        return userName.Length >= 2;
        /*
        if (userName.Length >= 1)
        {
            return true;
        }

        return false;

        // こんな書き方、みなさんしていませんか？
        */
    }

    /// <summary>
    /// ユーザーデータの作成
    /// </summary>
    /// <param name="userName"></param>
    public void CreateUserData(string userName)
    {
        // ゲーム前のスコアは0として作成
        _gameStorage.SetUserData(userName, 0);
    }

    /// <summary>
    /// ゲームシーンの遷移
    /// </summary>
    /// <returns></returns>
    public async UniTask LoadSceneAsync()
    {
        // シーン遷移前にリソースを解放
        Dispose();

        await LoadSceneManager.Instance.LoadSceneAsync(ConstantData.INGAME_SCENE);
    }

    private void Dispose()
    {
        _disposable?.Dispose();
    }
}
