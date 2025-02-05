using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultView : MonoBehaviour
{
    [SerializeField]
    private GameObject _rankingPanel;

    [Header("Ranking")]
    [SerializeField]
    private TextMeshProUGUI[] _nameTMP;
    [SerializeField]
    private TextMeshProUGUI[] _scoreTMP;

    [Header("Button")]
    [SerializeField]
    private ButtonView _retryButton;
    public ButtonView RetryButton => _retryButton;
    [SerializeField]
    private ButtonView _titleButton;
    public ButtonView TitleButton => _titleButton;

    public void Setup()
    {
        _rankingPanel.SetActive(false);
        SetButton(false);
    }

    /// <summary>
    /// ƒ‰ƒ“ƒLƒ“ƒO‚ğİ’è
    /// </summary>
    /// <param name="userData"></param>
    public void SetRanking(List<UserData> userData)
    {
        _rankingPanel.SetActive(true);

        for (int i = 0; i < ConstantData.RANKING_COUNT; i++)
        {
            if (i < userData.Count && userData[i] != null)
            {
                _nameTMP[i].text = userData[i].UserName;
                _scoreTMP[i].text = userData[i].Score.ToString();
            }
            else
            {
                _nameTMP[i].text = "???";
                _scoreTMP[i].text = "???";
            }
        }
    }

    public void SetButton(bool isActive)
    {
        _retryButton.gameObject.SetActive(isActive);
        _titleButton.gameObject.SetActive(isActive);
    }
}
