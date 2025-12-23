namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");
            string? str1 = Console.ReadLine();

            string[] word = str1.Split(new char[] { ' ', ',', '.', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries);

            char[] reverse;
            for (int i = 0; i < word.Length; i++)
            {
                reverse = word[i].ToCharArray();
                Array.Reverse(reverse);
                word[i] = new string(reverse);
            }
            str1 = string.Join(" ", word);
            Console.WriteLine(str1);
        }
    }
}
