// Abstract base class representing generic goals with shared attributes and behaviors.
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor to initialize standard goal properties.
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Getter for the goal name.
    public string GetShortName()
    {
        return _shortName;
    }

    // Getter for the goal description.
    public string GetDescription()
    {
        return _description;
    }

    // Getter for the associated points.
    public int GetPoints()
    {
        return _points;
    }

    // Abstract method forcing derived classes to handle recording events and returning earned points.
    public abstract int RecordEvent();

    // Abstract method forcing derived classes to determine completion status.
    public abstract bool IsComplete();

    // Virtual method returning formatted details for display in lists.
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    // Abstract method for file serialization format.
    public abstract string GetStringRepresentation();
}
