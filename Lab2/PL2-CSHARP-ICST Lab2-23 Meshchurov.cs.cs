using System;

public class Money
{
    private uint rubles;
    private byte kopeks;

    // Конструктор
    public Money(uint rubles, byte kopeks)
    {
        if (kopeks > 99)
        {
            throw new ArgumentException("Количество копеек не может быть больше 99");
        }

        this.rubles = rubles;
        this.kopeks = kopeks;
    }

    // Свойства
    public uint Rubles
    {
        get { return rubles; }
    }

    public byte Kopeks
    {
        get { return kopeks; }
    }

    // Метод ToString()
    public override string ToString()
    {
        return $"{rubles} руб. {kopeks} коп.";
    }

    // Метод сравнения двух объектов Money
    public bool CompareTo(Money other)
    {
        if (this.rubles > other.rubles)
        {
            return true;
        }
        else if (this.rubles < other.rubles)
        {
            return false;
        }
        else
        {
            return this.kopeks > other.kopeks;
        }
    }

    // Унарные операции
    public static Money operator --(Money money)
    {
        if (money.kopeks == 0)
        {
            money.rubles--;
            money.kopeks = 99;
        }
        else
        {
            money.kopeks--;
        }
        return money;
    }

    public static Money operator ++(Money money)
    {
        if (money.kopeks == 99)
        {
            money.rubles++;
            money.kopeks = 0;
        }
        else
        {
            money.kopeks++;
        }
        return money;
    }

    // Операции приведения типа
    public static implicit operator uint(Money money)
    {
        return money.rubles;
    }

    public static explicit operator double(Money money)
    {
        return (double)money.kopeks / 100;
    }

    // Бинарные операции
    public static Money operator -(Money money, int value)
    {
        if (money.kopeks < value)
        {
            money.rubles--;
            money.kopeks = (byte)(100 - (value - money.kopeks));
        }
        else
        {
            money.kopeks -= (byte)value;
        }
        return money;
    }

    public static Money operator -(int value, Money money)
    {
        return money - value;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool continueLoop = true;

        while (continueLoop)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Создать новый объект Money");
            Console.WriteLine("2. Выполнить унарную операцию");
            Console.WriteLine("3. Выполнить операцию приведения типа");
            Console.WriteLine("4. Выполнить бинарную операцию");
            Console.WriteLine("5. Сравнить два объекта Money"); // Добавили пункт меню
            Console.WriteLine("6. Выход"); // Изменили номер выхода

            Console.Write("\nВведите номер операции: ");
            string choiceInput = Console.ReadLine();

            if (string.IsNullOrEmpty(choiceInput))
            {
                Console.WriteLine("Введите номер операции.");
                continue; // Пропустить итерацию цикла
            }

            int choice;
            if (!int.TryParse(choiceInput, out choice))
            {
                Console.WriteLine("Неверный формат ввода. Введите целое число.");
                continue; // Пропустить итерацию цикла
            }

            switch (choice)
            {
                case 1:
                    CreateMoneyObject();
                    break;
                case 2:
                    PerformUnaryOperation();
                    break;
                case 3:
                    PerformTypeConversion();
                    break;
                case 4:
                    PerformBinaryOperation();
                    break;
                case 5:
                    CompareMoneyObjects();
                    break;
                case 6:
                    continueLoop = false;
                    Console.WriteLine("Выход из программы.");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
            Console.WriteLine("======================================");
        }
    }

