namespace try_catch_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int x = Convert.ToInt32(Console.ReadLine(), 2);
                Console.WriteLine(x);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow error");
            }
            catch (FormatException)
            {
                Console.WriteLine("Format error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
