using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor 1: sem parâmetros → 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2: apenas o numerador → x/1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor 3: numerador e denominador
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters
    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    // Setters
    public void SetTop(int value)
    {
        _top = value;
    }

    public void SetBottom(int value)
    {
        _bottom = value;
    }

    // Retorna "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Retorna decimal (double)
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}
