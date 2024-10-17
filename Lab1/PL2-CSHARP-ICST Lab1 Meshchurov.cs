using System;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

public class TaskSolver
{
    // Задача 1: Сумма знаков
    public int sumLastNums(int x)
    {
        return (x % 10 + ((x / 10) % 10));
    }

    // Задача 2: Есть ли позитив?
    public bool isPositive(int x)
    {
        return x >= 0;
    }

    // Задача 3: Большая буква
    public bool isUpperCase(char x)
    {
        return Char.IsUpper(x);
    }

    // Задача 4: Делитель
    public bool isDivisor(int a, int b)
    {
        return ((a % b == 0) || (b % a == 0));
    }

    // Задача 5: Многократный вызов
    public int lastNumSum(int a, int b)
    {
        return (a % 10) + (b % 10);
    }

    //Задача 6: Безопасное деление
    public double safeDiv(int x, int y)
    {
        if (y == 0)
        {
            return 0;
        }

        else
        {
            return (double)x / y;
        }
    }

    //Задача 7: Строка сравнения
    public String makeDecision(int x, int y)
    {
        if (x > y)
        {
            return x + " > " + y;
        }
        else if (x < y)
        {
            return x + " < " + y;
        }
        else
        {
            return x + " == " + y;
        }
    }

    //Задача 8: Тройная сумма
    public bool sum3(int x, int y, int z)
    {
        if (x + y == z)
        {
            return true;
        }

        else if (x + z == y)
        {
            return true;
        }

        else if (y + z == x)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    //Задача 9: Возраст
    public String age(int x)
    {
        if (x % 10 == 1 && x % 100 != 11)
        {
            return x + " год";
        }
        else if (x % 10 >= 2 && x % 10 <= 4 && (x % 100 < 12 || x % 100 > 14))
        {
            return x + " года";
        }
        else
        {
            return x + " лет";
        }
    }

    //Задача 10: Вывод дней недели
    public void printDays(String x)
    {
        switch (x)
        {
            case "понедельник":
                Console.WriteLine("понедельник");
                Console.WriteLine("вторник");
                Console.WriteLine("среда");
                Console.WriteLine("четверг");
                Console.WriteLine("пятница");
                Console.WriteLine("суббота");
                Console.WriteLine("воскресенье");
                break;
            case "вторник":
                Console.WriteLine("вторник");
                Console.WriteLine("среда");
                Console.WriteLine("четверг");
                Console.WriteLine("пятница");
                Console.WriteLine("суббота");
                Console.WriteLine("воскресенье");
                break;
            case "среда":
                Console.WriteLine("среда");
                Console.WriteLine("четверг");
                Console.WriteLine("пятница");
                Console.WriteLine("суббота");
                Console.WriteLine("воскресенье");
                break;
            case "четверг":
                Console.WriteLine("четверг");
                Console.WriteLine("пятница");
                Console.WriteLine("суббота");
                Console.WriteLine("воскресенье");
                break;
            case "пятница":
                Console.WriteLine("пятница");
                Console.WriteLine("суббота");
                Console.WriteLine("воскресенье");
                break;
            case "суббота":
                Console.WriteLine("суббота");
                Console.WriteLine("воскресенье");
                break;
            case "воскресенье":
                Console.WriteLine("воскресенье");
                break;
            default:
                Console.WriteLine("Это не день недели!");
                break;
        }
    }

    //Задача 11: Числа наоборот
    public String reverseListNums(int x)
    {
        string result = "";
        if (x >= 0)
        {
            for (int i = x; i >= 0; i--)
            {
                result += i + " ";
            }
        }
        else
        {
            for (int i = x; i <= 0; i++)
            {
                result += i + " ";
            }
        }

        return result.TrimEnd(); // Удаляем пробел в конце строки
    }

    //Задача 12: Степень числа
    public int pow(int x, int y)
    {
        if (y == 0)
        {
            return 1; // Любое число в степени 0 равно 1
        }
        else
        {
            int result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x; // Умножаем result на x y раз
            }
            return result;
        }
    }

