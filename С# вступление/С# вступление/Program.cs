namespace С__вступление
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("\tIt's easy to win forgiveness for being wrong;\v\tbeing right is what gets you into real trouble.\v\tBjarne Stroustrup");

            // 2
            int sum = 0;
            int product = 1;
            int max = int.MinValue;
            int min = int.MaxValue;

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter numbers {i}: ");
                int number = int.Parse(Console.ReadLine());

                sum += number;
                product *= number;

                if (number > max)
                {
                    max = number;
                }
                if (number < min)
                {
                    min = number;
                }
            }

            Console.WriteLine($"Sum of numbers: {sum}");
            Console.WriteLine($"Product of numbers: {product}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
        }
    }
}
