using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _countDownTMP;

    [SerializeField]
    private TextMeshProUGUI _timerTMP;

    public void SetCountDownText(float countDown)
    {
        _countDownTMP.text = countDown.ToString("0");
    }

    public void SetTimerText(float timer)
    {
        _timerTMP.text = timer.ToString("0");
    }
}
