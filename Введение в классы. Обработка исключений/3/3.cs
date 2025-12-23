namespace _3
{
    class Airplane
    {
        private string airplaneName;
        private string manufacturerName;
        private int yearOfManufacture;
        private string airplaneType;
        public Airplane(string airplaneName, string manufacturerName, int yearOfManufacture, string airplaneType)
        {
            SetAirplaneName(airplaneName);
            SetManufacturerName(manufacturerName);
            SetYearOfManufacture(yearOfManufacture);
            SetAirplaneType(airplaneType);
        }

        public Airplane(string airplaneNameParam, string manufacturerNameParam)
        {
            airplaneName = airplaneNameParam;
            manufacturerName = manufacturerNameParam;
            yearOfManufacture = 0;
            airplaneType = "Unknown";
        }

        public Airplane()
        {
            airplaneName = "Unknown";
            manufacturerName = "Unknown";
            yearOfManufacture = 0;
            airplaneType = "Unknown";
        }

        public void SetAirplaneName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Airplane name cannot be null or empty.");
            }
            airplaneName = value;
        }

        public void SetManufacturerName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Manufacturer name cannot be null or empty.");
            }
            manufacturerName = value;
        }

        public void SetYearOfManufacture(int value)
        {
            if (value < 1900 || value > DateTime.Now.Year)
            {
                throw new ArgumentException("Invalid year of manufacture.");
            }
            yearOfManufacture = value;
        }

        public void SetAirplaneType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Airplane type cannot be null or empty.");
            }
            airplaneType = value;
        }

        public string GetAirplaneName() { return airplaneName; }
        public string GetManufacturerName() { return manufacturerName; }
        public int GetYearOfManufacture() { return yearOfManufacture; }
        public string GetAirplaneType() { return airplaneType; }

        public void Show()
        {
            Console.WriteLine($"Airplane Name: {airplaneName}");
            Console.WriteLine($"Manufacturer: {manufacturerName}");
            Console.WriteLine($"Year of Manufacture: {yearOfManufacture}");
            Console.WriteLine($"Type: {airplaneType}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Airplane airplane1 = new Airplane("Boeing 747", "Boeing", 1969, "Commercial");
                airplane1.Show();
                Console.WriteLine();

                Airplane airplane2 = new Airplane("Airbus A320", "Airbus");
                airplane2.SetYearOfManufacture(1988);
                airplane2.SetAirplaneType("Commercial");
                airplane2.Show();
                Console.WriteLine();

                Airplane airplane3 = new Airplane();
                airplane3.Show();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
