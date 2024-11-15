using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

public static class DataProcessor
{
    public static void Main(string[] args)
    {
        // Цикл для меню задач, который позволяет пользователю выбирать задачи до выхода
        while (true)
        {
            Console.WriteLine("Выберите задачу:");
            Console.WriteLine("1. Количество различных элементов списка");
            Console.WriteLine("2. Замена соседей в LinkedList");
            Console.WriteLine("3. Анализ сельскохозяйственных культур");
            Console.WriteLine("4. Общие символы в словах");
            Console.WriteLine("5. Анализ оценок студентов");
            Console.WriteLine("0. Выход");
            Console.Write("Введите номер задачи (1-5 или 0): ");

            // Переменная для хранения номера задачи
            int taskNumber;
            // Проверка корректности ввода номера задачи
            while (!int.TryParse(Console.ReadLine(), out taskNumber) || taskNumber < 0 || taskNumber > 5)
            {
                Console.WriteLine("Некорректный ввод. Введите номер задачи от 0 до 5.");
                Console.Write("Введите номер задачи (1-5 или 0): ");
            }

            // Если пользователь вводит 0, выходим из программы
            if (taskNumber == 0)
            {
                Console.WriteLine("Выход из программы...");
                return;
            }

            // Запрос на загрузку готовых входных данных
            Console.WriteLine("Загрузить готовые входные данные? (y/n)");
            bool loadSampleData = Console.ReadKey().KeyChar == 'y';
            Console.WriteLine();

            // Выполнение выбранной задачи с обработкой исключений
            try
            {
                switch (taskNumber)
                {
                    case 1:
                        Task1(loadSampleData);
                        break;
                    case 2:
                        Task2(loadSampleData);
                        break;
                    case 3:
                        Task3(loadSampleData);
                        break;
                    case 4:
                        Task4(loadSampleData);
                        break;
                    case 5:
                        Task5(loadSampleData);
                        break;
                    default:
                        Console.WriteLine("Неверный номер задачи.");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений и вывод сообщения об ошибке
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }

    // Метод для подсчета количества различных элементов в списке
    public static int CountDistinctElements<T>(List<T> list)
    {
        return list.Distinct().Count();
    }

    // Метод для замены соседей в LinkedList
    public static void ReplaceNeighbors<T>(LinkedList<T> linkedList, T e, T f)
    {
        LinkedListNode<T> node = linkedList.Find(e);
        if (node != null)
        {
            if (node.Previous != null && node.Next != null && !node.Previous.Value.Equals(node.Next.Value))
            {
                node.Previous.Value = f;
                node.Next.Value = f;
            }
            else if (node.Previous != null && node.Next == null && !node.Previous.Value.Equals(e))
            {
                node.Previous.Value = f;
            }
            else if (node.Previous == null && node.Next != null && !node.Next.Value.Equals(e))
            {
                node.Next.Value = f;
            }
        }
    }

    // Метод для анализа сельскохозяйственных культур
    public static void AnalyzeAgriculturalCultures(HashSet<HashSet<string>> cooperatives)
    {
        HashSet<string> allCrops = new HashSet<string>(); // Хранит все культуры
        foreach (var coop in cooperatives)
        {
            allCrops.UnionWith(coop); // Объединяем культуры из всех кооперативов
        }

        // Вывод культур, возделываемых во всех кооперативах
        Console.WriteLine("Культуры, возделываемые во всех кооперативах:");
        var allInAll = allCrops.Where(c => cooperatives.All(coop => coop.Contains(c)));
        Console.WriteLine(string.Join(", ", allInAll));

        // Вывод культур, возделываемых только в некоторых кооперативах
        Console.WriteLine("\nКультуры, возделываемые только в некоторых кооперативах:");
        var someInSome = allCrops.Where(c => cooperatives.Any(coop => coop.Contains(c)) && !allInAll.Contains(c));
        Console.WriteLine(string.Join(", ", someInSome));

        // Вывод культур, возделываемых ровно в одном кооперативе
        Console.WriteLine("\nКультуры, возделываемые ровно в одном кооперативе:");
        var oneInOne = allCrops.Where(c => cooperatives.Count(coop => coop.Contains(c)) == 1);
        Console.WriteLine(string.Join(", ", oneInOne));
    }

    // Метод для нахождения общих символов в словах из файла
    public static HashSet<char> CommonCharsInWords(string filePath)
    {
        try
        {
            // Чтение текста из файла
            string text = File.ReadAllText(filePath);
            string[] words = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0) return new HashSet<char>(); // Если слов нет, возвращаем пустой HashSet

            HashSet<char> commonChars = new HashSet<char>(words[0].Where(char.IsLetter)); // Инициализация общими символами из первого слова

            // Пересечение символов из остальных слов
            foreach (string word in words.Skip(1))
            {
                commonChars.IntersectWith(word.Where(char.IsLetter));
            }

            return commonChars; // Возвращаем общий набор символов
        }
        catch (FileNotFoundException)
        {
            // Обработка случая, когда файл не найден
            Console.WriteLine($"Файл {filePath} не найден.");
            return new HashSet<char>(); // Возвращаем пустой HashSet в случае ошибки
        }
        catch (Exception ex)
        {
            // Обработка других исключений
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
            return new HashSet<char>(); // Возвращаем пустой HashSet в случае ошибки
        }
    }

    // Метод для анализа оценок студентов
    public static void AnalyzeStudentScores(List<Student> students)
    {
        // Проверка наличия достаточного количества студентов
        if (students == null || students.Count < 5)
        {
            Console.WriteLine("Недостаточно данных для анализа (необходимо минимум 5 студентов).");
            return;
        }

        // Проверка корректности данных студентов
        if (!students.All(s => s.School >= 1 && s.School <= 99 && s.Score >= 1 && s.Score <= 100 &&
                                 !string.IsNullOrWhiteSpace(s.LastName) && !string.IsNullOrWhiteSpace(s.FirstName) &&
                                 s.LastName.Length <= 20 && s.FirstName.Length <= 20 && !s.LastName.Contains(" ") && !s.FirstName.Contains(" ")))
        {
            Console.WriteLine("Некорректные данные в списке студентов. Проверьте формат.");
            return;
        }

        // Группировка студентов по школам
        var scoresBySchool = students.GroupBy(s => s.School);
        double averageScoreOverall = students.Average(s => s.Score); // Средний балл по всем студентам

        // Находим школы со средним баллом выше среднего по району
        var schoolsAboveAverage = scoresBySchool
            .Where(g => g.Count() >= 5 && g.Average(s => s.Score) > averageScoreOverall)
            .Select(g => g.Key)
            .ToList();

        // Вывод результатов анализа
        if (schoolsAboveAverage.Count > 0)
        {
            Console.WriteLine("Школы со средним баллом выше среднего по району:");
            Console.WriteLine(string.Join(" ", schoolsAboveAverage));
            if (schoolsAboveAverage.Count == 1)
            {
                double avg = scoresBySchool.First(g => g.Key == schoolsAboveAverage[0]).Average(s => s.Score);
                Console.WriteLine($"Средний балл в школе {schoolsAboveAverage[0]}: {avg}");
            }
        }
        else
        {
            Console.WriteLine("Нет школ со средним баллом выше среднего по району.");
        }
    }

    // Примерные данные для тестирования
    private static List<int> GetSampleList1()
    {
        Console.WriteLine("Входные данные по умолчанию: 1, 2, 2, 3, 4, 4, 4, 5, 5 ");
        return new List<int> { 1, 2, 2, 3, 4, 4, 4, 5, 5 }; // Пример списка
    }

    private static LinkedList<int> GetSampleLinkedList1()
    {
        Console.WriteLine("Входные данные по умолчанию:  1, 2, 3, 4, 5 ");
        return new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 }); // Пример LinkedList
    }

