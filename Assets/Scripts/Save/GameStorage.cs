using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class GameStorage
{
    [SerializeField]
    private List<UserData> _userDatList;
    public List<UserData> UserDataList => _userDatList;

    [SerializeField]
    private string _currentUserName;
    public string CurrentUserName => _currentUserName;

    [SerializeField]
    private ReactiveProperty<int> _currentScoreRP;
    public IReadOnlyReactiveProperty<int> CurrentScoreRP => _currentScoreRP;

    public GameStorage(List<UserData> userDataList = null)
    {
        _userDatList = userDataList ?? new List<UserData>();
        _currentScoreRP = new ReactiveProperty<int>(0);
    }

    public void SetupCurrentScore(int score)
    {
        _currentScoreRP.Value = score;
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
            _currentScoreRP.Value += count;
        }
    }

    public void SubtractScoreCount(int count)
    {
        UserData userData = _userDatList.Where(userData => userData.UserName == _currentUserName).ToList().FirstOrDefault();

        if (userData != null)
        {
            userData.Score -= count;
            _currentScoreRP.Value -= count;
        }
    }

    public bool IsScoreUpdate()
    {
        UserData userData = _userDatList.Where(userData => userData.UserName == _currentUserName).ToList().FirstOrDefault();

        return userData.Score <= _currentScoreRP.Value;
    }

    /// <summary>
    /// ���[�U�[�f�[�^�̕ۑ�
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="score"></param>
    public void SetUserData(string userName, int score)
    {
        _userDatList.Add(new UserData(userName, score));
    }

    /// <summary>
    /// ���݂̃��[�U�[����ۑ�
    /// </summary>
    /// <param name="userName"></param>
    public void SetCurrentUserName(string userName)
    {
        _currentUserName = userName;
    }

    /// <summary>
    /// �Q�[���f�[�^�S�̂��V���A���C�Y�\�ȏ�ԂŎ擾
    /// </summary>
    /// <returns></returns>
    public string GetGameStorageStrJson()
    {
        return JsonUtility.ToJson(this);
    }
}
