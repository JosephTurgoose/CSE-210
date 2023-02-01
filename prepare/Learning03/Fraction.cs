using System;

public class Fraction
{
    private int _top;
    private int _bottom;
//
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
//
    public void GetTop()
    {
        Console.WriteLine(_top);
    }
    public void SetTop(int input)
    {
        _top = input;
    }
    public void GetBottom()
    {
        Console.WriteLine(_bottom);
    }
    public void SetBottom(int input)
    {
        _bottom = input;
    }
//
    public string GetFractionString()
    {
        string variable = ($"{_top}/{_bottom}");
        return variable;
    }
    public double GetDecimalValue()
    {
        double variable = (double)_top / (double)_bottom;
        return variable;
    }

}