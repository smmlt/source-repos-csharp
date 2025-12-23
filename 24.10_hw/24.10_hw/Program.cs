using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace _24._10_hw
{
    public class CountryAndCity
    {
        private Dictionary<string, ObservableCollection<string>> countries = new Dictionary<string, ObservableCollection<string>>();

        public void AddCountry(string country)
        {
            if (!countries.ContainsKey(country))
            {
                var cities = new ObservableCollection<string>();
                cities.CollectionChanged += Cities_CollectionChanged;
                countries[country] = cities;
                Console.WriteLine($"Country {country} added.");
            }
            else
            {
                Console.WriteLine($"Country {country} already exists.");
            }
        }

        public void AddCity(string country, string city)
        {
            if (countries.ContainsKey(country))
            {
                countries[country].Add(city);
                Console.WriteLine($"City {city} added to country {country}.");
            }
            else
            {
                Console.WriteLine($"Country {country} not found.");
            }
        }

        public void RemoveCity(string country, string city)
        {
            if (countries.ContainsKey(country))
            {
                if (countries[country].Contains(city))
                {
                    countries[country].Remove(city);
                    Console.WriteLine($"City {city} removed from country {country}.");
                }
                else
                {
                    Console.WriteLine($"City {city} not found in country {country}.");
                }
            }
            else
            {
                Console.WriteLine($"Country {country} not found.");
            }
        }

        public void RemoveCountry(string country)
        {
            if (countries.ContainsKey(country))
            {
                countries.Remove(country);
                Console.WriteLine($"Country {country} removed.");
            }
            else
            {
                Console.WriteLine($"Country {country} not found.");
            }
        }

        public int CountCities(string country)
        {
            if (countries.ContainsKey(country))
            {
                return countries[country].Count;
            }
            else
            {
                Console.WriteLine($"Country {country} not found.");
                return 0;
            }
        }

        public void DisplayCountries()
        {
            foreach (var country in countries)
            {
                Console.WriteLine(country.Key);
            }
        }

        private void Cities_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (string newCity in e.NewItems)
                    {
                        Console.WriteLine($"Notification: new city {newCity} added.");
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (string oldCity in e.OldItems)
                    {
                        Console.WriteLine($"Notification: city {oldCity} removed.");
                    }
                    break;
                default:
                    break;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CountryAndCity countryAndCity = new CountryAndCity();

            countryAndCity.AddCountry("Ukraine");
            countryAndCity.AddCity("Ukraine", "Kyiv");
            countryAndCity.AddCity("Ukraine", "Kherson");

            countryAndCity.AddCountry("France");
            countryAndCity.AddCity("France", "Paris");
            countryAndCity.AddCity("France", "Lyon");

            countryAndCity.AddCountry("Russia");
            countryAndCity.AddCity("Russia", "Moscow");

            Console.WriteLine($"Number of cities in Ukraine: {countryAndCity.CountCities("Ukraine")}");
            Console.WriteLine("List of countries:");
            countryAndCity.DisplayCountries();

            countryAndCity.RemoveCity("Russia", "Moscow");
            countryAndCity.RemoveCountry("Russia");

            Console.WriteLine("List of countries after removal:");
            countryAndCity.DisplayCountries();
        }
    }
}
