using System;

public interface IModular
{
    float Module();
}
class ComplexNumber
{
    private float real;
    private float im;

    public float Re
    {
        get { return real; }
        set { real = value; }
    }

    public float Im
    {
        get { return im; }
        set { im = value; }
    }

    public ComplexNumber(float real, float im)
    {
        this.real = real;
        this.im = im;
    }

    public override string ToString()
    {
        return $"{real} + {im}i";
    }

    public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.real + c2.real, c1.im + c2.im);
    }

    public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.real - c2.real, c1.im - c2.im);
    }

    public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
    {
        float realPart = c1.real * c2.real - c1.im * c2.im;
        float imPart = c1.real * c2.im + c1.im * c2.real;
        return new ComplexNumber(realPart, imPart);
    }

    public static ComplexNumber operator -(ComplexNumber c)
    {
        if (c is null) throw new ArgumentNullException(nameof(c));
        return new ComplexNumber(c.real, -c.im);
    }

    public static bool operator ==(ComplexNumber? a, ComplexNumber? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.real == b.real && a.im == b.im;
    }

    public static bool operator !=(ComplexNumber? a, ComplexNumber? b)
        => !(a == b);

    public object Clone()
    {
        return new ComplexNumber(this.real, this.im);
    }

    public bool Equals(ComplexNumber? obj)
    {
        if (ReferenceEquals(obj, null))
            return false;
        if (ReferenceEquals(this, obj))
            return true;

        return this.real == obj.real && this.im == obj.im;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ComplexNumber);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(real, im);
    }

    public float Module()
    {
        return MathF.Sqrt(real * real + im * im);
    }
}


class Program
{
    public static void Main(string[] args)
    {
        var c1 = new ComplexNumber(2.0f, 3.0f);
        var c2 = new ComplexNumber(4.0f, 5.0f);
        var c4 = new ComplexNumber(-1.0f, 2.5f);

        Console.WriteLine($"c1 = {c1}");
        Console.WriteLine($"c2 = {c2}");
        Console.WriteLine($"c4 = {c4}");

        Console.WriteLine($"c1 + c2 = {c1 + c2}");
        Console.WriteLine($"c1 - c2 = {c1 - c2}");
        Console.WriteLine($"c1 * c2 = {c1 * c2}");
        Console.WriteLine($"conjugate of c1 = {-c1}");

        Console.WriteLine($"c1 == c2: {c1 == c2}");
        Console.WriteLine($"c1 != c2: {c1 != c2}");

        Console.WriteLine($"Module(c1) = {c1.Module()}");
        Console.WriteLine($"Module(c2) = {c2.Module()}");
        Console.WriteLine($"Module(c4) = {c4.Module()}");

        var copy = (ComplexNumber)c1.Clone();
        Console.WriteLine($"copy of c1 = {copy}, equals original: {copy.Equals(c1)}");

    }
}