    //Задача 13: Одинаковость
    public bool equalNum(int x)
    {
        if (x < 10)
        {
            return true; // Однозначное число всегда имеет одинаковые цифры
        }

        int firstDigit = x % 10; // Получаем первую цифру
        x /= 10; // Удаляем первую цифру

        while (x > 0)
        {
            int currentDigit = x % 10; // Получаем текущую цифру
            if (currentDigit != firstDigit)
            {
                return false; // Если нашли цифру, отличную от первой - возвращаем false
            }
            x /= 10; // Удаляем текущую цифру
        }

        return true; // Все цифры оказались равны первой, возвращаем true
    }

    //Задача 14: Левый треугольник
    public void leftTriangle(int x)
    {
        for (int i = 1; i <= x; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine(); // Переход на новую строку после каждого ряда
        }
    }

    //Задача 15: Угадайка
    public void guessGame()
    {
        Random random = new Random();
        int secretNumber = random.Next(10); // Генерируем случайное число от 0 до 9
        int attempts = 0;
        Console.WriteLine("Вам загаданно случайное число от 0 до 9!");
        while (true)
        {
            Console.WriteLine("Введите число от 0 до 9:");
            int guess = Convert.ToInt32(Console.ReadLine());
            attempts++;

            if (guess == secretNumber)
            {
                Console.WriteLine("Вы угадали!");
                Console.WriteLine("Вы отгадали число за " + attempts + " попытки");
                break; // Прерываем цикл, если угадали
            }
            else
            {
                Console.WriteLine("Вы не угадали, введите число от 0 до 9:");
            }
        }
    }

