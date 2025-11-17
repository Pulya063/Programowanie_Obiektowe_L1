using System;
using System.Collections.Generic;
using System.Linq;

public interface IModular
{
    public double Module();
}

public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular, IComparable<ComplexNumber>
{
    private double re;
    private double im;

    public double Re { get => re; set => re = value; }
    public double Im { get => im; set => im = value; }

    public ComplexNumber(double re, double im)
    {
        this.re = re;
        this.im = im;
    }

    public override string ToString()
    {
        string sign = im >= 0 ? "+" : "-";
        return $"{re} {sign} {Math.Abs(im)}i";
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re + b.re, a.im + b.im);

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re - b.re, a.im - b.im);

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re * b.re - a.im * b.im, a.re * b.re + a.im * b.im);

    public static ComplexNumber operator -(ComplexNumber a)
        => new ComplexNumber(a.re, -a.im);

    public object Clone() => new ComplexNumber(re, im);

    public bool Equals(ComplexNumber other)
    {
        if (other == null) return false;
        return re == other.re && im == other.im;
    }

    public override bool Equals(object obj)
        => obj is ComplexNumber other && Equals(other);

    public override int GetHashCode()
        => HashCode.Combine(re, im);

    public static bool operator ==(ComplexNumber a, ComplexNumber b)
        => a?.Equals(b) ?? b is null;

    public static bool operator !=(ComplexNumber a, ComplexNumber b)
        => !(a == b);

    public double Module()
        => Math.Sqrt(re * re + im * im);

    public int CompareTo(ComplexNumber other)
    {
        if (other == null) return 1;
        return this.Module().CompareTo(other.Module());
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("===== ZADANIE 2 — TABLICA =====");

        ComplexNumber[] arr =
        {
            new ComplexNumber(1,2),
            new ComplexNumber(3,-4),
            new ComplexNumber(-2,5),
            new ComplexNumber(0,-3),
            new ComplexNumber(4,1)
        };

        Console.WriteLine("\na) Wypisanie tablicy:");
        foreach (var z in arr) Console.WriteLine(z);

        Console.WriteLine("\nb) Sortowanie po module:");
        Array.Sort(arr);
        foreach (var z in arr) Console.WriteLine(z);

        Console.WriteLine("\nc) Minimum i maksimum:");
        Console.WriteLine("Min: " + arr.Min());
        Console.WriteLine("Max: " + arr.Max());

        Console.WriteLine("\nd) Filtrowanie Im < 0:");
        var filteredArr = arr.Where(z => z.Im < 0);
        foreach (var z in filteredArr) Console.WriteLine(z);


        Console.WriteLine("\n===== ZADANIE 3 — LISTA =====");

        List<ComplexNumber> list = new()
        {
            new ComplexNumber(1,2),
            new ComplexNumber(3,-4),
            new ComplexNumber(-2,5),
            new ComplexNumber(0,-3),
            new ComplexNumber(4,1)
        };

        Console.WriteLine("\na) Usuń drugi element:");
        list.RemoveAt(1);
        list.ForEach(Console.WriteLine);

        Console.WriteLine("\nb) Usuń najmniejszy:");
        var minList = list.Min();
        list.Remove(minList);
        list.ForEach(Console.WriteLine);

        Console.WriteLine("\nc) Wyczyść listę:");
        list.Clear();
        list.ForEach(Console.WriteLine);


        Console.WriteLine("\n===== ZADANIE 4 — HASHSET =====");

        HashSet<ComplexNumber> set = new()
        {
            new ComplexNumber(6,7),
            new ComplexNumber(1,2),
            new ComplexNumber(6,7),
            new ComplexNumber(1,-2),
            new ComplexNumber(-5,9)
        };

        Console.WriteLine("\na) Zawartość zbioru:");
        foreach (var z in set) Console.WriteLine(z);

        Console.WriteLine("\nb) Min i Max w zbiorze (można!):");
        Console.WriteLine("Min: " + set.Min());
        Console.WriteLine("Max: " + set.Max());

        Console.WriteLine("\nc) Filtrowanie Im < 0:");
        foreach (var z in set.Where(z => z.Im < 0))
            Console.WriteLine(z);

        Console.WriteLine("\nd) Sortowanie (HashSet nie ma sortowania):");
        var sortedSet = set.OrderBy(z => z.Module());
        foreach (var z in sortedSet) Console.WriteLine(z);


        Console.WriteLine("\n===== ZADANIE 5 — SŁOWNIK =====");

        Dictionary<string, ComplexNumber> dict = new()
        {
            {"z1", new ComplexNumber(6,7)},
            {"z2", new ComplexNumber(1,2)},
            {"z3", new ComplexNumber(6,7)},
            {"z4", new ComplexNumber(1,-2)},
            {"z5", new ComplexNumber(-5,9)}
        };

        Console.WriteLine("\na) Wszystkie elementy (klucz, wartość):");
        foreach (var kv in dict)
            Console.WriteLine($"{kv.Key}: {kv.Value}");

        Console.WriteLine("\nb) Same klucze:");
        foreach (var key in dict.Keys)
            Console.WriteLine(key);

        Console.WriteLine("\nSame wartości:");
        foreach (var value in dict.Values)
            Console.WriteLine(value);

        Console.WriteLine("\nc) Czy istnieje klucz z6?");
        Console.WriteLine(dict.ContainsKey("z6"));

        Console.WriteLine("\nd) Min i Max z wartości słownika:");
        Console.WriteLine("Min: " + dict.Values.Min());
        Console.WriteLine("Max: " + dict.Values.Max());

        Console.WriteLine("\nFiltrowanie Im < 0:");
        foreach (var z in dict.Values.Where(z => z.Im < 0))
            Console.WriteLine(z);

        Console.WriteLine("\ne) Usuń z3:");
        dict.Remove("z3");

        Console.WriteLine("\nf) Usuń drugi element:");
        var secondKey = dict.Keys.ElementAt(1);
        dict.Remove(secondKey);

        Console.WriteLine("\ng) Wyczyść słownik:");
        dict.Clear();

        Console.WriteLine("\nKoniec programu.");
    }
}
