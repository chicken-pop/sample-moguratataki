using TMPro;
using UnityEngine;

public class SampleView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreTMP;
    [SerializeField]
    private TextMeshProUGUI _countDownTMP;

    public void SetScoreText(int value)
    {
        _scoreTMP.text = $"スコア：{value}";
    }

    public void SetCountDownText(int value)
    {
        _countDownTMP.text = $"カウントダウン：{value}";
    }
}
