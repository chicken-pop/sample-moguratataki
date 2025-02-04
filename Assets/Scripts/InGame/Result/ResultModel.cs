using System.Collections.Generic;
using System.Linq;

public class ResultModel : ModelBase
{
    private GameStorage _gameStorage;

    public ResultModel()
    {
        _gameStorage = GameStore.Instance.SaveDataStore.CurrentGameStorage;
    }

    public List<UserData> GetRankingUserData()
    {
        return _gameStorage.UserDataList.OrderByDescending(data => data.Score).ToList();
    }
}
