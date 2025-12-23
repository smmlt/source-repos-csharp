namespace _14._09_hw
{
    internal class Program
    {
        class City
        {
            private string CityName;
            private string CityCode;
            private ulong NumberOfInhabitants;

            public City(string _cityName, string _cityCode, ulong _numberOfInhabitants)
            {
                CityName = _cityName;
                CityCode = _cityCode;
                NumberOfInhabitants = _numberOfInhabitants;
            }

            public City()
            {
                CityName = "Unknown";
                CityCode = "000";
                NumberOfInhabitants = 0;
            }

            public string GetCityName() { return CityName; }
            public string GetCityCode() { return CityCode; }
            public ulong GetNumberOfInhabitants() { return NumberOfInhabitants; }

            public void SetCityName(string value)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("City name cannot be empty.");
                CityName = value;
            }

            public void SetCityCode(string value)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("City code must be non-empty.");
                CityCode = value;
            }

            public void SetNumberOfInhabitants(ulong value) { NumberOfInhabitants = value; }

            public static City operator +(City city, ulong inhabitantsToAdd)
            {
                if (inhabitantsToAdd < 0)
                    throw new ArgumentException("Inhabitants to add must be a non-negative number.");
                return new City(city.GetCityName(), city.GetCityCode(), city.GetNumberOfInhabitants() + inhabitantsToAdd);
            }

            public static City operator -(City city, ulong inhabitantsToRemove)
            {
                if (city.NumberOfInhabitants - inhabitantsToRemove < 0)
                    throw new ArgumentException("The number of inhabitants to be removed exceeds the current population.");
                return new City(city.GetCityName(), city.GetCityCode(), city.GetNumberOfInhabitants() - inhabitantsToRemove);
            }

            public static bool operator ==(City city1, City city2)
                => city1.GetNumberOfInhabitants == city2.GetNumberOfInhabitants;
            public static bool operator !=(City city1, City city2)
                => city1.GetNumberOfInhabitants != city2.GetNumberOfInhabitants;

            public static bool operator <(City city1, City city2)
                => city1.NumberOfInhabitants < city2.NumberOfInhabitants;
            public static bool operator >(City city1, City city2)
                => city1.NumberOfInhabitants > city2.NumberOfInhabitants;

            public override bool Equals(object? obj) { return base.Equals(obj); }
            public override int GetHashCode() { return GetNumberOfInhabitants().GetHashCode(); }
            public override string ToString()
            {
                return $"City: {GetCityName()}, Code: {GetCityCode()}, Inhabitants: {GetNumberOfInhabitants()}";
            }
        }
        static void Main(string[] args)
        {
            City city1 = new City("New York", "NYC", 8336642);
            City city2 = new City("Los Angeles", "LA", 3822879);
            Console.WriteLine(city1);
            Console.WriteLine($"{city2}\n");

            city1 += 50000;
            city2 -= 23000;
            Console.WriteLine(city1);
            Console.WriteLine($"{city2}\n");

            Console.WriteLine(city1 == city2);
            Console.WriteLine(city1 > city2);
            Console.WriteLine(city1 < city2);
        }
    }
}
