using UniRx;

public class CellModel
{
    private GameStorage _gameStorage;

    private bool _isPressed;
    public bool IsPressed => _isPressed;

    /// <summary>
    /// 現在のステート
    /// </summary>
    private ReactiveProperty<CellState> _currentCellState;
    public IReadOnlyReactiveProperty<CellState> CurrentCellState => _currentCellState;

    public CellModel(CellState initState = CellState.None)
    {
        _gameStorage = GameStore.Instance.SaveDataStore.CurrentGameStorage;
        _currentCellState = new ReactiveProperty<CellState>(initState);
    }

    /// <summary>
    /// セルが押されたかどうか
    /// </summary>
    /// <param name="isPress"></param>
    public void SetPressValue(bool isPress)
    {
        _isPressed = isPress;
    }

    /// <summary>
    /// ステートの設定
    /// </summary>
    /// <param name="newState"></param>
    public void SetState(CellState newState)
    {
        _currentCellState.Value = newState;
    }

    /// <summary>
    /// ポイントが関与するステートに設定
    /// </summary>
    public void SetBonusState()
    {
        _isPressed = true;

        if (_currentCellState.Value == CellState.Slime)
        {
            _currentCellState.Value = CellState.SlimeBonus;
            AddScore(ConstantData.SLIME_POINT);
        }
        else if (_currentCellState.Value == CellState.Ghost)
        {
            _currentCellState.Value = CellState.GhostBonus;
            AddScore(ConstantData.GHOST_POINT);
        }
        else if (_currentCellState.Value == CellState.Princess)
        {
            _currentCellState.Value = CellState.PrincessPenalty;
            SubtractScore(ConstantData.PRINCESS_POINT);
        }
    }

    /// <summary>
    /// スコアの加算
    /// </summary>
    /// <param name="count"></param>
    public void AddScore(int count)
    {
        _gameStorage.AddScoreCount(count);
    }

    /// <summary>
    /// スコアの減算
    /// </summary>
    /// <param name="count"></param>
    public void SubtractScore(int count)
    {
        _gameStorage.SubtractScoreCount(count);
    }
}

/// <summary>
/// セルのステート
/// </summary>
public enum CellState
{
    None,
    Slime,
    Ghost,
    Princess,
    SlimeBonus,
    GhostBonus,
    PrincessPenalty,
}