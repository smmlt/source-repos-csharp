namespace _15._01._2025_cw
{
    internal class Program
    {


        /*static int CountDigits(int n)
        {
            return n.ToString().Length;
        }

        static int SumDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }*/

        static void MultiplicationTable(int number)
        {
            Console.WriteLine($"\nTable for {number}:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{number} x {i} = {number * i}");
            }
        }
        static void CalculateFactorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"factorial({n}) = {result};");
        }

        static void Main(string[] args)
        {

            List<int> numbers = File.ReadAllLines("nums.txt").ToList().ConvertAll(int.Parse);
            Parallel.ForEach(numbers, CalculateFactorial);

            Console.WriteLine("Enter the start of the range:");
            int start = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the end of the range:");
            int end = int.Parse(Console.ReadLine());
            Parallel.For(start, end + 1, MultiplicationTable);


            /*int number = 12;

            Parallel.Invoke(
                () => Console.WriteLine(CalculateFactorial(number)),
                () => Console.WriteLine(CountDigits(number)),
                () => Console.WriteLine(SumDigits(number))
            );*/

        }
    }
}
