using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatusString();
    public abstract string GetStringRepresentation();
    public override string ToString()
    {
        return $"{_shortName} ({_description}) - {Points} points";
    }
}