    // Метод для создания нового объекта Money
    static void CreateMoneyObject()
    {
        try
        {
            Console.Write("Введите количество рублей: ");
            string rublesInput = Console.ReadLine();

            if (string.IsNullOrEmpty(rublesInput))
            {
                throw new ArgumentException("Введите количество рублей.");
            }

            uint rubles = uint.Parse(rublesInput);

            Console.Write("Введите количество копеек: ");
            string kopeksInput = Console.ReadLine();

            if (string.IsNullOrEmpty(kopeksInput))
            {
                throw new ArgumentException("Введите количество копеек.");
            }

            byte kopeks = byte.Parse(kopeksInput);

            Money money = new Money(rubles, kopeks);
            Console.WriteLine($"Создан объект Money: {money}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    // Метод для выполнения унарной операции
    static void PerformUnaryOperation()
    {
        try
        {
            Console.WriteLine("1. Уменьшить количество копеек на 1 (--)");
            Console.WriteLine("2. Увеличить количество копеек на 1 (++)");

            Console.Write("Введите номер операции: ");
            string choiceInput = Console.ReadLine();

            if (string.IsNullOrEmpty(choiceInput))
            {
                throw new ArgumentException("Введите номер операции.");
            }

            int choice;
            if (!int.TryParse(choiceInput, out choice))
            {
                throw new ArgumentException("Неверный формат ввода. Введите целое число.");
            }

            Console.Write("Введите количество рублей: ");
            string rublesInput = Console.ReadLine();

            if (string.IsNullOrEmpty(rublesInput))
            {
                throw new ArgumentException("Введите количество рублей.");
            }

            uint rubles = uint.Parse(rublesInput);

            Console.Write("Введите количество копеек: ");
            string kopeksInput = Console.ReadLine();

            if (string.IsNullOrEmpty(kopeksInput))
            {
                throw new ArgumentException("Введите количество копеек.");
            }

            byte kopeks = byte.Parse(kopeksInput);

            Money money = new Money(rubles, kopeks);

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Результат: {--money}");
                    break;
                case 2:
                    Console.WriteLine($"Результат: {++money}");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    // Метод для выполнения операции приведения типа
    static void PerformTypeConversion()
    {
        try
        {
            Console.WriteLine("1. Приведение к uint (неявное)");
            Console.WriteLine("2. Приведение к double (явное)");

            Console.Write("Введите номер операции: ");
            string choiceInput = Console.ReadLine();

            if (string.IsNullOrEmpty(choiceInput))
            {
                throw new ArgumentException("Введите номер операции.");
            }

            int choice;
            if (!int.TryParse(choiceInput, out choice))
            {
                throw new ArgumentException("Неверный формат ввода. Введите целое число.");
            }

            Console.Write("Введите количество рублей: ");
            string rublesInput = Console.ReadLine();

            if (string.IsNullOrEmpty(rublesInput))
            {
                throw new ArgumentException("Введите количество рублей.");
            }

            uint rubles = uint.Parse(rublesInput);

            Console.Write("Введите количество копеек: ");
            string kopeksInput = Console.ReadLine();

            if (string.IsNullOrEmpty(kopeksInput))
            {
                throw new ArgumentException("Введите количество копеек.");
            }

            byte kopeks = byte.Parse(kopeksInput);

            Money money = new Money(rubles, kopeks);

            switch (choice)
            {
                case 1:
                    uint result1 = (uint)money;
                    Console.WriteLine($"Результат: {result1}");
                    break;
                case 2:
                    double result2 = (double)money;
                    Console.WriteLine($"Результат: {result2}");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    // Метод для выполнения бинарной операции
    static void PerformBinaryOperation()
    {
        try
        {
            Console.Write("Введите количество рублей: ");
            string rublesInput = Console.ReadLine();

            if (string.IsNullOrEmpty(rublesInput))
            {
                throw new ArgumentException("Введите количество рублей.");
            }

            uint rubles = uint.Parse(rublesInput);

            Console.Write("Введите количество копеек: ");
            string kopeksInput = Console.ReadLine();

            if (string.IsNullOrEmpty(kopeksInput))
            {
                throw new ArgumentException("Введите количество копеек.");
            }

            byte kopeks = byte.Parse(kopeksInput);

            Money money = new Money(rubles, kopeks);

            Console.Write("Введите количество копеек для вычитания: ");
            string valueInput = Console.ReadLine();

            if (string.IsNullOrEmpty(valueInput))
            {
                throw new ArgumentException("Введите количество копеек для вычитания.");
            }

            int value = int.Parse(valueInput);

            Console.WriteLine($"Результат: {money - value}");
            Console.WriteLine($"Результат: {value - money}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    static void CompareMoneyObjects()
    {
        try
        {
            // Создаем два объекта Money
            Money money1 = GetMoneyFromUser("Первый объект Money");
            Money money2 = GetMoneyFromUser("Второй объект Money");

            // Сравниваем объекты с помощью метода CompareTo
            bool result = money1.CompareTo(money2);

            // Выводим результат сравнения
            Console.WriteLine($"Результат сравнения: {result} (true - первый объект больше, false - второй объект больше/равны)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    // Вспомогательный метод для получения объекта Money от пользователя
    static Money GetMoneyFromUser(string prompt)
    {
        Console.WriteLine(prompt);

        Console.Write("Введите количество рублей: ");
        string rublesInput = Console.ReadLine();
        uint rubles = uint.Parse(rublesInput);

        Console.Write("Введите количество копеек: ");
        string kopeksInput = Console.ReadLine();
        byte kopeks = byte.Parse(kopeksInput);

        return new Money(rubles, kopeks);
    }
}