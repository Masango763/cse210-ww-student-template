/// <summary>
/// Derived class representing a Swimming lap pool activity.
/// </summary>
public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int lengthMinutes, int laps, string unitSystem = "miles") 
        : base(date, lengthMinutes, unitSystem)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double meters = _laps * 50;
        
        if (GetUnitSystem() == "km")
        {
            return meters / 1000.0;
        }
        else
        {
            return (meters / 1000.0) * 0.62;
        }
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthMinutes() / GetDistance();
    }
}
