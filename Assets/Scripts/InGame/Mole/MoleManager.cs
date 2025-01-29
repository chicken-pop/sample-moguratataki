using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using Utility;

public class MoleManager : MonoBehaviour
{
    private int _rows = 3;
    private int _cols = 3;
    private int _cellWidth = 70;
    private int _cellHeight = 70;
    private int _cellSpacing = 20;

    [SerializeField]
    private GameObject _cellPrefab;
    [SerializeField]
    private RectTransform _cellRectTransform;

    private CellPresenter[,] _cellPresenters;
    public CellPresenter[,] CellPresenter => _cellPresenters;

    /// <summary>
    /// �Z������̏�����
    /// </summary>
    public void Initialize()
    {
        _cellPresenters = new CellPresenter[_rows, _cols];

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                CellModel model = new CellModel();

                GameObject cellObj = Instantiate(_cellPrefab, _cellRectTransform);
                RectTransform rectTransform = cellObj.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(i * (_cellWidth + _cellSpacing), -j * (_cellHeight + _cellSpacing));

                CellView view = cellObj.GetComponent<CellView>();

                _cellPresenters[i, j] = new CellPresenter(model, view);
            }
        }

        CenterGrid();
    }

    /// <summary>
    /// �Z���̈ʒu�𒆉��ɏC��
    /// </summary>
    private void CenterGrid()
    {
        float totalWidth = _cols * _cellWidth + (_cols - 1) * _cellSpacing;
        float totalHeight = _rows * _cellHeight + (_rows - 1) * _cellSpacing;

        _cellRectTransform.anchoredPosition = new Vector2(-(totalWidth - _cellWidth) / 2, (totalHeight - _cellHeight) / 2);
    }

    /// <summary>
    /// �Z���̃X�e�[�g�������_���ɍX�V
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async UniTask RandomlyUpdateCells(CancellationToken token)
    {
        try
        {
            while (true)
            {
                // �����_������
                float randomInterval = UnityEngine.Random.Range(1f, 2f);
                await UniTask.Delay(TimeSpan.FromSeconds(randomInterval));

                // �����_���ȃZ����I��
                int randomRow = UnityEngine.Random.Range(0, _rows);
                int randomCol = UnityEngine.Random.Range(0, _cols);

                // �����_���ȏ�Ԃ�ݒ�
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

                // ��莞�Ԍ�Ɍ��ɖ߂�
                await UniTask.Delay(TimeSpan.FromSeconds(1f));

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
