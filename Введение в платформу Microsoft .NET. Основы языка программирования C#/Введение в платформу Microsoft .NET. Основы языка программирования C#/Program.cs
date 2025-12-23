namespace Введение_в_платформу_Microsoft_.NET._Основы_языка_программирования_C_;

class Program
{
    static void Main(string[] args)
    {
        // 1
        Console.WriteLine("Enter a number from 1 to 100:");
        int number = int.Parse(Console.ReadLine());

        if (number < 1 || number > 100)
        {
            Console.WriteLine("Error: please enter a number in the range of 1 to 100.");
        }
        else
        {
            if (number % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (number % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else if (number % 3 == 0 && number % 5 == 0)
            {
                Console.WriteLine("Fizz Buzz");
            }

            else
            {
                Console.WriteLine(number);
            }
        }

        // 2
        Console.WriteLine("Enter value:");
        int value = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter percent:");
        int percent = int.Parse(Console.ReadLine());

        int result = (value * percent) / 100;

        Console.WriteLine($"{percent}% of {value} is {result}");

        // 3
        string numbers = "";

        for (int i = 0; i <= 3; i++)
        {
            Console.WriteLine($"Enter number {i}:");
            string number = Console.ReadLine();

            numbers += number;
        }

        int resultNumber = int.Parse(numbers);

        Console.WriteLine($"Result: {resultNumber}");
    }
}
