using Cysharp.Threading.Tasks;
using System.Linq;
using UniRx;
using Utility;

public class TitleScenePresenter
{
    private TitleSceneModel _model;
    private TitleSceneView _view;

    public TitleScenePresenter(TitleSceneModel model, TitleSceneView view)
    {
        _model = model;
        _view = view;

        _view.Initialize();

        SubscribeViewObservable();
    }

    private void SubscribeViewObservable()
    {
        _view.StartButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                if (!_model.HasUserName(_view.GetUserNameString()))
                {
                    _view.DisplayAlert();
                    return;
                }

                _model.CreateUserData(_view.GetUserNameString());
                DebugUtility.Log(_model.GameStorage.UserDataList.Last().UserName);
                DebugUtility.Log(_model.GameStorage.UserDataList.Last().Score);
                _model.LoadSceneAsync().Forget();
            })
            .AddTo(_model.Disposable);
    }
}
