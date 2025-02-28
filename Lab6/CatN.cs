using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CatN : Cat
{
    private int k;

    public int GetK() => k;

    public CatN(string name) : base(name)
    {
        this.k = 0;
    }

    public override void Meow(int? n = null)
    {
        base.Meow(n);
        if (n is null)
            k++;
        else if (n != 0)
            k += (int)n;
    }
}
