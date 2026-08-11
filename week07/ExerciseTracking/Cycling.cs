/// <summary>
/// Derived class representing a Stationary Bicycle activity.
/// </summary>
public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int lengthMinutes, double speed, string unitSystem = "miles") 
        : base(date, lengthMinutes, unitSystem)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * GetLengthMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
