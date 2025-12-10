using System;

public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance (km) = laps * 50 / 1000
        // Distance (miles) = km * 0.62
        double distanceKm = _laps * 50.0 / 1000.0;
        double distanceMiles = distanceKm * 0.62;
        return distanceMiles;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        return (distance / LengthInMinutes) * 60.0;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return LengthInMinutes / distance;
    }
}
