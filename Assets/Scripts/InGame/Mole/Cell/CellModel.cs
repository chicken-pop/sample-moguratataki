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

    public void SetState(CellState newState)
    {
        _currentCellState.Value = newState;
    }

    public void SetPressValue(bool isPress)
    {
        _isPressed = isPress;
    }

    public void SetBonusState()
    {
        _isPressed = true;

        if (_currentCellState.Value == CellState.Slime)
        {
            _currentCellState.Value = CellState.SlimeBonus;
        }
        else if (_currentCellState.Value == CellState.Ghost)
        {
            _currentCellState.Value = CellState.GhostBonus;
        }
        else if (_currentCellState.Value == CellState.Princess)
        {
            _currentCellState.Value = CellState.PrincessPenalty;
        }
    }

    public void AddScore(int count)
    {
        _gameStorage.AddScoreCount(count);
    }

    public void SubtractScore(int count)
    {
        _gameStorage.SubtractScoreCount(count);
    }
}

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