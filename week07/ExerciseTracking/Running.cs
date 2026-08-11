/// <summary>
/// Derived class representing a Running activity.
/// </summary>
public class Running : Activity
{
    private double _distance;

    public Running(string date, int lengthMinutes, double distance, string unitSystem = "miles") 
        : base(date, lengthMinutes, unitSystem)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetLengthMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthMinutes() / _distance;
    }
}
