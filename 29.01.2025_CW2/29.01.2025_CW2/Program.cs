using System.Net;
using System.Net.Security;
using System.Net.Sockets;

namespace _29._01._2025_CW2
{
    static class Server
    {
        static List<Socket> clients = new List<Socket>();
        static Socket server;
        static public void Start()
        {
            server = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );

            try
            {
                server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80));
                server.Listen(10);
                Console.WriteLine("Server is ON");

                while (true) 
                {
                    Socket newClient = server.Accept();
                    clients.Add(newClient);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Client {clients.IndexOf(newClient)} connected");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Task.Run(() => ManageClient(newClient));
                }
            }
            catch { }
            finally {
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
        }
        private static void ManageClient(Socket newClient)
        {
            byte[] buffer = new byte[1024];
            int bytesCount;

            try
            {
                while ((bytesCount = newClient.Receive(buffer)) > 0)    
                {
                    string message = System.Text.Encoding.ASCII.GetString(buffer);
                    Console.WriteLine($"Received from {clients.IndexOf(newClient)}: {message}");
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Client disconnected");
                newClient.Close();
                clients.Remove(newClient);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Server.Start();
        }
    }
}
