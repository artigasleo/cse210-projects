using System;

public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(DateTime date, int lengthInMinutes, double distanceMiles)
        : base(date, lengthInMinutes)
    {
        _distance = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / LengthInMinutes) * 60.0;
    }

    public override double GetPace()
    {
        return LengthInMinutes / _distance;
    }
}
