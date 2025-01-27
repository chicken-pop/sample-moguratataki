using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _countDownTMP;

    [SerializeField]
    private TextMeshProUGUI _timerTMP;

    public void IsCountDownTextActive(bool isActive) => _countDownTMP.gameObject.SetActive(isActive);

    /// <summary>
    /// カウントダウンを設定
    /// </summary>
    /// <param name="countDown"></param>
    public void SetCountDownText(float countDown)
    {
        _countDownTMP.text = countDown.ToString("0");
    }

    /// <summary>
    /// タイマーを設定
    /// </summary>
    /// <param name="timer"></param>
    public void SetTimerText(float timer)
    {
        _timerTMP.text = timer.ToString("0");
    }
}