    private static HashSet<HashSet<string>> GetSampleCooperatives()
    {
        Console.WriteLine("Входные дынные по умолчанию: \nHashSet<HashSet<string>> cooperatives = new HashSet<HashSet<string>>();\r\n        cooperatives.Add(new HashSet<string>() { \"пшеница\", \"рожь\", \"овес\" });\r\n        cooperatives.Add(new HashSet<string>() { \"пшеница\", \"кукуруза\", \"соя\" });\r\n        cooperatives.Add(new HashSet<string>() { \"рожь\", \"гречиха\", \"овес\" });");
        // Пример данных для кооперативов
        HashSet<HashSet<string>> cooperatives = new HashSet<HashSet<string>>();
        cooperatives.Add(new HashSet<string>() { "пшеница", "рожь", "овес" });
        cooperatives.Add(new HashSet<string>() { "пшеница", "кукуруза", "соя" });
        cooperatives.Add(new HashSet<string>() { "рожь", "гречиха", "овес" });
        return cooperatives;
    }

    private static List<Student> GetSampleStudents()
    {
        Console.WriteLine("new Student { LastName = \"Иванов\", FirstName = \"Иван\", School = 12, Score = 85 },\r\n            new Student { LastName = \"Петров\", FirstName = \"Петр\", School = 18, Score = 92 },\r\n            new Student { LastName = \"Сидоров\", FirstName = \"Сидор\", School = 12, Score = 78 },\r\n            new Student { LastName = \"Васильев\", FirstName = \"Василий\", School = 18, Score = 89 },\r\n            new Student { LastName = \"Смирнов\", FirstName = \"Сергей\", School = 12, Score = 94 },\r\n            new Student { LastName = \"Попов\", FirstName = \"Павел\", School = 18, Score = 82 },\r\n            new Student { LastName = \"Козлов\", FirstName = \"Константин\", School = 12, Score = 87 },\r\n            new Student { LastName = \"Соколов\", FirstName = \"Александр\", School = 18, Score = 90 },\r\n            new Student { LastName = \"Михайлов\", FirstName = \"Михаил\", School = 12, Score = 83 },\r\n            new Student { LastName = \"Новиков\", FirstName = \"Алексей\", School = 18, Score = 86 },");
        // Пример данных о студентах
        return new List<Student>
        {
            new Student { LastName = "Иванов", FirstName = "Иван", School = 12, Score = 85 },
            new Student { LastName = "Петров", FirstName = "Петр", School = 18, Score = 92 },
            new Student { LastName = "Сидоров", FirstName = "Сидор", School = 12, Score = 78 },
            new Student { LastName = "Васильев", FirstName = "Василий", School = 18, Score = 89 },
            new Student { LastName = "Смирнов", FirstName = "Сергей", School = 12, Score = 94 },
            new Student { LastName = "Попов", FirstName = "Павел", School = 18, Score = 82 },
            new Student { LastName = "Козлов", FirstName = "Константин", School = 12, Score = 87 },
            new Student { LastName = "Соколов", FirstName = "Александр", School = 18, Score = 90 },
            new Student { LastName = "Михайлов", FirstName = "Михаил", School = 12, Score = 83 },
            new Student { LastName = "Новиков", FirstName = "Алексей", School = 18, Score = 86 },
        };
    }

