using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FractinPlus : Fraction
{
    private double v;

    public FractinPlus(int num, int den) : base(num, den)
    {
        v = (double)num / den;
    }

    public double GetDouble() { return v; }

    public void SetNum(int n)
    {
        base.SetNum(n);
        v = (double)num / den;
    }

    public void SetDen(int n)
    {
        base.SetDen(n);
        v = (double)num / den;
    }
}