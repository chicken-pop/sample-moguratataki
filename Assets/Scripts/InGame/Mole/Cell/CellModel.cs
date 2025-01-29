using UniRx;

public class CellModel
{
    private GameStorage _gameStorage;

    private bool _isPressed;
    public bool IsPressed => _isPressed;

    /// <summary>
    /// ���݂̃X�e�[�g
    /// </summary>
    private ReactiveProperty<CellState> _currentCellState;
    public IReadOnlyReactiveProperty<CellState> CurrentCellState => _currentCellState;

    public CellModel(CellState initState = CellState.None)
    {
        _gameStorage = GameStore.Instance.SaveDataStore.CurrentGameStorage;
        _currentCellState = new ReactiveProperty<CellState>(initState);
    }

    /// <summary>
    /// �Z���������ꂽ���ǂ���
    /// </summary>
    /// <param name="isPress"></param>
    public void SetPressValue(bool isPress)
    {
        _isPressed = isPress;
    }

    /// <summary>
    /// �X�e�[�g�̐ݒ�
    /// </summary>
    /// <param name="newState"></param>
    public void SetState(CellState newState)
    {
        _currentCellState.Value = newState;
    }

    /// <summary>
    /// �|�C���g���֗^����X�e�[�g�ɐݒ�
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
    /// �X�R�A�̉��Z
    /// </summary>
    /// <param name="count"></param>
    public void AddScore(int count)
    {
        _gameStorage.AddScoreCount(count);
    }

    /// <summary>
    /// �X�R�A�̌��Z
    /// </summary>
    /// <param name="count"></param>
    public void SubtractScore(int count)
    {
        _gameStorage.SubtractScoreCount(count);
    }
}

/// <summary>
/// �Z���̃X�e�[�g
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