    // Метод для выполнения задачи 1
    private static void Task1(bool loadSampleData)
    {
        List<int> list; // Явно указываем тип int
        if (loadSampleData)
        {
            list = GetSampleList1();
        }
        else
        {
            list = GetListFromUser<int>(); // Теперь явно указываем тип int
        }
        int distinctElementsCount = CountDistinctElements(list);
        Console.WriteLine($"Количество различных элементов: {distinctElementsCount}");
    }

    // Метод для выполнения задачи 2
    private static void Task2(bool loadSampleData)
    {
        LinkedList<int> linkedList; // Объявление типа int явно
        if (loadSampleData)
        {
            linkedList = GetSampleLinkedList1();
        }
        else
        {
            linkedList = GetLinkedListFromUser<int>(); // Указание типа int
        }

        Console.WriteLine("Введите E: ");
        int e = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите F: ");
        int f = int.Parse(Console.ReadLine());
        ReplaceNeighbors(linkedList, e, f);
        Console.WriteLine($"Связный список после замены: {string.Join(", ", linkedList)}");
    }

    // Метод для выполнения задачи 3
    private static void Task3(bool loadSampleData)
    {
        int n = loadSampleData ? 3 : GetIntInput("Введите количество кооперативов:", 1, int.MaxValue); // Получение количества кооперативов
        HashSet<HashSet<string>> cooperatives = loadSampleData ? GetSampleCooperatives() : GetCooperativesFromUser(n); // Получение данных о кооперативах
        AnalyzeAgriculturalCultures(cooperatives); // Анализ культур
    }

    // Метод для выполнения задачи 4
    private static void Task4(bool loadSampleData)
    {
        Console.WriteLine("Введите путь к файлу: ");
        string filePath = loadSampleData ? @"default_text.txt" : Console.ReadLine(); // Получение пути к файлу
        HashSet<char> commonChars = CommonCharsInWords(filePath); // Получение общих символов
        Console.WriteLine($"Общие символы во всех словах: {string.Join(", ", commonChars)}");
    }

    // Метод для выполнения задачи 5
    private static void Task5(bool loadSampleData)
    {
        List<Student> students = loadSampleData ? GetSampleStudents() : GetStudentsFromUser(); // Получение данных о студентах
        AnalyzeStudentScores(students); // Анализ оценок студентов

        // Сериализация данных о студентах в XML
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream("students.xml", FileMode.Create))
            {
                serializer.Serialize(fs, students); // Сохранение данных в файл
            }

