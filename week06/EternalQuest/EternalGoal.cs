public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) {}

    // Never complete
    public override bool IsComplete => false;

    public override int RecordEvent()
    {
        return Points; // award every time
    }

    public override string GetStringRepresentation()
    {
        // Type|Name|Description|Points
        return $"Eternal|{Name}|{Description}|{Points}";
    }
}
