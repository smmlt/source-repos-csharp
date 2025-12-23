namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the arithmetic expression: ");
            string input = Console.ReadLine();
            
            int result = 0;
            int currentNumber = 0;
            char currentOperation = '+';

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsDigit(c))
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                }

                if ((!char.IsDigit(c) && c != ' ') || i == input.Length - 1)
                {
                    if (i == input.Length - 1 && char.IsDigit(c))
                    {
                        currentNumber = currentNumber * 10 + (c - '0');
                    }

                    if (currentOperation == '+')
                    {
                        result += currentNumber;
                    }
                    else if (currentOperation == '-')
                    {
                        result -= currentNumber;
                    }

                    currentOperation = c;
                    currentNumber = 0;
                }
            }
            // Добавляем последнее число в выражении к результату
            if (currentOperation == '+')
            {
                result += currentNumber;
            }
            else if (currentOperation == '-')
            {
                result -= currentNumber;
            }

            Console.WriteLine($"Result: {result}");
        }
    }
}
