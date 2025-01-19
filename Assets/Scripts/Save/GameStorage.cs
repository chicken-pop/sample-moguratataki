using System.Collections.Generic;
using UnityEngine;

public class GameStorage
{
    [SerializeField]
    private List<UserData> _userDatList;
    public List<UserData> UserDataList => _userDatList;

    public GameStorage(List<UserData> userDataList = null)
    {
        _userDatList = userDataList ?? new List<UserData>();
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
    /// �Q�[���f�[�^�S�̂��V���A���C�Y�\�ȏ�ԂŎ擾
    /// </summary>
    /// <returns></returns>
    public string GetGameStorageStrJson()
    {
        return JsonUtility.ToJson(this);
    }
}
