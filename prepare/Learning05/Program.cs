using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.ReadKey();
        Console.Clear();
        Square square = new Square("red", 5);
        Console.WriteLine($"The color of the square: {square.GetColor()}");
        Console.WriteLine($"Square Area: {square.GetArea()}");
        Console.ReadKey();
        Console.Clear();

        Rectangle rectangle = new Rectangle("Purple", 6, 29);
        Console.WriteLine($"The color of the RECTANGLE : {rectangle.GetColor()}");
        Console.WriteLine($"Square Area: {rectangle.GetArea()}");
        Console.ReadKey();
        Console.Clear();

        Circle circle = new Circle("purple", 7);
        Console.WriteLine($"The color of the circle  : {rectangle.GetColor()}");
        Console.WriteLine($"Square Area: {rectangle.GetArea()}");
        Console.ReadKey();
        Console.Clear();

        // building list 
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("red", 5));
        shapes.Add(new Rectangle("Purple", 6, 29));
        shapes.Add(new Circle("purple", 7));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
            Console.WriteLine();
        }
        Console.ReadKey();
        Console.Clear();

        // building array 
        Shape[] shapes1 = new Shape[3]
        {
            new Square("red", 5),
            new Rectangle("Purple", 6, 29),
            new Circle("purple", 7),
        };
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
            Console.WriteLine(" in the form of array ");
        }
    }
    
    class Shape
    {
        public string _color;


        public Shape(string color)
        {
            _color = color;
        }
        public string GetColor()
        {
            return _color;

        }
        public virtual double GetArea()
        {
            return 8;
        }
    }
    class Square : Shape
    {
        public double _side;


        public Square(string color, double side) : base(color)
        {
            _side = side;

        }

        public override double GetArea()
        {
            return _side * _side;
        }
    }
    class Rectangle : Shape
    {
        public double _length;
        public double _width;

        public Rectangle(string color, double length, double width) : base(color)
        {
            _length = length;
            _width = width;
        }
        public override double GetArea()
        {
            return _length * _width;
        }
    }
    class Circle : Shape
    {
        public double _radius;

        public Circle(string color, double radius) : base(color)
        {
            _radius = radius;

        }
        public override double GetArea()
        {
            return Math.PI * _radius * _radius;
        }
    }

}