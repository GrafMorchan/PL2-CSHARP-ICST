using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tests
{
    public static void Test1_1()
    {
        Console.WriteLine("Тест метода Meow класса Cat");

        Cat cat = new Cat("Нафаня");
        Console.WriteLine(cat);
        Console.WriteLine();

        Console.WriteLine("Без параметров: ");
        cat.Meow();
        Console.WriteLine();

        Console.WriteLine("0: ");
        cat.Meow(0);
        Console.WriteLine();

        Random rand = new Random();

        Console.WriteLine("Случайные числа от 1 до 10: ");

        for (int i = 0; i < 3; i++) 
        {
            cat.Meow(rand.Next(1, 10));
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    public static void Test1_2() 
    {
        Console.WriteLine("Тест метода CatsMeow класса Meow");

        Cat cat1 = new Cat("Нафаня");
        Cat cat2 = new Cat("Барсик");
        Cat cat3 = new Cat("Шрёденгер");

        Console.WriteLine("1 Кот");
        Meow.CatsMeow(cat1);

        Console.WriteLine("3 Кота");
        Meow.CatsMeow(cat1, cat2, cat3);
        Console.WriteLine();
    }

    public static void Test1_3()
    {
        Console.WriteLine("Тест получения количества мяуканий");

        CatN cat1 = new CatN("Нафаня");
        CatN cat2 = new CatN("Барсик");
        CatN cat3 = new CatN("Шрёденгер");

        Meow.CatsMeow(cat1, cat2, cat3);
        Console.WriteLine($"{cat1}, {cat1.GetK()}");
        Console.WriteLine($"{cat2}, {cat2.GetK()}");
        Console.WriteLine($"{cat3}, {cat3.GetK()}");
        Console.WriteLine();
    }

    public static void Test2_1_1()
    {
        Console.WriteLine("Тест создания дробей");

        Fraction f = new Fraction(5, 2);
        Console.WriteLine($"Дробь созданная из чисел 5 и 2: {f}");

        
        f = new Fraction(5, -2);
        Console.WriteLine($"Дробь созданная из чисел 5 и -2: {f}");

        f = new Fraction(-5, 2);
        Console.WriteLine($"Дробь созданная из чисел -5 и 2: {f}");

        f = new Fraction(-5, -2);
        Console.WriteLine($"Дробь созданная из чисел -5 и -2: {f}");

        Console.WriteLine();
    }

    public static void Test2_1_2()
    {
        Console.WriteLine("Тест операций с дробями");

        Fraction f = new Fraction(1, 3);

        Console.WriteLine($"{f} + 3 = {f + 3}");
        Console.WriteLine($"3 + {f} = {3 + f}");

        Console.WriteLine($"{f} - 3 = {f - 3}");
        Console.WriteLine($"3 - {f} = {3 - f}");

        Console.WriteLine($"{f} * 3 = {f * 3}");
        Console.WriteLine($"3 * {f} = {3 * f}");

        Console.WriteLine($"{f} / 3 = {f / 3}");
        Console.WriteLine($"3 / {f} = {3 / f}");

        Console.WriteLine();

        Fraction f2 = new Fraction(2, 7);

        Console.WriteLine($"{f} + {f2} = {f + f2}");
        Console.WriteLine($"{f2} + {f} = {f2 + f}");

        Console.WriteLine($"{f} - {f2} = {f - f2}");
        Console.WriteLine($"{f2} - {f} = {f2 - f}");

        Console.WriteLine($"{f} * {f2} = {f * f2}");
        Console.WriteLine($"{f2} * {f} = {f2 * f}");

        Console.WriteLine($"{f} / {f2} = {f / f2}");
        Console.WriteLine($"{f2} / {f} = {f2 / f}");
        Console.WriteLine();
    }

    public static void Test2_1_3() 
    {
        Console.WriteLine("Тест выржения f1.sum(f2).div(f3).minus(5)");
        Fraction f1 = new Fraction(1, 3);
        Fraction f2 = new Fraction(2, 3);
        Fraction f3 = new Fraction(2, 5);

        Console.WriteLine($"({f1} + {f2}) / {f2} - 5 = {(f1 + f2) / f2 - 5}");

        Console.WriteLine();

    }

    public static void Test2_2() 
    {
        Console.WriteLine("Тест сравнения дробей");
        Fraction f1 = new Fraction(1, 3);
        Fraction f2 = new Fraction(1, 3);

        Console.WriteLine($"{f1}, {f2}: {f1.Equals(f2)}");

        f1 = new Fraction(2, 3);
        Console.WriteLine($"{f1}, {f2}: {f1.Equals(f2)}");

        f1 = new Fraction(2, 6);
        Console.WriteLine($"{f1}, {f2}: {f1.Equals(f2)}");

        Console.WriteLine();
    }

    public static void Test2_3() 
    {
        Console.WriteLine("Тест клонирования дроби");
        Random rnd = new Random();

        for (int i = 0; i < 3; i++)
        {
            Fraction f = new Fraction(rnd.Next(1, 30), rnd.Next(31, 50));
            Console.WriteLine($"Дробь: {f}");
            var clone = f.Clone();
            Console.WriteLine($"Клон: {clone}");
            Console.WriteLine();
        }

        Console.WriteLine();

    }

    public static void Test2_4()
    {
        Console.WriteLine("Тест Вычисления вещественного значения");
        Random rnd = new Random();
        for (int i = 0; i < 3; i++)
        {
            Fraction f = new Fraction(rnd.Next(1, 10), rnd.Next(1, 25));
            Console.WriteLine($"{f} = {f.GetDouble()}");
        }
        Console.WriteLine();
    }

    public static void Test2_5()
    {
        Console.WriteLine("Тест изменения числителя, знаменателя");
        Random rnd = new Random();
        for (int i = 0; i < 3; i++)
        {
            Fraction f = new Fraction(rnd.Next(1, 10), rnd.Next(1, 25));
            Console.WriteLine($"Дробь: {f}");
            f.SetNum(rnd.Next(1, 10));
            f.SetDen(rnd.Next(1, 40));
            Console.WriteLine($"После изменения: {f}");
        }
        Console.WriteLine();
    }

    public static void Test2_6()
    {
        Console.WriteLine("Тест FractionPlus");
        Random rnd = new Random();
        for (int i = 0; i < 3; i++)
        {
            FractinPlus f = new FractinPlus(rnd.Next(1, 10), rnd.Next(1, 25));
            Console.WriteLine($"Дробь: {f}, {f.GetDouble()}");
            f.SetNum(rnd.Next(1, 10));
            f.SetDen(rnd.Next(1, 40));
            Console.WriteLine($"После изменения: {f}, {f.GetDouble()}");
        }
        Console.WriteLine();
    }
}