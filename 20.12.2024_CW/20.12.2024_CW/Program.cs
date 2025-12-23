using System.Threading;

namespace _20._12._2024_CW
{
    internal class Program
    {
        // 1, 2
        /*
        static void Fun(object obj)
        {
            int[] range = (int[])obj;
            int start = range[0];
            int end = range[1];

            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }*/

        // 4
        static int[] numbers;
        static int max;
        static int min;
        static double average;

        static string filePath = "C:\\Users\\Bohdan\\source\\repos\\20.12.2024_CW\\value.txt";

        static void RandomNum()
        {
            Random random = new Random();
            numbers = new int[10000];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 10001);
            }
            Console.WriteLine("numbers generated.");
        }

        static void FindMax()
        {
            max = numbers.Max();
            Console.WriteLine($"Maximum: {max}");
        }

        static void FindMin()
        {
            min = numbers.Min();
            Console.WriteLine($"Minimum: {min}");
        }
        static void FindAverage()
        {
            average = numbers.Average();
            Console.WriteLine($"Average: {average}");
        }

        // 5
        static void WriteToFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Generated Numbers:");
                foreach (var number in numbers)
                {
                    sw.WriteLine(number);
                }
                sw.WriteLine();
                sw.WriteLine($"Maximum: {max}");
                sw.WriteLine($"Minimum: {min}");
                sw.WriteLine($"Average: {average}");
            }

            
        }

        static void Main(string[] args)
        {
            // 1, 2
            /*
            Console.WriteLine("Enter the start of the range: ");
            int start = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the end of the range: ");
            int end = int.Parse(Console.ReadLine());


            Thread t1 = new Thread(Fun);
            t1.Start(new int[] { start, end });*/


            // 4
            Thread generateThread = new Thread(RandomNum);
            generateThread.Start();
            generateThread.Join();


            Thread maxThread = new Thread(FindMax);
            Thread minThread = new Thread(FindMin);
            Thread avgThread = new Thread(FindAverage);

            maxThread.Start();
            maxThread.Join();
            
            minThread.Start();
            minThread.Join();
            
            avgThread.Start();
            avgThread.Join();

            // 5
            Thread writeThread = new Thread(WriteToFile);
            writeThread.Start();
            writeThread.Join();

            Console.WriteLine("Completed");
        }
    }
}
