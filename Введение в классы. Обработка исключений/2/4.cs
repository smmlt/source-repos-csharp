using static System.Net.Mime.MediaTypeNames;

namespace _2
{
    class CaesarCipher
    {
        public static string Encrypt(string text, int shift)
        {
            if (text == null)
            {
                Console.WriteLine("error");
                return text;
            }

            char[] chars = text.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (char.IsLetter(c))
                {
                    char shiftedChar = (char)(c + shift);

                    if (char.IsLower(c))
                    {
                        if (shiftedChar > 'z')
                        {
                            shiftedChar = (char)(shiftedChar - 26);
                        }
                        else if (shiftedChar < 'a')
                        {
                            shiftedChar = (char)(shiftedChar + 26);
                        }
                    }
                    else if (char.IsUpper(c))
                    {
                        if (shiftedChar > 'Z')
                        {
                            shiftedChar = (char)(shiftedChar - 26);
                        }
                        else if (shiftedChar < 'A')
                        {
                            shiftedChar = (char)(shiftedChar + 26);
                        }
                    }

                    chars[i] = shiftedChar;
                }
            }

            return new string(chars);
        }

        public static string Decrypt(string text, int shift)
        {
            if (text == null)
            {
                Console.WriteLine("error");
                return text;
            }

            return Encrypt(text, -shift);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello, World!";
            int shift = 3;

            string encryptedText = CaesarCipher.Encrypt(text, shift);
            Console.WriteLine($"Encrypted: {encryptedText}");

            string decryptedText = CaesarCipher.Decrypt(encryptedText, shift);
            Console.WriteLine($"Decrypted: {decryptedText}");
        }
    }
}
