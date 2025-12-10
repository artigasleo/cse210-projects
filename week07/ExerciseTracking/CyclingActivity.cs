using System;

public class CyclingActivity : Activity
{
    private double _speed; // mph

    public CyclingActivity(DateTime date, int lengthInMinutes, double speedMph)
        : base(date, lengthInMinutes)
    {
        _speed = speedMph;
    }

    public override double GetDistance()
    {
        // Distance = speed * hours
        double hours = LengthInMinutes / 60.0;
        return _speed * hours;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        // Pace = 60 / speed
        return 60.0 / _speed;
    }
}
