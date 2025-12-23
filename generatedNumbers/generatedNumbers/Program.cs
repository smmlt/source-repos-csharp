using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Количество возможных комбинаций для 4-значных чисел
    static int totalCombinations = 10000;

    // Для хранения сгенерированных чисел и их количества
    static Dictionary<int, (int id, int count)> generatedNumbers = new Dictionary<int, (int id, int count)>();
    static Dictionary<int, (int id, int count)> userDefinedNumbers = new Dictionary<int, (int id, int count)>();

    static Random random = new Random();
    static int uniqueId = 1;

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Начать генерацию и запись всех комбинаций (10000)");
            Console.WriteLine("2. Генерировать указанное количество комбинаций");
            Console.WriteLine("3. Показать все сгенерированные числа (10000)");
            Console.WriteLine("4. Показать все сгенерированные числа (пользовательские)");
            Console.WriteLine("5. Показать самое частое число (10000)");
            Console.WriteLine("6. Показать самое редкое число (10000)");
            Console.WriteLine("7. Показать самое частое число (пользовательские)");
            Console.WriteLine("8. Показать самое редкое число (пользовательские)");
            Console.WriteLine("9. Выход");

            Console.Write("Выберите пункт меню: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartGeneration();
                    break;
                case "2":
                    GenerateUserDefinedCombinations();
                    break;
                case "3":
                    ShowAllGeneratedNumbers(generatedNumbers);
                    break;
                case "4":
                    ShowAllGeneratedNumbers(userDefinedNumbers);
                    break;
                case "5":
                    ShowMostFrequentNumbers(generatedNumbers);
                    break;
                case "6":
                    ShowLeastFrequentNumbers(generatedNumbers);
                    break;
                case "7":
                    ShowMostFrequentNumbers(userDefinedNumbers);
                    break;
                case "8":
                    ShowLeastFrequentNumbers(userDefinedNumbers);
                    break;
                case "9":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    // Метод для генерации и записи всех комбинаций
    static void StartGeneration()
    {
        Console.WriteLine("Начинается генерация чисел...");

        // Очищаем прошлые результаты
        generatedNumbers.Clear();
        uniqueId = 1;

        // Генерация всех комбинаций
        while (generatedNumbers.Count < totalCombinations)
        {
            int randomNumber = random.Next(0, 10000); // Случайное число от 0000 до 9999

            if (!generatedNumbers.ContainsKey(randomNumber))
            {
                generatedNumbers[randomNumber] = (uniqueId, 1); // Добавляем новое число с уникальным ID
                uniqueId++;
            }
            else
            {
                generatedNumbers[randomNumber] = (generatedNumbers[randomNumber].id, generatedNumbers[randomNumber].count + 1); // Увеличиваем количество
            }
        }

        Console.WriteLine("Генерация завершена!");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
        Console.ReadKey();
    }

    // Метод для генерации указанного количества комбинаций
    static void GenerateUserDefinedCombinations()
    {
        Console.Write("Введите количество комбинаций для генерации: ");
        if (int.TryParse(Console.ReadLine(), out int numberToGenerate) && numberToGenerate > 0)
        {
            Console.WriteLine($"Начинается генерация {numberToGenerate} чисел...");

            // Очищаем прошлые результаты
            userDefinedNumbers.Clear();
            uniqueId = 1;

            int generatedCount = 0;

            while (generatedCount < numberToGenerate)
            {
                int randomNumber = random.Next(0, 10000); // Случайное число от 0000 до 9999

                // Если число новое, добавляем его
                if (!userDefinedNumbers.ContainsKey(randomNumber))
                {
                    userDefinedNumbers[randomNumber] = (uniqueId, 1); // Добавляем новое число с уникальным ID
                    uniqueId++;
                    generatedCount++;
                }
                else
                {
                    // Увеличиваем счетчик для уже существующего числа
                    userDefinedNumbers[randomNumber] = (userDefinedNumbers[randomNumber].id, userDefinedNumbers[randomNumber].count + 1);
                    generatedCount++;
                }
            }

            Console.WriteLine("Генерация завершена!");
        }
        else
        {
            Console.WriteLine("Некорректное количество. Пожалуйста, введите положительное число.");
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
        Console.ReadKey();
    }

    // Метод для показа всех сгенерированных чисел
    static void ShowAllGeneratedNumbers(Dictionary<int, (int id, int count)> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("Числа еще не были сгенерированы. Сначала начните генерацию.");
        }
        else
        {
            foreach (var entry in numbers)
            {
                Console.WriteLine($"ID: {entry.Value.id}, Число: {entry.Key:D4}, Количество раз: {entry.Value.count}");
            }
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
        Console.ReadKey();
    }

    // Метод для нахождения всех самых частых чисел
    static void ShowMostFrequentNumbers(Dictionary<int, (int id, int count)> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("Числа еще не были сгенерированы. Сначала начните генерацию.");
        }
        else
        {
            // Находим максимальное количество появлений
            int maxCount = numbers.Max(x => x.Value.count);
            var mostFrequentNumbers = numbers.Where(x => x.Value.count == maxCount);

            Console.WriteLine("Самые частые числа:");
            foreach (var entry in mostFrequentNumbers)
            {
                Console.WriteLine($"{entry.Key:D4}: {entry.Value.count} раз(а)");
            }
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
        Console.ReadKey();
    }

    // Метод для нахождения всех самых редких чисел
    static void ShowLeastFrequentNumbers(Dictionary<int, (int id, int count)> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("Числа еще не были сгенерированы. Сначала начните генерацию.");
        }
        else
        {
            // Находим минимальное количество появлений
            int minCount = numbers.Min(x => x.Value.count);
            var leastFrequentNumbers = numbers.Where(x => x.Value.count == minCount);

            Console.WriteLine("Самые редкие числа:");
            foreach (var entry in leastFrequentNumbers)
            {
                Console.WriteLine($"{entry.Key:D4}: {entry.Value.count} раз(а)");
            }
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню...");
        Console.ReadKey();
    }
}

