namespace методы_1
{
    internal class Program
    {
        public static void Square(int sideLength, char symbol)
        {
            for (int i = 0; i < sideLength; i++)
            {
                for (int j = 0; j < sideLength; j++)
                {
                    Console.Write(symbol + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool IsPalindrome(int number)
        {
            string numberStr = number.ToString();

            bool isPalindrome = true;

            for (int i = 0; i < numberStr.Length / 2; i++)
            {
                if (numberStr[i] != numberStr[numberStr.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }

        static int[] FilterArray(int[] originalArray, int[] filterForArray)
        {
            int[] filteredArray = new int[originalArray.Length];
            int filteredIndex = 0;

            foreach (int num in originalArray)
            {
                if (!filterForArray.Contains(num))
                {
                    filteredArray[filteredIndex] = num;
                    filteredIndex++;
                }
            }

            int[] resultArray = new int[filteredIndex];
            Array.Copy(filteredArray, resultArray, filteredIndex);

            return resultArray;
        }
        static void Main(string[] args)
        {
            // 1
            int sideLength = 5;
            char symbol = '*';

            Square(sideLength, symbol);
            Console.WriteLine();

            // 2 
            int number1 = 1221;
            int number2 = 3443;
            int number3 = 7854;

            Console.WriteLine($"{number1} is palindrome: {IsPalindrome(number1)}");
            Console.WriteLine($"{number2} is palindrome: {IsPalindrome(number2)}");
            Console.WriteLine($"{number3} is palindrome: {IsPalindrome(number3)}");
            Console.WriteLine();

            // 3
            int[] originalArray = { 1, 2, 6, -1, 88, 7, 6 };
            int[] filterForArray = { 6, 88, 7 };

            int[] filteredArray = FilterArray(originalArray, filterForArray);

            Console.WriteLine("Array after filtering: ");
            foreach (int num in filteredArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

        }
    }
}
