using System.Net;
using System.Net.Sockets;

namespace Client_V1_CW_31._01._2025_
{
    static class Client
    {
        static Socket client;

        public static void Start()
        {
            client = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );

            try
            {
                client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80));
                Console.WriteLine($"Connected to server 127.0.0.1");

                Console.WriteLine("Enter your login: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string? login = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;

                byte[] bLogin = System.Text.Encoding.ASCII.GetBytes(login);
                client.Send(bLogin);

                Task.Run(() => ReceiveMessages());

                while (true)
                { 
                    string? message = Console.ReadLine();
                    byte[] bMessage = System.Text.Encoding.ASCII.GetBytes(message);
                    client.Send(bMessage);
                }

            }
            catch (SocketException ex) { Console.WriteLine(ex.Message); }
            finally { client.Close(); }
        }

        private static void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            int bytesCount;

            try
            {
                while ((bytesCount = client.Receive(buffer)) > 0)
                {
                    string message = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesCount);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            catch (SocketException ex) { Console.WriteLine(ex.Message); }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Client.Start();
        }
    }
}
