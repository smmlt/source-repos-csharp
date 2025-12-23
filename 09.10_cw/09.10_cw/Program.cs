namespace _09._10_cw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Dictionary<string, string> countryDictionary = new Dictionary<string, string>()
            {
                { "Ukraine" , "Украина" },
                { "Poland" , "Польша"  },
                { "Germany", "Германия"},
                { "France", "Франция" },
                { "Spain" , "Испания" },
                { "Italy" , "Италия" },
                { "China" , "Китай" },
                { "Japan" , "Япония" }
            };

            Dictionary<string, string> reverseCountryDictionary = new Dictionary<string, string>();
            foreach (var country in countryDictionary) 
            {
                reverseCountryDictionary.Add(country.Value, country.Key);
            }

            while (true)
            {
                Console.WriteLine("Choose translation direction:");
                Console.WriteLine("1 - from English to Russian");
                Console.WriteLine("2 - from Russian to English");
                Console.WriteLine("3 - exit\n");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "3")
                {
                    break;
                }

                Console.WriteLine("Enter the country name:");
                string country = Console.ReadLine();

                if (choice == "1")
                {
                    if (countryDictionary.ContainsKey(country))
                    {
                        Console.WriteLine($"Translation: {countryDictionary[country]}\n");
                    }
                    else
                    {
                        Console.WriteLine("Country not found in the dictionary.\n");
                    }
                }
                else if (choice == "2")
                {
                    if (reverseCountryDictionary.ContainsKey(country))
                    {
                        Console.WriteLine($"Translation: {reverseCountryDictionary[country]}\n");
                    }
                    else
                    {
                        Console.WriteLine("Country not found in the dictionary.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.\n");
                }
            }*/

            //2 
            Console.WriteLine("enter text: ");
            string inputText = Console.ReadLine();

            string[] words = inputText.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> frequencyWord = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (frequencyWord.ContainsKey(word))
                {
                    frequencyWord[word]++;
                }
                else
                {
                    frequencyWord.Add(word, 1);
                }
            }
        }
    }
}
