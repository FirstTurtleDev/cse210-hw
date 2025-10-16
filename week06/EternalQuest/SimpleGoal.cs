public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete => _isComplete;

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return Points;
        }
        // No extra points after completion.
        return 0;
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString();
    }

    public override string GetStringRepresentation()
    {
        // Type|Name|Description|Points|IsComplete
        return $"Simple|{Name}|{Description}|{Points}|{_isComplete}";
    }
}
