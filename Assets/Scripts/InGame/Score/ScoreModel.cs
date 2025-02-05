public class ScoreModel
{
    private GameStorage _gameStorage;
    public GameStorage GameStorage => _gameStorage;

    public ScoreModel()
    {
        _gameStorage = GameStore.Instance.SaveDataStore.CurrentGameStorage;
    }
}
