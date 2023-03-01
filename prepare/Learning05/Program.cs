using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("Red", 4);
        shapes.Add(square);
        Rectangle rectangle = new Rectangle("Green", 5, 4);
        shapes.Add(rectangle);
        Circle circle = new Circle("Blue", 3);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            shape.GetColor();
            shape.GetArea();
        }
    }
}