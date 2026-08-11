using System;

/// <summary>
/// Abstract base class representing a generic fitness activity.
/// Encapsulates shared attributes and provides abstract/virtual methods for polymorphism.
/// </summary>
public abstract class Activity
{
    private string _date;
    private int _lengthMinutes;
    private string _unitSystem;

    protected Activity(string date, int lengthMinutes, string unitSystem = "miles")
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
        _unitSystem = unitSystem.ToLower();
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetLengthMinutes()
    {
        return _lengthMinutes;
    }

    public string GetUnitSystem()
    {
        return _unitSystem;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string distUnit = _unitSystem == "km" ? "km" : "miles";
        string speedUnit = _unitSystem == "km" ? "kph" : "mph";
        string paceUnit = _unitSystem == "km" ? "min per km" : "min per mile";

        return $"{GetDate()} {GetType().Name} ({GetLengthMinutes()} min): " +
               $"Distance {GetDistance():0.0} {distUnit}, " +
               $"Speed: {GetSpeed():0.0} {speedUnit}, " +
               $"Pace: {GetPace():0.00} {paceUnit}";
    }
}
