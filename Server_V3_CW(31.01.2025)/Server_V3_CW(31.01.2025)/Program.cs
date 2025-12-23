using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_V3_CW_31._01._2025_
{
    // -----------------------------------------------
    static class Server
    {
        static List<Socket> clients = new List<Socket>();
        static List<string> logins = new List<string>();

        static Socket server;

        static int? secretNumber;
        static Random random = new Random();

        static public void Start()
        {
            server = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );

            try
            {
                server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80)); // telnet 127.0.0.1 80
                server.Listen(10);
                Console.WriteLine("Server is ON");

                while (true)
                {
                    Socket newClient = server.Accept();
                    clients.Add(newClient);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Client {clients.IndexOf(newClient)} connected");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    if (clients.Count == 1)
                    {
                        StartGame();
                    }


                    Task.Run(() => ManageClient(newClient));
                    //Task.Run(() => SendTime(newClient));
                }
            }
            catch (SocketException ex) { Console.WriteLine(ex.Message); }
            finally
            {
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
        }

        private static void StartGame()
        {
            secretNumber = random.Next(1, 1001);
            Console.WriteLine($"[SERVER] The secret number is: {secretNumber}");
            BroadcastMessage("\n\rThe game has started! Guess the number between 1 and 1000:\t");
        }

        private static void BroadcastMessage(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message + "\n");

            foreach (Socket client in clients)
            {
                client.Send(data);
            }
        }

        private static void SendTime(Socket newClient)
        {
            try
            {
                while (newClient.Connected)
                {
                    newClient.Send(Encoding.ASCII.GetBytes(DateTime.Now.ToString() + "\t"));
                    Thread.Sleep(1000);
                }
            }
            catch (SocketException ex) { Console.WriteLine(ex.Message); }
        }

        private static void BroadcastMessages( string message, Socket currentClient)
        {
            int index = clients.IndexOf(currentClient);
            byte[] bMessage = System.Text.Encoding.ASCII.GetBytes(logins[index] + ": " + message);

            foreach (Socket cl in clients)
            {
                if (cl != currentClient)
                    cl.Send(bMessage);
            }
        }

        private static void ManageClient(Socket newClient)
        {
            byte[] buffer = new byte[1024];
            int bytesCount;
            bool hasLogin = false;
            string clientName = "Unknown";

            try
            {
                while ((bytesCount = newClient.Receive(buffer)) > 0)
                {
                    string message = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesCount);

                    if (!hasLogin)
                    {
                        clientName = message;
                        logins.Add(clientName);
                        hasLogin = true;

                        Console.WriteLine($"[SERVER] Client {clients.IndexOf(newClient)} has joined the game.");
                        SendToClient(newClient, "\n\rWelcome! The game is already in progress. Try to guess the number between 1 and 1000:\t");
                    }
                    else 
                    {
                        int index = clients.IndexOf(newClient);
                        Console.WriteLine($"Received from {logins[index]}: {message}");

                        if (int.TryParse(message, out int guess))
                        {
                            HandleGuess(newClient, clientName, guess);
                        }
                        else
                        {
                            BroadcastMessages($"{clientName}: {message}", newClient);
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                int index = clients.IndexOf(newClient);

                Console.WriteLine($"Client {logins[index]} disconnected");
                newClient.Close();

                if(clients.Count > 0) clients.RemoveAt(index);
                if(logins.Count > 0) logins.RemoveAt(index);
            }
        }

        private static void HandleGuess(Socket newClient, string clientName, int guess)
        {
            if (secretNumber == null) return;

            if (guess < secretNumber)
            {
                SendToClient(newClient, "The secret number is higher.");
            }
            else if (guess > secretNumber)
            {
                SendToClient(newClient, "The secret number is lower.");
            }
            else
            {
                BroadcastMessage($"Player {clientName} guessed the number {secretNumber}!");
                StartGame();
            }
        }

        private static void SendToClient(Socket client, string message)
        {
            client.Send(Encoding.ASCII.GetBytes(message + "\n"));
        }
    }

    // -----------------------------------------------
    internal class Program
    {
        static void Main(string[] args)
        {
            Server.Start();
        }
    }
}
