using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class CellView : ButtonView
{
    [Header("Character")]
    [SerializeField]
    private Image _characterImage;
    [SerializeField]
    private Sprite _slimeSprite;
    [SerializeField]
    private Sprite _ghostSprite;
    [SerializeField]
    private Sprite _princessSprite;

    [Header("Point")]
    [SerializeField]
    private Image _pointImage;
    [SerializeField]
    private Sprite _slimePoint;
    [SerializeField]
    private Sprite _ghostPoint;
    [SerializeField]
    private Sprite _princessPoint;

    /// <summary>
    /// キャラクター画像の設定
    /// </summary>
    /// <param name="cellState"></param>
    public async UniTask 
        
        SetCharacterImage(CellState cellState, CancellationToken token)
    {
        try
        {
            switch (cellState)
            {
                case CellState.None:
                    _characterImage.gameObject.SetActive(false);
                    break;
                case CellState.Slime:
                    _characterImage.gameObject.SetActive(true);
                    _characterImage.sprite = _slimeSprite;
                    break;
                case CellState.Ghost:
                    _characterImage.gameObject.SetActive(true);
                    _characterImage.sprite = _ghostSprite;
                    break;
                case CellState.Princess:
                    _characterImage.gameObject.SetActive(true);
                    _characterImage.sprite = _princessSprite;
                    break;
                default:
                    await UniTask.Delay(TimeSpan.FromSeconds(1f));
                    _characterImage.gameObject.SetActive(false);
                    break;
            }
        }
        catch (OperationCanceledException)
        {
            DebugUtility.LogError("SetCharacterImage was cancelled.");
        }
        catch (Exception e)
        {
            DebugUtility.LogError(e);
        }
    }

    /// <summary>
    /// ポイント画像の設定
    /// </summary>
    /// <param name="cellState"></param>
    public async UniTask SetPointImage(CellState cellState, CancellationToken token)
    {
        try
        {
            switch (cellState)
            {
                case CellState.SlimeBonus:
                    _pointImage.gameObject.SetActive(true);
                    _pointImage.sprite = _slimePoint;
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                    _pointImage.gameObject.SetActive(false);
                    break;
                case CellState.GhostBonus:
                    _pointImage.sprite = _ghostPoint;
                    _pointImage.gameObject.SetActive(true);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                    _pointImage.gameObject.SetActive(false);
                    break;
                case CellState.PrincessPenalty:
                    _pointImage.gameObject.SetActive(true);
                    _pointImage.sprite = _princessPoint;
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                    _pointImage.gameObject.SetActive(false);
                    break;
                default:
                    _pointImage.gameObject.SetActive(false);
                    break;
            }
        }
        catch (OperationCanceledException)
        {
            DebugUtility.LogError("SetPointImage was cancelled.");
        }
        catch (Exception e)
        {
            DebugUtility.LogError(e);
        }
    }

    /// <summary>
    /// ボタンの設定
    /// </summary>
    /// <param name="cellState"></param>
    public void SetInteractable(CellState cellState)
    {
        switch (cellState)
        {
            case CellState.Slime:
                SetInteractable(true);
                break;
            case CellState.Ghost:
                SetInteractable(true);
                break;
            case CellState.Princess:
                SetInteractable(true);
                break;
            default:
                SetInteractable(false);
                break;
        }
    }
}
