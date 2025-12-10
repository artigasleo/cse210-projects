using System;

public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    protected Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public DateTime Date => _date;
    public int LengthInMinutes => _lengthInMinutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace(); 

    public string GetSummary()
    {
        string dateText = _date.ToString("dd MMM yyyy");
        string activityType = GetType().Name.Replace("Activity", ""); 

        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{dateText} {activityType} ({_lengthInMinutes} min): " +
               $"Distance {distance:F1} miles, Speed {speed:F1} mph, Pace: {pace:F2} min per mile";
    }
}
