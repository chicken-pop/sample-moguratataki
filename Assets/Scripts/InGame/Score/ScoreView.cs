using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreTMP;

    /// <summary>
    /// スコアの表示
    /// </summary>
    /// <param name="score"></param>
    public void SetScore(int score)
    {
        _scoreTMP.text = score.ToString();
    }
}
