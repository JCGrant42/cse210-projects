using System;

class Program
{
    static void Main(string[] args)
    {
        Shape square = new Square("blue", 5);
        Shape rectangle = new Rectangle("green", 3, 4);
        Shape circle = new Circle("red", 4);
        List<Shape> list = new List<Shape>();
        list.Add(square);
        list.Add(rectangle);
        list.Add(circle);
        foreach (Shape shape in list){
            string color = shape.GetColor();
            double area = shape.GetArea();
            Type type = shape.GetType();
            Console.WriteLine($"This is a {color} {type} with an area of {area}");
        }
    }
}