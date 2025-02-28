using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Meow
{
    public static void CatsMeow(params ICat[] cats)
    {
        Random rnd = new Random();
        foreach (ICat cat in cats)
            cat.Meow(rnd.Next(1, 7));
    }
}