using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Utility;

public class MoleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _cellPrefab;
    [SerializeField]
    private RectTransform _cellRectTransform;

    private CellPresenter[,] _cellPresenters;
    public CellPresenter[,] CellPresenter => _cellPresenters;

    [SerializeField]
    private List<CellView> _cellList;

    /// <summary>
    /// セル周りの初期化
    /// </summary>
    public void Initialize()
    {
        _cellPresenters = new CellPresenter[ConstantData.ROWS, ConstantData.COLS];
        _cellList = new List<CellView>();

        for (int i = 0; i < ConstantData.ROWS; i++)
        {
            for (int j = 0; j < ConstantData.COLS; j++)
            {
                CellModel model = new CellModel();

                GameObject cellObj = Instantiate(_cellPrefab, _cellRectTransform);
                RectTransform rectTransform = cellObj.GetComponent<RectTransform>();
                rectTransform.anchoredPosition =
                    new Vector2(i * (ConstantData.CELL_WHDTH + ConstantData.CELL_SPACING), -j * (ConstantData.CELL_HEIGHT + ConstantData.CELL_SPACING));

                CellView view = cellObj.GetComponent<CellView>();
                _cellPresenters[i, j] = new CellPresenter(model, view);

                _cellList.Add(view);
                view.gameObject.SetActive(false);
            }
        }

        CenterGrid();
    }

    /// <summary>
    /// セルの位置を中央に修正
    /// </summary>
    private void CenterGrid()
    {
        float totalWidth = ConstantData.ROWS * ConstantData.CELL_WHDTH + (ConstantData.ROWS - 1) * ConstantData.CELL_SPACING;
        float totalHeight = ConstantData.COLS * ConstantData.CELL_HEIGHT + (ConstantData.COLS - 1) * ConstantData.CELL_SPACING;

        _cellRectTransform.anchoredPosition
            = new Vector2(-(totalWidth - ConstantData.CELL_WHDTH) / 2, (totalHeight - ConstantData.CELL_HEIGHT) / 2);
    }

    public void SetCellObjects(bool isActive)
    {
        for (int i = 0; i < _cellList.Count; i++)
        {
            _cellList[i].gameObject.SetActive(isActive);
        }
    }

    /// <summary>
    /// セルのステートをランダムに更新
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async UniTask RandomlyUpdateCells(CancellationToken token)
    {
        try
        {
            while (true)
            {
                // ランダム周期
                float randomInterval = UnityEngine.Random.Range(1f, 2f);
                await UniTask.Delay(TimeSpan.FromSeconds(randomInterval));

                // ランダムなセルを選択
                int randomRow = UnityEngine.Random.Range(0, ConstantData.ROWS);
                int randomCol = UnityEngine.Random.Range(0, ConstantData.COLS);

                // ランダムな状態を設定
                CellState randomState;
                float randomValue = UnityEngine.Random.Range(0f, 1f);
                if (randomValue <= 0.3)
                {
                    randomState = CellState.Slime;
                }
                else if (randomValue <= 0.6)
                {
                    randomState = CellState.Ghost;
                }
                else
                {
                    randomState = CellState.Princess;
                }
                _cellPresenters[randomRow, randomCol].SetState(randomState);

                // 一定時間後に元に戻す
                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);

                if (_cellPresenters[randomRow, randomCol].Model.IsPressed)
                {
                    continue;
                }

                _cellPresenters[randomRow, randomCol].SetState(CellState.None);
            }
        }
        catch (OperationCanceledException)
        {
            DebugUtility.Log("Canceled successfully");
        }
        catch (Exception e)
        {
            DebugUtility.LogError(e);
        }
    }
}
