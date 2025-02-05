using Cysharp.Threading.Tasks;
using UniRx;

public class TitleScenePresenter : PresenterBase
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
                _model.SaveGameStorageData();
                _model.LoadSceneAsync().Forget();
            })
            .AddTo(Disposable);
    }
}
