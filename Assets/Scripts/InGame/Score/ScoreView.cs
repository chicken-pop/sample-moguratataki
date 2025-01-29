using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreTMP;

    /// <summary>
    /// �X�R�A�̕\��
    /// </summary>
    /// <param name="score"></param>
    public void SetScore(int score)
    {
        _scoreTMP.text = score.ToString();
    }
}
