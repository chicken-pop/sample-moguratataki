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

        // CancellationToken �ɂ��L�����Z�����Ď����A�V�[�����[�h��ҋ@
        while (!operation.isDone)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
        }

        // �V�[���̃��[�h��r���ŃL�����Z���������ꍇ�́A��L�̂悤�ȏ����ɂȂ�
        // ����͊m���Ƀ��[�h���������������̂ŁA�g�[�N����n���Ȃ��Ă����Ȃ�
        */
    }
}
