namespace _17._10_hw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 10, -1, -2, 3, -1, -7, 5, -2, -3, 7, -3, -10 };

            Func<int[], int[]> uniqueNumbers = myArray =>
            {
                int[] uniqueNegativeNumbers = new int[myArray.Length];
                int uniqueCount = 0;

                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] < 0)
                    {
                        bool isUnique = true;

                        for (int j = 0; j < myArray.Length; j++)
                        {
                            if (i != j && myArray[i] == myArray[j])
                            {
                                isUnique = false;
                                break;
                            }
                        }
                        if (isUnique)
                        {
                            uniqueNegativeNumbers[uniqueCount] = myArray[i];
                            uniqueCount++;
                        }
                    }
                }

                Array.Resize(ref uniqueNegativeNumbers, uniqueCount);
                return uniqueNegativeNumbers;
            };

            int[] result = uniqueNumbers(numbers);

            Console.WriteLine("Unique negativ numbers:");
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
        }
    }
}
