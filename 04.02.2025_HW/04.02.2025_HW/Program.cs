using GeometryLibrary1;
using TextHelp;

namespace _04._02._2025_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            double square = Geometry.SquareArea(5);
            double rectangle = Geometry.RectangleArea(4, 6);
            double triangle = Geometry.TriangleArea(3, 5);

            Console.WriteLine($"Area of the square: {square}");
            Console.WriteLine($"Area of the rectangle: {rectangle}");
            Console.WriteLine($"Area of the triangle: {triangle}");

            // 2
            string text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam faucibus condimentum faucibus.
                            Aliquam blandit justo quis hendrerit aliquet. Etiam et imperdiet erat. 
                            Praesent egestas posuere nisi, eu lobortis odio venenatis vitae.
                            Mauris aliquam lorem vel nisl molestie gravida. Nam ultrices felis augue,
                            non lacinia augue maximus eget. Praesent pharetra ut ipsum sit amet dictum.";

            bool isPalindrome = TextHelper.IsPalindrome("madam");
            Console.WriteLine($"Is 'madam' a palindrome? {isPalindrome}");

            int sentenceCount = TextHelper.CountSentences(text);
            Console.WriteLine($"Number of sentences: {sentenceCount}");

            string reversedText = TextHelper.MyReverse(text);
            Console.WriteLine($"Reversed text: {reversedText}");
        }
    }
}
