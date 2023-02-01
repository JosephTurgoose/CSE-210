using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(6,7);

        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction3.GetFractionString());
        // Done

        Console.WriteLine();

        fraction3.SetTop(3);
        fraction3.SetBottom(4);
        fraction3.GetTop();
        fraction3.GetBottom();
        Console.WriteLine(fraction3.GetFractionString());
        // Done

        Console.WriteLine();

        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
        // Done

    }
}