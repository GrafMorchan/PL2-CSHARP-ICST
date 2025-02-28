using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cat : ICat
{
    private string name;

    public Cat(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return $"Имя: {name}";
    }

    public override void Meow(int? n = null)
    {
        if (n == null)
        {
            Console.WriteLine($"{name}: мяу!");
        }
        else if (n != 0)
        {
            string s = $"{name}: ";
            for (int i = 0; i < n; i++)
                s += "мяу-";
            s = $"{s.Substring(0, s.Length - 1)}!";
            Console.WriteLine(s);
        }

    }
}
