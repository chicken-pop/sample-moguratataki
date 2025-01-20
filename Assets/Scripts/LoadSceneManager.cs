using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Utility;

public class LoadSceneManager : SingletonMonoBehaviour<LoadSceneManager>
{
    public async UniTask LoadSceneAsync(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName);
        /*
        var operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        // CancellationToken によるキャンセルを監視しつつ、シーンロードを待機
        while (!operation.isDone)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
        }

        // シーンのロードを途中でキャンセルしたい場合は、上記のような処理になる
        // 今回は確実にロードを完了させたいので、トークンを渡さなくても問題なし
        */
    }
}
