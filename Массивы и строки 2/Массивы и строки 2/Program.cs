namespace Массивы_и_строки_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2
            int[,] ints = new int[5, 5];
            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;

            Random random = new Random();
            for(int i = 0; i < ints.GetLength(0); i++) // я не запомнил обязательно через .GetLength() или можно через .Length
            {
                for(int j = 0; j < ints.GetLength(1); j++)
                {
                    ints[i, j] = random.Next(-10, 10);
                    Console.Write(ints[ i, j] + " | ");

                    if (ints[i, j] > maxNumber) { maxNumber = ints[i, j]; }

                    if (ints[i, j] < minNumber) { minNumber = ints[i, j]; }

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Min value: {minNumber}");
            Console.WriteLine($"Max value: {maxNumber}");

            int sum = 0;
            bool is_between = false;

            for (int i = 0; i < ints.GetLength(0); i++)
            {
                for (int j = 0; j < ints.GetLength(1); j++)
                {
                    if (ints[i, j] == minNumber || ints[i, j] == maxNumber)
                    {
                        is_between = true;
                    }

                    if (is_between)
                    {
                        sum += ints[i, j];
                    }
                }
            }
            Console.WriteLine($"Sum of elements between min and max values: {sum}");

        }
    }
}
