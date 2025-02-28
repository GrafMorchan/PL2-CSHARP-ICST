using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

class Fraction : ICloneable, IFraction
{
    private protected int num;
    private protected int den;

    public Fraction(int num, int den)
    {
        if (den < 0)
        {
            this.num = -num;
            this.den = -den;
        }
        else if (den == 0)
            throw new DivideByZeroException("Знаменатель дроби не может быть равен 0!!!");
        else
        {
            this.num = num;
            this.den = den;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Fraction other)
        {
            return false;
        }

        return num == other.num && den == other.den;
    }

    public override string ToString()
    {
        return $"{num}/{den}";
    }

    public object Clone()
    {
        return new Fraction(this.num, this.den);
    }

    public double GetDouble() => (double)this.num / this.den;

    public void SetNum(int n) => this.num = n;

    public void SetDen(int n) => this.den = n;

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.num * f2.den + f2.num * f1.den, f1.den * f2.den);
    }

    public static Fraction operator +(Fraction f1, int n)
    {
        return new Fraction(f1.num + n * f1.den, f1.den);
    }

    public static Fraction operator +(int n, Fraction f1) => f1 + n;

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.num * f2.den - f2.num * f1.den, f1.den * f2.den);
    }

    public static Fraction operator -(Fraction f1, int n)
    {
        return new Fraction(f1.num - n * f1.den, f1.den);
    }

    public static Fraction operator -(int n, Fraction f1)
    {
        return new Fraction(n * f1.den - f1.num, f1.den);
    }

    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.num * f2.num, f1.den * f2.den);
    }

    public static Fraction operator *(Fraction f, int n)
    {
        return f * new Fraction(n, 1);
    }

    public static Fraction operator *(int n, Fraction f)
    {
        return f * n;
    }

    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.num * f2.den, f1.den * f2.num);
    }

    public static Fraction operator /(Fraction f, int n)
    {
        return new Fraction(f.num, f.den * n);
    }

    public static Fraction operator /(int n, Fraction f)
    {
        return new Fraction(n, 1) / f;
    }
}
