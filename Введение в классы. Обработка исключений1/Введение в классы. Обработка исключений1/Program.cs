using System;

namespace Introduction_to_Classes_Exception_Handling1
{
    internal class Program
    {
        static int EvaluateExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new FormatException("The expression cannot be empty");
            }

            string[] parts = expression.Split('*');

            if (parts.Length == 1)
            {
                throw new FormatException("The expression must contain at least one '*' operator");
            }

            int result = 1;

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (c != '*' && !char.IsDigit(c))
                {
                    throw new FormatException($"Invalid character '{c}' in the expression. Only digits and the '*' operator are allowed.");
                }
            }

            for (int i = 0; i < parts.Length; i++)
            {
                string part = parts[i];

                if (!int.TryParse(part, out int number))
                {
                    throw new FormatException($"'{part}' is not a valid integer");
                }

                result *= number;
            }

            /*
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (c != '*' && !char.IsDigit(c))
                {
                    throw new FormatException($"Invalid character '{c}' in the expression. Only digits and the '*' operator are allowed.");
                }
            }
            */

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a mathematical expression containing only integers and the '*' operator:");
            string input = Console.ReadLine();

            try
            {
                int result = EvaluateExpression(input);
                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
        }
    }
}
