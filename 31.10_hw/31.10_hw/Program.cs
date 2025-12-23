namespace _31._10_hw
{
    public class FileStatistics
    {
        public int SentenceCount { get; private set; }
        public int UpperCaseCount { get; private set; }
        public int LowerCaseCount { get; private set; }
        public int VowelCount { get; private set; }
        public int ConsonantCount { get; private set; }
        public int DigitCount { get; private set; }

        public FileStatistics(string text)
        {
            SentenceCount = CountSentences(text);
            UpperCaseCount = CountUpperCaseLetters(text);
            LowerCaseCount = CountLowerCaseLetters(text);
            VowelCount = CountVowels(text);
            ConsonantCount = CountConsonants(text);
            DigitCount = CountDigits(text);
        }

        private int CountSentences(string text)
        {
            char[] sentenceEndings = { '.', '!', '?' };
            return text.Split(sentenceEndings, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private int CountUpperCaseLetters(string text)
        {
            return text.Count(char.IsUpper);
        }

        private int CountLowerCaseLetters(string text)
        {
            return text.Count(char.IsLower);
        }

        private int CountVowels(string text)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y',
                          'A', 'E', 'I', 'O', 'U', 'Y' };
            return text.Count(c => vowels.Contains(c));
        }

        private int CountConsonants(string text)
        {
            char[] consonants = { 'b', 'c', 'd', 'f', 'g', 'h',
                              'j', 'k', 'l', 'm', 'n', 'p',
                              'q', 'r', 's', 't', 'v', 'w',
                              'x', 'z',
                              'B', 'C', 'D', 'F', 'G', 'H',
                              'J', 'K', 'L', 'M', 'N', 'P',
                              'Q', 'R', 'S', 'T', 'V', 'W',
                              'X', 'Z' };
            return text.Count(c => consonants.Contains(c));
        }

        private int CountDigits(string text)
        {
            return text.Count(char.IsDigit);
        }

        public void DisplayStatistics()
        {
            Console.WriteLine($"Number of sentences: {SentenceCount}");
            Console.WriteLine($"Number of uppercase letters: {UpperCaseCount}");
            Console.WriteLine($"Number of lowercase letters: {LowerCaseCount}");
            Console.WriteLine($"Number of vowels: {VowelCount}");
            Console.WriteLine($"Number of consonants: {ConsonantCount}");
            Console.WriteLine($"Number of digits: {DigitCount}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Test\textForAnaliz.txt";

            try
            {
                string text = File.ReadAllText(filePath);

                FileStatistics statistics = new FileStatistics(text);

                statistics.DisplayStatistics();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
