using System;

class Program
{
    static void Main(string[] args)
    {
        // Testing the Fraction class 
        Console.Clear();
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction();
        Fraction f3 = new Fraction();

        Console.WriteLine(f1.GetFractionString()); // Output: 1/1
        Console.WriteLine(f2.GetFractionString()); // Output: 5/1
        Console.WriteLine(f3.GetFractionString()); // Output: 3/4

        Console.WriteLine(f1.GetDecimalValue());   // Output: 1
        Console.WriteLine(f2.GetDecimalValue());   // Output: 5
        Console.WriteLine(f3.GetDecimalValue());   // Output: 0.75

        f3.Top = 3;
        f3.Bottom = 4;
        Console.WriteLine(f3.GetFractionString()); // Output: 7/8
        Console.WriteLine(f3.GetDecimalValue());   // Output: 0.875





        Console.ReadKey();
        Console.Clear();
    }
}
class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;

    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int Top
    {
        get { return _top; }
        set { _top = value; }

    }
    public int Bottom
    {
        get { return _bottom; }
        set { _bottom = value; }
    }

    public string GetFractionString()
    {
        return $"{_top} / {Bottom}";
    }
    public double GetDecimalValue()
    {
        return Convert.ToDouble(_top)/_bottom ; // alternative would be Double(_Top)
    }
    
}