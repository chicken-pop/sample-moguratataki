using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStorage
{
    [SerializeField]
    private List<UserData> _userDatList;
    public List<UserData> UserDataList => _userDatList;

    private string _currentUserName;
    public string CurrentUserName => _currentUserName;

    public GameStorage(List<UserData> userDataList = null)
    {
        _userDatList = userDataList ?? new List<UserData>();
    }

    public void SetCurrentUserName(string userName)
    {
        _currentUserName = userName;
    }

    public void SetScore(int score)
    {
        UserData userData = _userDatList.Where(userData => userData.UserName == _currentUserName).ToList().FirstOrDefault();

        if (userData != null)
        {
            userData.Score = score;
        }
    }

    public void AddScoreCount(int count)
    {
        UserData userData = _userDatList.Where(userData => userData.UserName == _currentUserName).ToList().FirstOrDefault();

        if (userData != null)
        {
            userData.Score += count;
        }
    }

    public void SubtractScoreCount(int count)
    {
        UserData userData = _userDatList.Where(userData => userData.UserName == _currentUserName).ToList().FirstOrDefault();

        if (userData != null)
        {
            userData.Score -= count;
        }
    }

    /// <summary>
    /// ユーザーデータの保存
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="score"></param>
    public void SetUserData(string userName, int score)
    {
        _userDatList.Add(new UserData(userName, score));
    }

    /// <summary>
    /// ゲームデータ全体をシリアライズ可能な状態で取得
    /// </summary>
    /// <returns></returns>
    public string GetGameStorageStrJson()
    {
        return JsonUtility.ToJson(this);
    }
}
