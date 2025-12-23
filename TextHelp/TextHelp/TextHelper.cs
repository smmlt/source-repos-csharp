namespace TextHelp
{
    public class TextHelper
    {
        public static bool IsPalindrome(string _text)
        {
            string cleanText = _text.Replace(" ", "").ToLower();
            char[] reversedText = cleanText.ToCharArray();
            Array.Reverse(reversedText);
            return cleanText == new string(reversedText);
        }

        public static int CountSentences(string text)
        {
            char[] sentenceDelimiters = new char[] { '.', '!', '?', ';' };
            string[] sentences = text.Split(sentenceDelimiters, StringSplitOptions.RemoveEmptyEntries);
            return sentences.Length;
        }

        public static string MyReverse(string text)
        {
            char[] reversed = text.ToCharArray();
            Array.Reverse(reversed);
            string comletedText = new string(reversed);
            return comletedText;
        }
    }
}
