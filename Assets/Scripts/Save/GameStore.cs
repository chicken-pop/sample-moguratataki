using Utility;

public class GameStore : SingletonMonoBehaviour<GameStore>
{
    public SaveDataStore SaveDataStore { get; private set; }

    public void Initialize()
    {
        SaveDataStore = new SaveDataStore();
    }
}
