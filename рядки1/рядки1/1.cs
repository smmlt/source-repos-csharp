namespace рядки1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("Enter text: ");
            string? str1 = Console.ReadLine();

            string[] word = str1.Split(new char[] { ' ', ',', '.', '!', '?'}, 
                StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"Word count: {word.Length}");

            int vowels = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == 'a' || str1[i] == 'e' || str1[i] == 'y' || str1[i] == 'i' || str1[i] == 'o' || str1[i] == 'u')
                {
                    vowels++;
                }
            }
            Console.WriteLine($"Vowels count: {vowels}");
        }
    }
}
