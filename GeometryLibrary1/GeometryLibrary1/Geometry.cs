namespace GeometryLibrary1
{
    public class Geometry
    {
        public static double SquareArea(double side)
        {
            return side * side;
        }

        public static double RectangleArea(double width, double height)
        {
            return width * height;
        }

        public static double TriangleArea(double length, double height)
        {
            return 0.5 * length * height;
        }
    }
}
