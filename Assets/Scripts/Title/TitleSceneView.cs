using TMPro;
using UnityEngine;

public class TitleSceneView : MonoBehaviour
{
    [Header("テキスト")]
    [SerializeField]
    private TextMeshProUGUI _userNameTMP;
    public TextMeshProUGUI UserNameTMP => _userNameTMP;
    [SerializeField]
    private TextMeshProUGUI _alertTMP;

    [Header("ボタン")]
    [SerializeField]
    private ButtonView _startButton;
    public ButtonView StartButton => _startButton;

    /// <summary>
    /// タイトルのView初期化
    /// </summary>
    public void Initialize()
    {
        _userNameTMP.text = string.Empty;
        _alertTMP.gameObject.SetActive(false);
    }

    /// <summary>
    /// ユーザー名をStringで返す
    /// </summary>
    /// <returns></returns>
    public string GetUserNameString()
    {
        return _userNameTMP.text;
    }

    /// <summary>
    /// アラートの表示
    /// </summary>
    public void DisplayAlert()
    {
        _alertTMP.gameObject.SetActive(true);
    }
}
