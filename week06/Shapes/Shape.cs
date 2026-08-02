// Abstract base class representing generic shapes, implementing the IPrintable contract.
public abstract class Shape : IPrintable
{
    private string _color;

    // Protected constructor to initialize the common color attribute for derived shapes.
    protected Shape(string color)
    {
        _color = color;
    }

    // Getter for retrieving the shape's color.
    public string GetColor()
    {
        return _color;
    }

    // Setter for modifying the shape's color.
    public void SetColor(string color)
    {
        _color = color;
    }

    // Abstract method: forces all derived shape classes to implement their own area calculation logic.
    public abstract double GetArea();

    // Virtual method from IPrintable: provides a default implementation to output shape details.
    public virtual void DisplayDetails()
    {
        System.Console.WriteLine($"Color: {_color}, Area: {GetArea():F2}");
    }
}
