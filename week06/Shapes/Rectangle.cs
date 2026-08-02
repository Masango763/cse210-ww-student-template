// Derived class Rectangle inheriting from the abstract Shape base class.
public class Rectangle : Shape
{
    private double _length;
    private double _width;

    // Constructor passing the color to the base class and initializing dimensions.
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Overridden method providing specific area calculation logic for a rectangle.
    public override double GetArea()
    {
        return _length * _width;
    }
}
