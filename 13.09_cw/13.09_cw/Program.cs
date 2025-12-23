namespace _13._09_cw
{

    public class Device
    {
        public string Name { get; set; }
        public string Specifications { get; set; }


        public Device(string name, string specifications)
        {
            Name = name;
            Specifications = specifications;
        }

        public Device()
        {
            Name = "Unknown device";
            Specifications = "Unknown specifications";
        }

        public virtual void Show()
        {
            Console.WriteLine($"Device: {Name}");
        }

        public virtual void Desc()
        {
            Console.WriteLine($"Desc: {Name} - {Specifications}");
        }

        public virtual void Sound()
        {
            Console.WriteLine($"{Name} a sound.");
        }
    }

    public class Kettle : Device
    {
        public int Amount { get; set; }


        public Kettle(string name, string specifications, int amount)
            : base(name, specifications)
        {
            Amount = amount;
        }

        public Kettle() : base()
        {
            Amount = 1;
        }

        public override void Sound()
        {
            Console.WriteLine($"{Name} a sound.");
        }

        public override void Desc()
        {
            base.Desc();
            Console.WriteLine($"Amount: {Amount} liters");
        }
    }

    public class Microwave : Device
    {
        public int Power { get; set; }

        public Microwave(string name, string specifications, int power)
            : base(name, specifications)
        {
            Power = power;
        }

        public Microwave() : base()
        {
            Power = 800;
        }

        public override void Sound()
        {
            Console.WriteLine($"{Name} a sound.");
        }

        public override void Desc()
        {
            base.Desc();
            Console.WriteLine($"Power: {Power} watts");
        }
    }

    public class Car : Device
    {
        public string FuelType { get; set; }

        public Car(string name, string specifications, string fuelType)
            : base(name, specifications)
        {
            FuelType = fuelType;
        }
        public Car() : base()
        {
            FuelType = "Unknown fuel";
        }

        public override void Sound()
        {
            Console.WriteLine($"{Name} a sound .");
        }

        public override void Desc()
        {
            base.Desc();
            Console.WriteLine($"Fuel type: {FuelType}");
        }
    }

    public class Steamship : Device
    {
        public int AreaShip { get; set; }

        public Steamship() : base()
        {
            AreaShip = 1000;
        }

        public Steamship(string name, string specifications, int areaShip)
            : base(name, specifications)
        {
            AreaShip = areaShip;
        }

        public override void Sound()
        {
            Console.WriteLine($"{Name} a sound.");
        }

        public override void Desc()
        {
            base.Desc();
            Console.WriteLine($"Area: {AreaShip} 'm");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Device kettle = new Kettle("Electric Kettle", "Modern kettle", 1);
            Device microwave = new Microwave("Microwave", "Microwave Cool 3000", 1200);
            Device car = new Car("AUDI", "Premium class car", "Gasoline");
            Device steamship = new Steamship("Korablick?", "Fishing vessel", 46000);

            kettle.Show();
            microwave.Desc();
            car.Sound();
        }
    }
}
