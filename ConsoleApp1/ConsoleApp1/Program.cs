


using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class A
    {
        public static int a = 5;
        public static int b = a;
    }
    class B 
    {
        public static int b = a;
        public static int a = 5;
        
    }
    class C { }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write(A.b);
            Console.WriteLine(B.b);
        }
    }
}
