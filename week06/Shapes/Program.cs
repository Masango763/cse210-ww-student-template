using System;
using System.Collections.Generic;
using System.Linq;

// Main program entry point demonstrating polymorphism, abstract classes, interfaces, and LINQ queries.
class Program
{
    static void Main(string[] args)
    {
        // Initialize a polymorphic list holding various derived shape objects.
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 4.0),
            new Rectangle("Blue", 5.0, 3.0),
            new Circle("Green", 2.5),
            new Square("Yellow", 6.5),
            new Circle("Red", 3.0)
        };

        Console.WriteLine("=== ALL SHAPES (Polymorphism in Action) ===");
        // Iterate through the list, invoking DisplayDetails() polymorphically.
        foreach (Shape shape in shapes)
        {
            shape.DisplayDetails();
        }

        Console.WriteLine("\n=== ADVANCED ENHANCEMENTS: LINQ QUERIES ===");

        // 1. Use LINQ OrderByDescending and FirstOrDefault to find the shape with the maximum area.
        Shape largestShape = shapes.OrderByDescending(s => s.GetArea()).FirstOrDefault();
        if (largestShape != null)
        {
            Console.WriteLine($"\nLargest Shape Found:");
            largestShape.DisplayDetails();
        }

        // 2. Use LINQ Where clause to filter shapes matching a specific color case-insensitively.
        string searchColor = "Red";
        var redShapes = shapes.Where(s => s.GetColor().Equals(searchColor, StringComparison.OrdinalIgnoreCase));
        
        Console.WriteLine($"\nShapes with color '{searchColor}':");
        foreach (var shape in redShapes)
        {
            shape.DisplayDetails();
        }

        // 3. Use LINQ Sum aggregate function to calculate the combined area of all shapes.
        double totalArea = shapes.Sum(s => s.GetArea());
        Console.WriteLine($"\nTotal Combined Area of All Shapes: {totalArea:F2}");
    }
}
