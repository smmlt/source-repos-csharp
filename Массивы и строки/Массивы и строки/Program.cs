namespace Массивы_и_строки
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();

            string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sentences.Length; i++)
            {
                string sentence = sentences[i].Trim();

                if (!string.IsNullOrEmpty(sentence))
                {
                    sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);
                }
                sentences[i] = sentence;
            }

            string result = string.Join(" ", sentences);

            Console.WriteLine($"Result: {result}");
        }
    }
}
