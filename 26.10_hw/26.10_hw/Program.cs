namespace _26._10_hw
{
    class Moderator
    {
        public string ModerateFromFiles(string textFilePath, string wordsFilePath)
        {
            if (!File.Exists(textFilePath) || !File.Exists(wordsFilePath))
            {
                throw new FileNotFoundException("One of the files was not found. Please check the paths.");
            }

            string text = File.ReadAllText(textFilePath);
            string[] wordsToModerate = File.ReadAllLines(wordsFilePath);

            string moderatedText = ModerateText(text, wordsToModerate);

            string directory = Path.GetDirectoryName(textFilePath);
            string resultFilePath = Path.Combine(directory, "resultModerText.txt");

            File.WriteAllText(resultFilePath, moderatedText);

            Console.WriteLine($"\nThe moderated text has been saved to: {resultFilePath}");

            return moderatedText;
        }

        private string ModerateText(string text, string[] wordsToModerate)
        {
            foreach (var word in wordsToModerate)
            {
                text = ReplaceWord(text, word);
            }
            return text;
        }

        private string ReplaceWord(string text, string word)
        {
            string replacement = new string('*', word.Length);
            return text.Replace(word, replacement);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string textFilePath = @"C:\Test\textFile.txt";
                string wordsFilePath = @"C:\Test\textModer.txt";

                Moderator moderator = new Moderator();
                string moderatedText = moderator.ModerateFromFiles(textFilePath, wordsFilePath);

                Console.WriteLine("\nModerated text:");
                Console.WriteLine(moderatedText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
