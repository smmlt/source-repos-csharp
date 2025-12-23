namespace _29._01._2025_hw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "C:\\Users\\Bohdan\\Desktop\\test12.txt";
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    return;
                }

                var numbers = File.ReadAllLines(filePath)
                                  .SelectMany(line => line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                                  .Select(int.Parse)
                                  .ToList();

                Console.WriteLine($"Loaded numbers: {string.Join(", ", numbers)}");

                var uniqueNumbers = numbers
                    .AsParallel()
                    .GroupBy(n => n)
                    .Where(g => g.Count() == 1)
                    .Select(g => g.Key)
                    .ToList();

                Console.Write($"Unique values: {string.Join(", ", uniqueNumbers)}");
                Console.WriteLine($"\nNumber of unique values: {uniqueNumbers.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
