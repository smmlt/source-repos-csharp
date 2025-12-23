namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");
            string str1 = Console.ReadLine();

            string[] word = str1.Split(new char[] { ' ', ',', '.', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Enter word for find: ");
            string str2 = Console.ReadLine();

            int count = 0;
            foreach (string i in word)
            {
                if (i.ToLower().Contains(str2))
                {
                    count++;
                }
            }
            Console.WriteLine($"Word {str2} was found {count} times");
        }
    }
}
