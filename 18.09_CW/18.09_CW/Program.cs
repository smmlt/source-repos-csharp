namespace _18._09_CW
{
    abstract class Worker
    {
        public string? Name { get; set; }
        public DateTime BirthDay { get; set; }
        public decimal? Salary { get; set; }

        public Worker(string? name, DateTime birthDay, decimal salary)
        {
            Name = name;
            BirthDay = birthDay;
            Salary = salary;
        }

        public abstract void Print();
    }

    class President : Worker
    {
        public string? Country { get; set; }

        public President(string? name, DateTime birthDay, decimal salary, string? country)
            : base(name, birthDay, salary)
        {
            Country = country;
        }

        public override void Print()
        {
            Console.WriteLine($"President: {Name}, Country: {Country}, Birthdate: {BirthDay.ToShortDateString()}, Salary: {Salary:C}");
        }
    }

    class Security : Worker
    {
        public string? Building { get; set; }

        public Security(string? name, DateTime birthDay, decimal salary, string? building)
            : base(name, birthDay, salary)
        {
            Building = building;
        }

        public override void Print()
        {
            Console.WriteLine($"Security: {Name}, Guards building: {Building}, Birthdate: {BirthDay.ToShortDateString()}, Salary: {Salary:C}");
        }
    }

    class Manager : Worker
    {
        public string? Store { get; set; }

        public Manager(string? name, DateTime birthDate, decimal salary, string? store)
            : base(name, birthDate, salary)
        {
            Store = store;
        }

        public override void Print()
        {
            Console.WriteLine($"Manager: {Name}, Store: {Store}, Birthdate: {BirthDay.ToShortDateString()}, Salary: {Salary:C}");
        }
    }

    class Engineer : Worker
    {
        public string? Company { get; set; }

        public Engineer(string? name, DateTime birthDate, decimal salary, string? company)
            : base(name, birthDate, salary)
        {
            Company = company;
        }

        public override void Print()
        {
            Console.WriteLine($"Engineer: {Name}, Company: {Company}, Birthdate: {BirthDay.ToShortDateString()}, Salary: {Salary:C}");
        }
    }

    abstract class Shape
    {
        public abstract double GetArea();
    }

    class Rectangle : Shape
    {
        public uint Width { get; set; }
        public uint Height { get; set; }

        public Rectangle(uint width, uint height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea()
        {
            return Width * Height;
        }
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.Round(Math.PI * Radius * Radius, 2);
        }
    }

    class RightTriangle : Shape
    {
        public double Weight { get; set; }
        public double Height { get; set; }

        public RightTriangle(double weightLength, double height)
        {
            Weight = weightLength;
            Height = height;
        }

        public override double GetArea()
        {
            return Weight * Height / 2;
        }
    }

    class Trapeze : Shape
    {
        public double BottomBase { get; set; }
        public double TopBase { get; set; }
        public double Height { get; set; }

        public Trapeze(double bottomBase, double topBase, double height)
        {
            BottomBase = bottomBase;
            TopBase = topBase;
            Height = height;
        }

        public override double GetArea()
        {
            return (BottomBase + TopBase) * Height / 2;
        }
    }

    class CompositeShape : Shape
    {
        public int Size { get; set; }
        private Shape[] shapes;
        public int Capacity { get; set; }

        public CompositeShape(int capacity = 5)
        {
            shapes = new Shape[capacity];
            Size = 0;
            Capacity = capacity;
        }

        public void AddShape(Shape shape)
        {
            if (Size >= Capacity)
            {
                IncreaseCapacity();
            }
            shapes[Size++] = shape;
        }

        private void IncreaseCapacity()
        {
            Capacity *= 2;
            Shape[] newShapes = new Shape[Capacity];

            for (int i = 0; i < Size; i++)
            {
                newShapes[i] = shapes[i];
            }
            shapes = newShapes;
        }

        public override double GetArea()
        {
            double totalArea = 0;
            for (int i = 0; i < Size; i++)
            {
                totalArea += shapes[i].GetArea();
            }
            return totalArea;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 

            Worker president = new President("Tramp", new DateTime(1234, 6, 14), 2000000, "USA");
            Worker security = new Security("Parker", new DateTime(1335, 3, 22), 5000, "Office");
            Worker manager = new Manager("Oleg", new DateTime(1995, 11, 5), 75100, "Apple Store");
            Worker engineer = new Engineer("Bob", new DateTime(1987, 9, 12), 10870, "Apple");

            president.Print();
            security.Print();
            manager.Print();
            engineer.Print();

            Console.WriteLine();

            // 2

            Shape[] shapes = new Shape[]
            {
            new Rectangle(8, 5),
            new Circle(7),
            new RightTriangle(6, 8),
            new Trapeze(5, 3, 4)
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.GetArea());
            }

            Console.WriteLine();

            // 3

            CompositeShape compositeShape = new CompositeShape();

            foreach (Shape shape in shapes)
            {
                compositeShape.AddShape(shape);
            }

            Console.WriteLine($"Composite shape area: {compositeShape.GetArea()}");
        }
    }

}
