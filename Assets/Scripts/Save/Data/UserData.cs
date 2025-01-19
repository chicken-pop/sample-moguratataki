[System.Serializable]
public class UserData
{
    public string UserName;
    public int Score;

    public UserData(string userName, int score)
    {
        UserName = userName;
        Score = score;
    }

    public void SetScore(int score)
    {
        Score = score;
    }
}
