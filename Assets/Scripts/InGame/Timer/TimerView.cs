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
    /// �J�E���g�_�E����ݒ�
    /// </summary>
    /// <param name="countDown"></param>
    public void SetCountDownText(float countDown)
    {
        _countDownTMP.text = countDown.ToString("0");
    }

    /// <summary>
    /// �^�C�}�[��ݒ�
    /// </summary>
    /// <param name="timer"></param>
    public void SetTimerText(float timer)
    {
        _timerTMP.text = timer.ToString("0");
    }
}
