public class Running : Activity
{
    private double _distance; // in chosen unit (mi or km)

    public Running(System.DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed()
    {
        // speed = (distance / minutes) * 60
        return (_distance / Minutes) * 60.0;
    }

    public override double GetPace()
    {
        // pace = minutes / distance
        return Minutes / _distance;
    }
}
