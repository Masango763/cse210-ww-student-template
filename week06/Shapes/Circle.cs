using System;

// Derived class Circle inheriting from the abstract Shape base class.
public class Circle : Shape
{
    private double _radius;

    // Constructor passing the color to the base class and initializing the radius.
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Overridden method providing specific area calculation logic for a circle using Math.PI.
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