            // Вывод сообщения об успешной записи
            Console.WriteLine("Данные о студентах сохранены в файле students.xml");
        }
        catch (Exception ex)
        {
            // Обработка ошибок при сохранении
            Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
        }
    }

    // Методы для получения входных данных от пользователя
    private static List<T> GetListFromUser<T>()
    {
        Console.WriteLine($"Введите элементы списка типа {typeof(T).Name}, разделенные запятыми:");
        string input = Console.ReadLine();
        try
        {
            return input.Split(',').Select(x => (T)Convert.ChangeType(x.Trim(), typeof(T))).ToList();
        }
        catch (FormatException)
        {
            Console.WriteLine("Некорректный формат ввода.");
            return new List<T>();
        }
        catch (InvalidCastException)
        {
            Console.WriteLine($"Невозможно преобразовать ввод в тип {typeof(T).Name}");
            return new List<T>();
        }
    }

    private static LinkedList<T> GetLinkedListFromUser<T>()
    {
        Console.WriteLine($"Введите элементы LinkedList типа {typeof(T).Name}, разделенные запятыми:");
        string input = Console.ReadLine();
        try
        {
            return new LinkedList<T>(input.Split(',').Select(x => (T)Convert.ChangeType(x.Trim(), typeof(T))).ToList());
        }
        catch (FormatException)
        {
            Console.WriteLine("Некорректный формат ввода.");
            return new LinkedList<T>(); // Возвращаем пустой список при ошибке
        }
        catch (InvalidCastException)
        {
            Console.WriteLine($"Невозможно преобразовать ввод в тип {typeof(T).Name}");
            return new LinkedList<T>();
        }
    }

    private static HashSet<HashSet<string>> GetCooperativesFromUser(int numCooperatives)
    {
        HashSet<HashSet<string>> cooperatives = new HashSet<HashSet<string>>();
        for (int i = 0; i < numCooperatives; i++)
        {
            Console.WriteLine($"Введите культуры для кооператива {i + 1}, разделенные запятыми (например, пшеница,рожь,овес):");
            string input = Console.ReadLine();
            cooperatives.Add(new HashSet<string>(input.Split(',').Select(s => s.Trim()))); // Добавление культур кооператива
        }
        return cooperatives; // Возвращаем все кооперативы
    }

    private static List<Student> GetStudentsFromUser()
    {
        Console.WriteLine("Введите количество студентов:");
        int studentCount = GetIntInput("Количество студентов", 1, int.MaxValue); // Получение количества студентов

        List<Student> students = new List<Student>();
        for (int i = 0; i < studentCount; i++)
        {
            students.Add(GetStudentDataFromConsole($"Студент {i + 1}")); // Получение данных о каждом студенте
        }
        return students; // Возвращаем список студентов
    }

    private static Student GetStudentDataFromConsole(string studentNumber)
    {
        Console.WriteLine($"Введите данные для {studentNumber}:");
        string lastName = GetStringInput("Фамилия:", 20); // Получение фамилии
        string firstName = GetStringInput("Имя:", 20); // Получение имени
        int school = GetIntInput("Школа (1-99):", 1, 99); // Получение номера школы
        int score = GetIntInput("Балл (1-100):", 1, 100); // Получение балла
        return new Student
        {
            LastName = lastName,
            FirstName = firstName,
            School = school,
            Score = score
        };
    }

    // Метод для получения строкового ввода с проверкой длины
    private static string GetStringInput(string prompt, int maxLength)
    {
        string input;
        do
        {
            Console.Write($"{prompt} (макс. {maxLength} символов): ");
            input = Console.ReadLine();
            // Проверка на корректность ввода
            if (string.IsNullOrWhiteSpace(input) || input.Length > maxLength || input.Contains(' '))
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
            }
        } while (string.IsNullOrWhiteSpace(input) || input.Length > maxLength || input.Contains(' '));
        return input; // Возвращаем корректный ввод
    }

    // Метод для получения целочисленного ввода с проверкой диапазона
    private static int GetIntInput(string prompt, int min, int max)
    {
        int input;
        do
        {
            Console.Write($"{prompt}: ");
            // Проверка на корректность ввода
            if (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                Console.WriteLine($"Некорректный ввод. Введите число от {min} до {max}.");
            }
        } while (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max);
        return input; // Возвращаем корректный ввод
    }

    // Метод для парсинга строкового ввода с числами, разделенными запятыми
    private static List<int> ParseCommaSeparatedIntegers(string input)
    {
        try
        {
            return input.Split(',')
                        .Select(s => int.Parse(s.Trim())) // Парсинг и удаление пробелов
                        .ToList(); // Возвращаем список целых чисел
        }
        catch (FormatException)
        {
            // Обработка ошибки формата
            Console.WriteLine("Некорректный формат ввода. Введите числа через запятую.");
            return new List<int>(); // Возвращаем пустой список в случае ошибки
        }
        catch (Exception ex)
        {
            // Обработка других исключений
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
            return new List<int>(); // Возвращаем пустой список в случае ошибки
        }
    }

    // Класс для представления студента
    [Serializable]
    public class Student
    {
        public string LastName { get; set; } // Фамилия студента
        public string FirstName { get; set; } // Имя студента
        public int School { get; set; } // Номер школы
        public int Score { get; set; } // Балл студента
    }
}
