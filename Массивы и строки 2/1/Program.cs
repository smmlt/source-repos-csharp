using System;
namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            int[] a = new int[5];

            double[,] b = new double[3, 4];

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"Enter number for mas A[{i}]: ");
                a[i] = int.Parse( Console.ReadLine() );
            }

            Random random = new Random();
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = random.NextDouble() * 100;
                }
            }

            Console.WriteLine("Mas A: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Mas B: ");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                Console.WriteLine("-");
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    double circumcision = Math.Round(b[i, j], 2);
                    Console.Write(circumcision + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int maxA = a[0];
            double maxB = b[0, 0];
            foreach (int element in a)
            {
                if (element > maxA){ maxA = element; }
            }
            foreach (double element in b)
            {
                if (element > maxB) { maxB = element; }
            }
            Console.WriteLine($"Common max element: {Math.Round(Math.Max(maxA, maxB), 2)}");

            int minA = a[0];
            double minB = b[0, 0];
            foreach (int element in a)
            {
                if (element < minA) { minA = element; }
            }
            foreach (double element in b)
            {
                if (element < minB) { minB = element; }
            }
            Console.WriteLine($"Common min element: {Math.Round(Math.Min(minA, minB), 2)}");

            int sumA = 0;
            double sumB = 0;
            foreach (int element in a)
            {
                sumA += element;
            }
            foreach (double element in b)
            {
                sumB += element; 
            }
            Console.WriteLine($"Sum all elements: {Math.Round(sumA + sumB, 2)}");

            int productA = 1;
            double productB = 1;
            foreach (int element in a)
            {
                productA += element;
            }
            foreach (double element in b)
            {
                productB += element;
            }
            Console.WriteLine($"Product all elements: {Math.Round(productA * productB, 2)}");

            int sumEvenA = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    sumEvenA += a[i];
                }
            }
            Console.WriteLine($"Sum all even elements in mas A: {sumEvenA}");

            double sumOddB = 0;
            for (int j = 0; j < b.GetLength(1); j += 2) 
            {
                for (int i = 0; i < b.GetLength(0); i++)
                {
                    sumOddB += b[i, j];
                }
            }
            Console.WriteLine($"Sum all odd elements in mas B: {Math.Round(sumOddB, 2)}");

        }
    }
}
