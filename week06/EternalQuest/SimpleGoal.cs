// Derived class for goals that can be completed once.
public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Constructor for creating a new simple goal.
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    // Overloaded constructor for loading simple goals from a file.
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Marks the goal complete and awards points once.
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    // Returns true if completed.
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Returns serialized string format for saving.
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}
