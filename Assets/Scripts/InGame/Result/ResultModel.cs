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
    /// ƒ|ƒCƒ“ƒg‚Ì‚‚¢‡‚ÅUserData‚ğæ“¾
    /// </summary>
    /// <returns></returns>
    public List<UserData> GetRankingUserData()
    {
        return _gameStorage.UserDataList.OrderByDescending(data => data.Score).ToList();
    }
}
