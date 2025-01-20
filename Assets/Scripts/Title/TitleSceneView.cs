using TMPro;
using UnityEngine;

public class TitleSceneView : MonoBehaviour
{
    [Header("�e�L�X�g")]
    [SerializeField]
    private TextMeshProUGUI _userNameTMP;
    public TextMeshProUGUI UserNameTMP => _userNameTMP;
    [SerializeField]
    private TextMeshProUGUI _alertTMP;

    [Header("�{�^��")]
    [SerializeField]
    private ButtonView _startButton;
    public ButtonView StartButton => _startButton;

    /// <summary>
    /// �^�C�g����View������
    /// </summary>
    public void Initialize()
    {
        _userNameTMP.text = string.Empty;
        _alertTMP.gameObject.SetActive(false);
    }

    /// <summary>
    /// ���[�U�[����String�ŕԂ�
    /// </summary>
    /// <returns></returns>
    public string GetUserNameString()
    {
        return _userNameTMP.text;
    }

    /// <summary>
    /// �A���[�g�̕\��
    /// </summary>
    public void DisplayAlert()
    {
        _alertTMP.gameObject.SetActive(true);
    }
}
