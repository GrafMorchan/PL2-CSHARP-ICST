using System;

public class BooleanPair
{
    private bool field1;
    private bool field2;

    // Конструктор
    public BooleanPair(bool field1, bool field2)
    {
        this.field1 = field1;
        this.field2 = field2;
    }

    // Конструктор копирования
    public BooleanPair(BooleanPair other)
    {
        this.field1 = other.field1;
        this.field2 = other.field2;
    }

    // Метод для вычисления отрицания конъюнкции полей
    public bool NotAnd()
    {
        return !(field1 && field2);
    }

    // Перегруженный метод ToString()
    public override string ToString()
    {
        return $"Field1: {field1}, Field2: {field2}";
    }
}

public class UserAccount : BooleanPair
{
    // Поля: 
    // - active: активность аккаунта
    // - verified: подтвержден ли email
    public bool active;
    public bool verified;

    // Конструктор 
    public UserAccount(bool active, bool verified) : base(active, verified)
    {
        this.active = active;
        this.verified = verified;
    }

    // Конструктор копирования
    public UserAccount(UserAccount other) : base(other)
    {
        this.active = other.active;
        this.verified = other.verified;
    }

    // Метод для проверки, может ли пользователь войти в систему
    public bool CanLogin()
    {
        return active && verified;
    }

    // Метод для проверки, может ли пользователь получить доступ к определенным функциям
    public bool HasFullAccess()
    {
        return active && verified && NotAnd();
    }

    // Метод для обновления статуса аккаунта
    public void SetActive(bool isActive)
    {
        this.active = isActive;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Тесты для BooleanPair
        Console.WriteLine("Тесты для BooleanPair:");
        // Создание объекта BooleanPair
        BooleanPair pair1 = new BooleanPair(true, false);

        // Тестирование метода NotAnd()
        Console.WriteLine($"NotAnd(): {pair1.NotAnd()}"); // Ожидаемый результат: True

        // Создание копии объекта
        BooleanPair pair2 = new BooleanPair(pair1);

        // Проверка равенства полей в копии
        Console.WriteLine($"Pair2: {pair2}"); // Ожидаемый результат: Field1: True, Field2: False

        // Проверка метода ToString()
        Console.WriteLine(pair1.ToString()); // Ожидаемый результат: Field1: True, Field2: False

        // Тесты для UserAccount
        Console.WriteLine("\nТесты для UserAccount:");
        // Создание объекта UserAccount
        UserAccount user1 = new UserAccount(true, true);

        // Тестирование метода CanLogin()
        Console.WriteLine($"CanLogin(): {user1.CanLogin()}"); // Ожидаемый результат: True

        // Тестирование метода HasFullAccess()
        Console.WriteLine($"HasFullAccess(): {user1.HasFullAccess()}"); // Ожидаемый результат: False

        // Создание копии объекта
        UserAccount user2 = new UserAccount(user1);

        // Проверка равенства полей в копии
        Console.WriteLine($"User2: {user2}"); // Ожидаемый результат: Field1: True, Field2: True

        // Тестирование метода SetActive()
        user1.SetActive(false);
        Console.WriteLine($"CanLogin() after setting Active to false: {user1.CanLogin()}"); // Ожидаемый результат: False
    }
}
