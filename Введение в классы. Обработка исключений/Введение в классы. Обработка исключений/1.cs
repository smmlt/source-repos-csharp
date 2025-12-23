using System;
namespace Введение_в_классы._Обработка_исключений
{
    class City
    {
        private string cityName;
        private string countryName;
        private int population;
        private string phoneCode;
        private string[] districts;

        public City(string cityName, string countryName, int population, string phoneCode, string[] districts)
        {
            SetCityName(cityName);
            SetCountryName(countryName);
            SetPopulation(population);
            SetPhoneCode(phoneCode);
            SetDistricts(districts);
        }
        public City(string cityNameParam, string countryNameParam)
        {
            cityName = cityNameParam;
            countryName = countryNameParam;
            population = 0;
            phoneCode = "000";
            districts = new string[0];
        }

        public City()
        {
            cityName = "Unknown";
            countryName = "Unknown";
            population = 0;
            phoneCode = "000";
            districts = new string[0];
        }
        public void SetCityName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("City name cannot be null or empty.");
            }
            cityName = value;
        }

        public void SetCountryName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Country name cannot be null or empty.");
            }
            countryName = value;
        }

        public void SetPopulation(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Population cannot be negative.");
            }
            population = value;
        }

        public void SetPhoneCode(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Phone code cannot be null or empty.");
            }
            phoneCode = value;
        }

        public void SetDistricts(string[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Districts cannot be null.");
            }

            districts = new string[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                districts[i] = value[i];
            }
        }
        public string GetCityName() { return cityName; }
        public string GetCountryName() { return countryName; }
        public int GetPopulation() { return population; }
        public string GetPhoneCode() { return phoneCode; }
        public string[] GetDistricts() { return districts; }
        
        public void Show()
        {
            Console.WriteLine($"Name of the city: {cityName}");
            Console.WriteLine($"Country: {countryName}");
            Console.WriteLine($"Population: {population}");
            Console.WriteLine($"Phone: {phoneCode}");
            foreach (string district in districts)
            {
                Console.WriteLine($"- {district}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                string[] districts = { "Central", "Old", "New" };
                City city1 = new City("City of a Thousand Planets", "ne znau", 123456789, "123-456", districts);
                city1.Show();
                Console.WriteLine();

                City city2 = new City("Qwerty", "");
                city2.SetPopulation(5);
                city2.SetPhoneCode("654-321");
                city2.Show();
                Console.WriteLine();

                City city3 = new City();
                city3.Show();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            

        }
    }
}
