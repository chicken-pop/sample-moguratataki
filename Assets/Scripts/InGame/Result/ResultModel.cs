using System.Collections.Generic;
using System.Linq;

public class ResultModel
{
    private GameStorage _gameStorage;

    public ResultModel()
    {
        _gameStorage = GameStore.Instance.SaveDataStore.CurrentGameStorage;
    }

    /// <summary>
    /// ポイントの高い順でUserDataを取得
    /// </summary>
    /// <returns></returns>
    public List<UserData> GetRankingUserData()
    {
        return _gameStorage.UserDataList.OrderByDescending(data => data.Score).ToList();
    }
}
