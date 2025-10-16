public class Cycling : Activity
{
    private double _speed; // mph or kph, given

    public Cycling(System.DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        // distance = speed * (minutes/60)
        return _speed * (Minutes / 60.0);
    }

    public override double GetSpeed() => _speed;

    public override double GetPace()
    {
        // pace = 60 / speed
        return 60.0 / _speed;
    }
}
