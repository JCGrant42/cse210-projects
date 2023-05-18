using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");

        Fraction frac1 = new Fraction();
        Console.WriteLine($"Fraction 1: {frac1.GetFractionString()}");
        frac1.SetUpper(5);
        frac1.SetLower(3);
        Console.WriteLine("Changing Fraction 1");
        Console.WriteLine($"Fraction 1: {frac1.GetFractionString()}");
        Console.WriteLine($"Fraction 1: {frac1.GetDeciamalValue()}");

        Fraction frac2 = new Fraction(5);
        Console.WriteLine($"Fraction 2: {frac2.GetFractionString()}");
        Console.WriteLine($"Fraction 2: {frac2.GetDeciamalValue()}");

        Fraction frac3 = new Fraction(2, 4);
        Console.WriteLine($"Fraction 3: {frac3.GetFractionString()}");
        Console.WriteLine($"Fraction 3: {frac3.GetDeciamalValue()}");

    }
}