// Derived class Square inheriting from the abstract Shape base class.
public class Square : Shape
{
    private double _side;

    // Constructor passing the color to the base class and initializing the side length.
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Overridden method providing specific area calculation logic for a square.
    public override double GetArea()
    {
        return _side * _side;
    }
}
