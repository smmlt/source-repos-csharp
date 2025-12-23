namespace _24._01._2025_hw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 3, 8, 3, 9, 1, 5, 6, 7, 8, -1, 123, 2, 3, 345, 2546, 257, 573, 568, 675, 324, 465, 54, 345, };
            Console.Write("Array: ");
            foreach (var i in array)
            {
                Console.Write(i + " ");
            }

            Task.Run(() =>
            {

                var uniqueArray = array.Distinct().ToArray();
                Console.WriteLine("\nRemoving duplicates...");

                Array.Sort(uniqueArray);
                Console.WriteLine("Sorting the array...");

                Console.Write("Sorted array: ");
                foreach (var i in uniqueArray)
                {
                    Console.Write(i + " ");
                }

                int valueToFind = 6;
                int index = Array.BinarySearch(uniqueArray, valueToFind);

                if (index >= 0)
                    Console.WriteLine($"\nValue {valueToFind} found at index {index}.");
                else
                    Console.WriteLine($"\nValue {valueToFind} not found.");
            }).Wait();
        }
    }
}
