using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Server_V4_05._02._2025_CW
{
    public static class Server
    {
        public static List<Client> clients = new List<Client>();
        public static Socket? ServerSocket {  get; set; }
        public static MainWindow? Window { get; set; }

        public static void Start()
        {
            Window = Application.Current.MainWindow as MainWindow;

            ServerSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );

            ServerSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80));
            ServerSocket.Listen(100);

            ListViewItem item = new ListViewItem();
            item.Foreground= Brushes.DarkSeaGreen;
            item.Content = "Server online";
            item.HorizontalAlignment = HorizontalAlignment.Center;
            Window?.LvChat.Items.Add(item);

            Task.Run(WaitForClients);
        }

        public static void WaitForClients()
        {
            while (true)
            {
                Socket? clientSocket = ServerSocket.Accept();
                /*clientSocket.Send(Encoding.ASCII.GetBytes("Hello! What is your name?"));*/

                Task.Run(() => ManageClient(clientSocket));
            }
        }

        public static Client FillClient(Socket? clientSocket, string? login)
        {
            Client client = new Client();
            Random random = new Random();

            client.Login = login;
            client.Socket = clientSocket;
            client.DateOfConnection = DateTime.Now;
            client.ColorBrush = new SolidColorBrush(Color.FromRgb(
                (byte)random.Next(0, 255),
                (byte)random.Next(0, 255),
                (byte)random.Next(0, 255)
                ));

            return client;
        }

        public static void ManageClient(Socket clientSocket)
        {
            bool clientFilled = false;
            Client client = new Client();

            byte[] buffer = new byte[1024];
            int bytesCount;

            try
            {
                while ((bytesCount = clientSocket.Receive(buffer)) > 0)
                {
                    if (!clientFilled)
                    {
                        string login = Encoding.ASCII.GetString(buffer, 0, bytesCount);
                        client = FillClient(clientSocket, login);
                        clients.Add(client);

                        clientSocket.Send(Encoding.ASCII.GetBytes($"Welcome, {client.Login}!"));
                        clientFilled = true;

                        Window?.Dispatcher.Invoke(() => Window?.LvClients.Items.Add(client));
                        Window?.Dispatcher.Invoke(() => Window?.LvChat.Items.Add($"{DateTime.Now} connected {client.Login}"));
                        Window?.Dispatcher.Invoke(() =>
                        {
                            if (Window != null) Window.labelClients.Content = $"Clients {clients.Count}";
                        });
                    }
                    else
                    {
                        string message = Encoding.ASCII.GetString(buffer, 0, bytesCount);
                        PrintMessage(message, client.ColorBrush.Color);
                    }
                }
            }
            catch { }
            finally 
            {
                clientSocket?.Close();
                clients.Remove(client);
                Window?.Dispatcher.Invoke(() => Window?.LvChat.Items.Add($"{DateTime.Now} disconnected {client.Login}"));
                Window?.Dispatcher.Invoke(() => Window?.LvClients.Items.Remove(client));
                Window?.Dispatcher.Invoke(() =>
                {
                    if (Window != null) Window.labelClients.Content = $"Clients {clients.Count}";
                });
            }
        }

        public static void PrintMessage(string? message, Color color)
        {
            Window?.Dispatcher.Invoke(() => {
                ListViewItem item = new ListViewItem()
                {
                    Content = message,
                    Foreground = new SolidColorBrush(color)
                };
                Window?.LvChat?.Items.Add(item);
            });
        }
    }
}
