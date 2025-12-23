using System.Net;
using System.Net.Sockets;

namespace _29._01._2025_CW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("142.250.181.206");
            IPEndPoint ep = new IPEndPoint(ip, 80);
            Socket socket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );

            try
            {
                socket.Connect(ep);
                if (socket.Connected)
                {
                    string strToSend = "GET\n";
                    socket.Send(System.Text.Encoding.ASCII.GetBytes(strToSend));

                    byte[] buffer = new byte[1024];
                    while (socket.Receive(buffer) > 0)
                    {
                        Console.WriteLine(System.Text.Encoding.ASCII.GetString(buffer));
                        Console.WriteLine(1);
                    }

                    socket.Shutdown(SocketShutdown.Both);
                }
                else { Console.WriteLine("Error"); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                socket.Close();
            }
        }
    }
}
