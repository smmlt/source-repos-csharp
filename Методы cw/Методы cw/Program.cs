namespace Методы_cw
{
    internal class Program
    {
        public static long CalculateProduct(int start, int end)
        {
            long product = 1;
            for (int i = start; i <= end; i++)
            {
                product *= i;
            }
            return product;
              
        }

        static bool IsFibonacci(int n)
        {
            if (n < 0) return false;

            int a = 0;
            int b = 1;

            if (n == a || n == b) return true;

            int c = a + b;
            while (c <= n)
            {
                if (c == n) return true;
                a = b;
                b = c;
                c = a + b;
            }

            return false;
        }
        static void Main(string[] args)
        {
            // 1
            int start = 1;
            int end = 5;
            long product = CalculateProduct(start, end);

            Console.WriteLine($"Product of numbers from {start} to {end}: {product}");


            // 2
            Console.WriteLine("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"Number {number} is {IsFibonacci(number)} number of Fibonacci");
        }
    }
}
