namespace _27._09_сw
{
    internal class Program
    {
        // 1
        static bool IsEven(int number) => number % 2 == 0;
        static bool IsOdd(int number) => number % 2 != 0;
        static bool IsFibonacci(int number)
        {
            if (number < 0) return false;

            int a = 0, b = 1;
            while (a < number)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a == number;
        }

        delegate bool IsNumber(int number);

        static void CheckArray(IsNumber _number, int[] arr)
        {
            foreach (int num in arr)
            {
                if (_number(num))
                {
                    Console.WriteLine(num);
                }
            }
        }

        // 2

        static void ShowCurrentTime()
        {
            Console.WriteLine("Current time: " + DateTime.Now.TimeOfDay);
        }

        static void ShowCurrentDate()
        {
            Console.WriteLine("Current date: " + DateTime.Now.Day);
        }

        static void ShowCurrentDayOfWeek()
        {
            Console.WriteLine("Current day of the week: " + DateTime.Now.DayOfWeek);
        }

        static double CalculateAreaTriangle(double baseLength, double height)
        {
            return baseLength * height / 2;
        }

        static double CalculateAreaRectangle(double width, double height)
        {
            return width * height;
        }

        delegate void DateTimeAction();
        delegate double AreaCalculation(double a, double b);

        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};

            Console.WriteLine("Even numbers: ");
            CheckArray(IsEven, numbers);
            Console.WriteLine();

            Console.WriteLine("Odd numbers: ");
            CheckArray(IsOdd, numbers);
            Console.WriteLine();

            Console.WriteLine("Fibonacci numbers: ");
            CheckArray(IsFibonacci, numbers);
            Console.WriteLine();

            // 2

            DateTimeAction dateTimeAction;

            dateTimeAction = ShowCurrentTime;
            dateTimeAction();

            dateTimeAction = ShowCurrentDate;
            dateTimeAction();

            dateTimeAction = ShowCurrentDayOfWeek;
            dateTimeAction();

            AreaCalculation areaCalculation;

            areaCalculation = CalculateAreaTriangle;
            Console.WriteLine(areaCalculation(5, 10));

            areaCalculation = CalculateAreaRectangle;
            Console.WriteLine(areaCalculation(2, 7));
        }
    }
}
