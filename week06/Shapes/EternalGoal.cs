// Derived class for habits or actions that never technically finish but award points continuously.
public class EternalGoal : Goal
{
    // Constructor to initialize an eternal goal.
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    // Always records the event and awards points without changing completion state.
    public override int RecordEvent()
    {
        return _points;
    }

    // Eternal goals are never complete.
    public override bool IsComplete()
    {
        return false;
    }

    // Returns serialized string format for saving.
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}