    //Задача 16: Поиск последнего значения
    public int findLast(int[] arr, int x)
    {
        int lastIndex = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x)
            {
                lastIndex = i;
            }
        }
        return lastIndex;
    }

    //Задача 17: Добавление в массив
    public int[] add(int[] arr, int x, int pos)
    {
        int[] newArr = new int[arr.Length + 1]; // Создаем новый массив на 1 элемент больше

        // Копируем элементы из старого массива в новый
        for (int i = 0; i < pos; i++)
        {
            newArr[i] = arr[i];
        }

        // Вставляем x в заданную позицию
        newArr[pos] = x;

        // Копируем оставшиеся элементы из старого массива в новый
        for (int i = pos; i < arr.Length; i++)
        {
            newArr[i + 1] = arr[i];
        }

        return newArr; // Возвращаем новый массив
    }

    //Задача 18: Реверс 
    public void reverse(int[] arr)
    {
        Console.WriteLine("\nРеверсированный массив:");
        int n = arr.Length;
        for (int i = 0; i < n / 2; i++)
        {
            // Обмен элементов с противоположных концов массива
            int temp = arr[i];
            arr[i] = arr[n - i - 1];
            arr[n - i - 1] = temp;
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }

    //Задача 19: Объединение
    public int[] concat(int[] arr1, int[] arr2)
    {
        int[] result = new int[arr1.Length + arr2.Length]; // Создаем массив нужной длины

        // Копируем элементы из arr1
        for (int i = 0; i < arr1.Length; i++)
        {
            result[i] = arr1[i];
        }

        // Копируем элементы из arr2
        for (int i = 0; i < arr2.Length; i++)
        {
            result[i + arr1.Length] = arr2[i];
        }

        return result; // Возвращаем объединенный массив
    }

    //Задача 20: Удалить негатив
    public int[] deleteNegative(int[] arr)
    {
        int countPositive = 0;
        // Считаем количество положительных элементов
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 0)
            {
                countPositive++;
            }
        }

        // Создаем новый массив для положительных элементов
        int[] result = new int[countPositive];
        int index = 0;

        // Копируем положительные элементы в новый массив
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 0)
            {
                result[index] = arr[i];
                index++;
            }
        }

        return result;
    }

    // Главный метод
    public static void Main(string[] args)
    {
        TaskSolver solver = new TaskSolver();

        string[] number = { "Сумма знаков", "Есть ли позитив?", "Большая буква", "Делитель", "Многократный вызов",
                            "Безопасное деление", "Строка сравнения",  "Тройная сумма", "Возраст", "Вывод дней недели",
                            "Числа наоборот", "Степень числа", "Одинаковость", "Левый треугольник", "Угадайка",
                            "Поиск последнего значения", "Добавление в массив", "Реверс", "Объединение", "Удалить негатив"};
        int x = 0, y = 0, z = 0;
        char ch;
        int[] massive = { 1, 2, 3, 4, 2, 2, 5 };
        int[] massive2 = { 1, 2, 3, 4, 2, 2, 5 };
        int[] massive3 = { -1, 2, -3, 4, -5, 6 };

        // Вызов методов для решения задач
        while (true)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("[Лабораторная работа #1] Мещуров Сергей ПМИ-8");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("===============СПИСОК ЗАДАЧ===================");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"[{i+1}] {number[i]}");
            }
            Console.WriteLine("=============================================");
            Console.Write("Введите номер задачи для просмотра: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if ((choice > 0) && (choice <=20))
            {
                Console.WriteLine($"===============[{choice}] {number[choice-1]}===============");
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите целое положительное число, содержащее не менее 2-х знаков: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x > 9)
                    {
                        Console.WriteLine($"Сумма последних 2-х знаков: {solver.sumLastNums(x)}");
                    }
                    else
                    {
                        Console.WriteLine("ОШИБКА! Число не соответсвтует заданным условиям!");
                    }
                    break;

                case 2:
                    Console.WriteLine("Введите целое число: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Число положительное?: {solver.isPositive(x)}");
                    break;

                case 3:
                    Console.WriteLine("Введите букву латинского алфавита: ");
                    ch = Console.ReadKey().KeyChar;
                    Console.WriteLine($"\nБуква в верхнем регистре?: {solver.isUpperCase(ch)}");
                    break;

                case 4:
                    Console.WriteLine("Введите целое число x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите целое число y: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Возможно ли полностью разделить одно число на другое?: {solver.isDivisor(x, y)}");
                    break;

                case 5:
                    Console.WriteLine("Введите целое положительное число x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите целое положительное число y: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    if ((x >= 0) && (y >= 0))
                    {
                        Console.WriteLine($"Сумма последних знаков чисел: {solver.lastNumSum(x, y)}");
                    }
                    else
                    {
                        Console.WriteLine("ОШИБКА! Числа не соответсвтуют заданным условиям!");
                    }
                    break;

                case 6:
                    Console.WriteLine("Введите целое число x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите целое число y: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"{x} / {y} = {solver.safeDiv(x, y)}");
                    break;

                case 7:
                    Console.WriteLine("Введите целое число x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите целое число y: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Получается неравенство: {solver.makeDecision(x, y)}");
                    break;

                case 8:
                    Console.WriteLine("Введите целое число x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите целое число y: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите целое число z: ");
                    z = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Возможно ли сложить два числа, чтобы получить третье?: {solver.sum3(x, y, z)}");
                    break;

                case 9:
                    Console.WriteLine("Введите целое число x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x > 0)
                    {
                        Console.WriteLine($"Год и слово в правильной форме?: {solver.age(x)}");
                    }
                    else
                    {
                        Console.WriteLine("ОШИБКА! Год не должен быть меньше или равен 0!");
                    }
                    break;

                case 10:
                    string[] array = { "понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье" };
                    Console.WriteLine("Введите день недели (с маленькой буквы): ");
                    string? day = Console.ReadLine();
                    if (array.Contains(day))
                    {
                        solver.printDays(day);
                    }
                    else
                    {
                        Console.WriteLine("ОШИБКА! Строка не соответсвтует заданным условиям!");
                    }
                    break;

                case 11:
                    Console.WriteLine("Введите целое число x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Числа от x до 0: {solver.reverseListNums(x)}");
                    break;

                case 12:
                    Console.WriteLine("Введите целое неотрицательное число x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите целое неотрицательное число y: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    if ((x >= 0) && (x >= 0))
                    {
                        Console.WriteLine($"{x}^{y} = {solver.pow(x, y)}");
                    }
                    else
                    {
                        Console.WriteLine("ОШИБКА! Одно из чисел не соответсвтует заданным условиям!");
                    }
                    break;

                case 13:
                    Console.WriteLine("Введите целое неотрицательное число x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x >= 0)
                    {
                        Console.WriteLine($"Являются ли все цифры числа одинаковыми?: {solver.equalNum(x)}");
                    }
                    else
                    {
                        Console.WriteLine("ОШИБКА! Число не соответсвтует заданным условиям!");
                    }
                    break;

                case 14:
                    Console.WriteLine("Введите целое положительное число x: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x >= 0)
                    {
                        solver.leftTriangle(x);
                    }
                    else
                    {
                        Console.WriteLine("ОШИБКА! Число не соответсвтует заданным условиям!");
                    }
                    break;

                case 15:
                    solver.guessGame();
                    break;

                case 16:
                    Console.WriteLine("Ввести собственный массив (В противном случае будет использован массив [1,2,3,4,2,2,5]?) y/n");
                    ch = Console.ReadKey().KeyChar;
                    if (ch == 'y')
                    {
                        Console.WriteLine("\nВведите размер массива:");
                        int numbers = Convert.ToInt32(Console.ReadLine());

                        if (numbers < 0) 
                        { Console.WriteLine("ОШИБКА! Размер не введен или массив с заданным размером невозможен!"); break; }

                        massive = new int[numbers]; // Создаем массив заданного размера

                        Console.WriteLine("Введите элементы массива:");
                        for (int i = 0; i < numbers; i++)
                        {
                            Console.Write($"Элемент {i + 1}: ");
                            massive[i] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    
                    Console.WriteLine("\nВведите число x:");
                    x = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"Индекс последнего вхождения {x} в массиве: {solver.findLast(massive, x)}");
                    break;

                case 17:
                    Console.WriteLine("Ввести собственный массив (В противном случае будет использован [1,2,3,4,2,2,5])? y/n");
                    ch = Console.ReadKey().KeyChar;
                    if (ch == 'y')
                    {
                        Console.WriteLine("\nВведите размер массива:");
                        int numbers = Convert.ToInt32(Console.ReadLine());

                        if (numbers < 0)
                        { Console.WriteLine("ОШИБКА! Размер не введен или массив с заданным размером невозможен!"); break; }

                        massive = new int[numbers]; // Создаем массив заданного размера

                        Console.WriteLine("Введите элементы массива:");
                        for (int i = 0; i < numbers; i++)
                        {
                            Console.Write($"Элемент {i + 1}: ");
                            massive[i] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    Console.WriteLine("\nВведите целое число (значение элемента массива): ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите целое положительное число (индекс элемента массива, в который будет добавлен элемент): ");
                    y = Convert.ToInt32(Console.ReadLine());


                    if ((y >= 0) && (y <= Convert.ToInt32(massive.Length)))
                    {
                        Console.WriteLine($"Массив после добавления переменной:");
                        massive = solver.add(massive, x, y);
                        for (int i = 0; i < Convert.ToInt32(massive.Length); i++)
                        {
                            Console.WriteLine($"[{i}] {massive[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ОШИБКА! Переменная имеет недопустимое значение!");
                    }
                    break;

                case 18:
                    Console.WriteLine("Ввести собственный массив (В противном случае будет использован [1,2,3,4,2,2,5])? y/n");
                    ch = Console.ReadKey().KeyChar;
                    if (ch == 'y')
                    {
                        Console.WriteLine("\nВведите размер массива:");
                        int numbers = Convert.ToInt32(Console.ReadLine());

                        if (numbers < 0)
                        { Console.WriteLine("ОШИБКА! Размер не введен или массив с заданным размером невозможен!"); break; }

                        massive = new int[numbers]; // Создаем массив заданного размера

                        Console.WriteLine("Введите элементы массива:");
                        for (int i = 0; i < numbers; i++)
                        {
                            Console.Write($"Элемент {i + 1}: ");
                            massive[i] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    solver.reverse(massive);
                    break;

                case 19:
                    Console.WriteLine("Ввести собственный массив 1 (В противном случае будет использован [1,2,3,4,2,2,5])? y/n");
                    ch = Console.ReadKey().KeyChar;
                    if (ch == 'y')
                    {
                        Console.WriteLine("\nВведите размер массива:");
                        int numbers = Convert.ToInt32(Console.ReadLine());

                        if (numbers < 0)
                        { Console.WriteLine("ОШИБКА! Размер не введен или массив с заданным размером невозможен!"); break; }

                        massive = new int[numbers]; // Создаем массив заданного размера

                        Console.WriteLine("Введите элементы массива:");
                        for (int i = 0; i < numbers; i++)
                        {
                            Console.Write($"Элемент {i + 1}: ");
                            massive[i] = Convert.ToInt32(Console.ReadLine());
                        }
                    }


                    Console.WriteLine("\nВвести собственный массив 2 (В противном случае будет использован [1,2,3,4,2,2,5])? y/n");
                    ch = Console.ReadKey().KeyChar;
                    if (ch == 'y')
                    {
                        Console.WriteLine("\nВведите размер массива:");
                        int numbers = Convert.ToInt32(Console.ReadLine());

                        if (numbers < 0)
                        { Console.WriteLine("ОШИБКА! Размер не введен или массив с заданным размером невозможен!"); break; }

                        massive2 = new int[numbers]; // Создаем массив заданного размера

                        Console.WriteLine("Введите элементы массива:");
                        for (int i = 0; i < numbers; i++)
                        {
                            Console.Write($"Элемент {i + 1}: ");
                            massive2[i] = Convert.ToInt32(Console.ReadLine());
                        }
                    }

                    massive3 = solver.concat(massive, massive2);

                    Console.WriteLine("\nМассив 1 + Массив 2:");
                    Console.WriteLine($"Массив после добавления переменной:");
                    massive = solver.add(massive, x, y);
                    for (int i = 0; i < Convert.ToInt32(massive3.Length); i++)
                    {
                        Console.WriteLine($"[{i}] {massive3[i]}");
                    }
                    break;

                case 20:
                    Console.WriteLine("Ввести собственный массив (В противном случае будет использован  [-1,2,-3,4,-5,6])? y/n");
                    ch = Console.ReadKey().KeyChar;
                    if (ch == 'y')
                    {
                        Console.WriteLine("\nВведите размер массива:");
                        int numbers = Convert.ToInt32(Console.ReadLine());

                        if (numbers < 0)
                        { Console.WriteLine("ОШИБКА! Размер не введен или массив с заданным размером невозможен!"); break; }

                        massive3 = new int[numbers]; // Создаем массив заданного размера

                        Console.WriteLine("Введите элементы массива:");
                        for (int i = 0; i < numbers; i++)
                        {
                            Console.Write($"Элемент {i + 1}: ");
                            massive3[i] = Convert.ToInt32(Console.ReadLine());
                        }
                    }

                    massive3 = solver.deleteNegative(massive3);

                    Console.WriteLine("\nМассив 1 + Массив 2:");
                    Console.WriteLine($"Массив после добавления переменной:");
                    massive = solver.add(massive, x, y);
                    for (int i = 0; i < Convert.ToInt32(massive3.Length); i++)
                    {
                        Console.WriteLine($"[{i}] {massive3[i]}");
                    }
                    break;

                default:
                    Console.WriteLine("=============================================");
                    Console.WriteLine("ОШИБКА! Номер не введен или задача под заданным номером отсутсвтует!");
                    break;
            }
            if ((choice > 0) && (choice <= 20))
            {
                Console.WriteLine($"===============[{choice}] {number[choice - 1]}===============");
            }
            else
            {
                Console.Write("=============================================");
            }
            Thread.Sleep(5000);
            Console.Clear();
        }
    }
}
