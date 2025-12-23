namespace _19._10_hw
{
    public class Item
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public Item(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }
    }

    public class Backpack
    {
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Fabric { get; set; }
        public double Weight { get; set; }
        public double Capacity { get; set; }
        public List<Item> Contents { get; private set; }
        private double currentVolume;

        public delegate void ItemChange(Item item);
        public event ItemChange ItemAdded;
        public event ItemChange ItemRemoved;

        public Backpack(string color, string brand, string fabric, double weight, double capacity)
        {
            Color = color;
            Brand = brand;
            Fabric = fabric;
            Weight = weight;
            Capacity = capacity;
            Contents = new List<Item>();
            currentVolume = 0;
        }

        public void AddItem(Item item)
        {
            if (currentVolume + item.Volume > Capacity)
            {
                throw new InvalidOperationException("Cannot add item: backpack volume exceeded.");
            }

            Contents.Add(item);
            currentVolume += item.Volume;

            ItemAdded?.Invoke(item);
        }

        public void RemoveItem(Item item)
        {
            if (Contents.Remove(item))
            {
                currentVolume -= item.Volume;

                ItemRemoved?.Invoke(item);
            }
            else
            {
                throw new InvalidOperationException("Cannot remove item: item not found in the backpack.");
            }
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Backpack Info:");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Fabric: {Fabric}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Capacity: {Capacity} liters");
            Console.WriteLine($"Currently Occupied Volume: {currentVolume} liters");
            Console.WriteLine("Items inside the backpack:");

            if (Contents.Count > 0)
            {
                foreach (var item in Contents)
                {
                    Console.WriteLine($"~ {item.Name}, Volume: {item.Volume} liters");
                }
            }
            else
            {
                Console.WriteLine("The backpack is empty.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Backpack backpack = new Backpack("Black", "Nike", "Nylon", 1.2, 30);

            backpack.ItemAdded += item =>
            {
                Console.WriteLine($"Item '{item.Name}' added to the backpack.Volume occupied: { item.Volume} liters.");
            };

            backpack.ItemRemoved += item =>
            {
                Console.WriteLine($"Item '{item.Name}' removed from the backpack. Volume freed: {item.Volume} liters.");
            };

            try
            {
                Item book = new Item("Book", 2.5);
                Item laptop = new Item("Laptop", 5.0);
                Item bottle = new Item("Water Bottle", 1.5);

                backpack.AddItem(book);
                backpack.AddItem(laptop);
                backpack.AddItem(bottle);

                backpack.DisplayInfo();

                backpack.RemoveItem(book);

                Item pen = new Item("Pen", 0.2);
                backpack.RemoveItem(pen);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
