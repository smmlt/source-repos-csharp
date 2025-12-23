namespace _19._09_hw
{
    using System;

    class Shop
    {
        string? Name { get; set; }
        double Area { get; set; }

        

        public Shop(string name, double area)
        {
            if (area < 0)
            {
                throw new ArgumentException("Shop area cannot be negative.");
            }
            Name = name;
            Area = area;
        }
        public Shop()
        {
            Name = "Unknown";
            Area = 0.0;
        }

        public static Shop operator +(Shop shop, double AddArea)
        {
            if (AddArea < 0)
            {
                throw new ArgumentException("The area to subtract from the current one cannot be less than zero.");
            }

            return new Shop(shop.Name, shop.Area + AddArea);
        }

        public static Shop operator -(Shop shop, double SubstArea)
        {
            if (SubstArea < 0)
            {
                throw new ArgumentException("The area to subtract from the current one cannot be less than zero.");
            }

            if (shop.Area - SubstArea < 0)
            {
                throw new ArgumentException("Shop area cannot be negative.");
            }

            return new Shop(shop.Name, shop.Area - SubstArea);
        }

        public static bool operator ==(Shop shop1, Shop shop2) 
            => shop1.Area == shop2.Area;


        public static bool operator !=(Shop shop1, Shop shop2)
            => shop1.Area != shop2.Area;

        public static bool operator >(Shop shop1, Shop shop2)
            => shop1.Area > shop2.Area;

        public static bool operator <(Shop shop1, Shop shop2)
            => shop1.Area < shop2.Area;

        public override bool Equals(object obj) => base.Equals(obj);


        public override int GetHashCode() => base.GetHashCode();

        public override string ToString()
        {
            return $"Shop \"{Name}\" with area {Area} square meters";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop1 = new Shop("Shop 1", 100);
            Shop shop2 = new Shop("Shop 2", 150);

            Console.WriteLine(shop1);
            Console.WriteLine(shop2);

            shop1 += 50;
            shop2 -= 30;

            Console.WriteLine(shop1);
            Console.WriteLine(shop2);

            Console.WriteLine("\nComparing the areas of the shops:");
            Console.WriteLine($"Are the areas of the shops equal? {shop1 == shop2}");
            Console.WriteLine($"Are the areas of the shops not equal? {shop1 != shop2}");
            Console.WriteLine($"Is Shop 1 larger than Shop 2? {shop1 > shop2}");
            Console.WriteLine($"Is Shop 1 smaller than Shop 2? {shop1 < shop2}");

            Console.WriteLine(Equals(shop1, shop2));

            try
            {
                shop1 -= 200.0;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nError when subtracting area: {e.Message}");
            }
        }
    }
}
