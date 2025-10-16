using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    // Whether the goal is considered complete (default: false; override if needed)
    public virtual bool IsComplete => false;

    // Called when the user records progress/completion. Returns points awarded.
    public abstract int RecordEvent();

    // Text for listing details in the UI.
    public virtual string GetDetailsString()
    {
        string status = IsComplete ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description})";
    }

    // String used for saving. Each derived class appends its own fields.
    public abstract string GetStringRepresentation();
}
