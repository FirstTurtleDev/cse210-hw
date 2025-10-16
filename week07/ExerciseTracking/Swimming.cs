public class Swimming : Activity
{
    private int _laps; // each lap is 50 meters

    // Set useMiles = true for miles, false for km
    private readonly bool _useMiles;

    public Swimming(System.DateTime date, int minutes, int laps, bool useMiles)
        : base(date, minutes)
    {
        _laps = laps;
        _useMiles = useMiles;
    }

    public override double GetDistance()
    {
        // km = laps * 50 / 1000; miles = km * 0.62
        double km = _laps * 50.0 / 1000.0;
        return _useMiles ? km * 0.62 : km;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60.0;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}
