using System;

public abstract class Activity
{
    private DateTime _date;   // e.g., 2025-10-16
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance(); // in your chosen unit (mi or km)
    public abstract double GetSpeed();    // mph or kph
    public abstract double GetPace();     // min/mi or min/km

    public virtual string GetSummary(string unitDistance, string unitSpeed, string unitPace)
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance():0.##} {unitDistance}, " +
               $"Speed {GetSpeed():0.##} {unitSpeed}, " +
               $"Pace: {GetPace():0.##} {unitPace}";
    }
}
