public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override bool IsComplete => _currentCount >= _targetCount;

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                return Points + _bonus; // final hit gives bonus
            }
            return Points;
        }
        // already complete—no more points
        return 0;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        // Type|Name|Description|Points|Target|Bonus|Current
        return $"Checklist|{Name}|{Description}|{Points}|{_targetCount}|{_bonus}|{_currentCount}";
    }
}
