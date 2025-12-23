namespace _05._10_hw
{
    public interface IFigure
    {
        void Draw();
        string GetInfo();
    }

    public abstract class Figure : IFigure
    {
        public string Color { get; set; }

        protected Figure(string color)
        {
            Color = color;
        }

        public abstract void Draw();
        public abstract string GetInfo();

        protected void SetColor(string color)
        {
            switch (color.ToLower())
            {
                case "black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
        protected void ResetColor()
        {
            Console.ResetColor();
        }
    }

    public class Rectangle : Figure
    {
        private int width;
        private int height;

        public Rectangle(int width, int height, string color) : base(color)
        {
            this.width = width;
            this.height = height;
        }

        public override void Draw()
        {
            SetColor(Color);
            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(new string('*', width));
            }
            ResetColor();
        }

        public override string GetInfo()
        {
            return $"Rectangle: Width = {width}, Height = {height}, Color = {Color}";
        }
    }

    public class Diamond : Figure
    {
        private int size;

        public Diamond(int size, string color) : base(color)
        {
            this.size = size;
        }

        public override void Draw()
        {
            SetColor(Color);
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(new string(' ', size - i - 1) + new string('*', 2 * i + 1));
            }
            for (int i = size - 2; i >= 0; i--)
            {
                Console.WriteLine(new string(' ', size - i - 1) + new string('*', 2 * i + 1));
            }
            ResetColor();
        }

        public override string GetInfo()
        {
            return $"Diamond: Size = {size}, Color = {Color}";
        }
    }

    public class Triangle : Figure
    {
        private int height;

        public Triangle(int height, string color) : base(color)
        {
            this.height = height;
        }

        public override void Draw()
        {
            SetColor(Color);
            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(new string(' ', height - i - 1) + new string('*', 2 * i + 1));
            }
            ResetColor();
        }

        public override string GetInfo()
        {
            return $"Triangle: Height = {height}, Color = {Color}";
        }
    }
    public class Trapezoid : Figure
    {
        private int topWidth;
        private int bottomWidth;
        private int height;

        public Trapezoid(int topWidth, int bottomWidth, int height, string color) : base(color)
        {
            this.topWidth = topWidth;
            this.bottomWidth = bottomWidth;
            this.height = height;
        }

        public override void Draw()
        {
            SetColor(Color);
            for (int i = 0; i < height; i++)
            {
                int currentWidth = topWidth + (bottomWidth - topWidth) * i / height;
                Console.WriteLine(new string(' ', (bottomWidth - currentWidth) / 2) + new string('*', currentWidth));
            }
            ResetColor();
        }

        public override string GetInfo()
        {
            return $"Trapezoid: Top Width = {topWidth}, Bottom Width = {bottomWidth}, Height = {height}, Color = {Color}";
        }
    }

    public class Polygon : Figure
    {
        private int sides;
        private int sideLength;

        public Polygon(int sides, int sideLength, string color) : base(color)
        {
            this.sides = sides;
            this.sideLength = sideLength;
        }

        public override void Draw()
        {
            SetColor(Color);
            for (int i = 0; i < sides; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
            ResetColor();
        }

        public override string GetInfo()
        {
            return $"Polygon: Sides = {sides}, Side Length = {sideLength}, Color = {Color}";
        }
    }

    public class FigureCollection
    {
        private Figure[] figures;
        private int count;

        public FigureCollection(int capacity)
        {
            figures = new Figure[capacity];
            count = 0;
        }

        public void Add(Figure figure)
        {
            if (count < figures.Length)
            {
                figures[count] = figure;
                count++;
            }
            else
            {
                Console.WriteLine("Collection is full, cannot add new figure.");
            }
        }

        public void DrawAll()
        {
            for (int i = 0; i < count; i++)
            {
                figures[i].Draw();
                Console.WriteLine(figures[i].GetInfo());
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            FigureCollection collectionFigure = new FigureCollection(5);
            bool run = true;

            while (run)
            {
                Console.WriteLine("Choose a figure:");
                Console.WriteLine("1. Rectangle");
                Console.WriteLine("2. Diamond");
                Console.WriteLine("3. Triangle");
                Console.WriteLine("4. Trapezoid");
                Console.WriteLine("5. Polygon");
                Console.WriteLine("6. Display all figures");
                Console.WriteLine("7. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter width: ");
                        int width = int.Parse(Console.ReadLine());
                        Console.Write("Enter height: ");
                        int height = int.Parse(Console.ReadLine());
                        Console.Write("Enter color (black, red, green, yellow, blue, magenta, cyan, white): ");
                        string rectColor = Console.ReadLine();
                        collectionFigure.Add(new Rectangle(width, height, rectColor));
                        break;

                    case "2":
                        Console.Write("Enter size: ");
                        int diamondSize = int.Parse(Console.ReadLine());
                        Console.Write("Enter color (black, red, green, yellow, blue, magenta, cyan, white): ");
                        string diamondColor = Console.ReadLine();
                        collectionFigure.Add(new Diamond(diamondSize, diamondColor));
                        break;

                    case "3":
                        Console.Write("Enter height: ");
                        int triangleHeight = int.Parse(Console.ReadLine());
                        Console.Write("Enter color (black, red, green, yellow, blue, magenta, cyan, white): ");
                        string triangleColor = Console.ReadLine();
                        collectionFigure.Add(new Triangle(triangleHeight, triangleColor));
                        break;

                    case "4":
                        Console.Write("Enter top width: ");
                        int topWidth = int.Parse(Console.ReadLine());
                        Console.Write("Enter bottom width: ");
                        int bottomWidth = int.Parse(Console.ReadLine());
                        Console.Write("Enter height: ");
                        int trapezoidHeight = int.Parse(Console.ReadLine());
                        Console.Write("Enter color (black, red, green, yellow, blue, magenta, cyan, white): ");
                        string trapezoidColor = Console.ReadLine();
                        collectionFigure.Add(new Trapezoid(topWidth, bottomWidth, trapezoidHeight, trapezoidColor));
                        break;

                    case "5":
                        Console.Write("Enter number of sides: ");
                        int sides = int.Parse(Console.ReadLine());
                        Console.Write("Enter side length: ");
                        int sideLength = int.Parse(Console.ReadLine());
                        Console.Write("Enter color (black, red, green, yellow, blue, magenta, cyan, white): ");
                        string polygonColor = Console.ReadLine();
                        collectionFigure.Add(new Polygon(sides, sideLength, polygonColor));
                        break;

                    case "6":
                        collectionFigure.DrawAll();
                        break;

                    case "7":
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }
    }
}