using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game_x_0__07._02._2025_CW
{
    public partial class MainWindow : Window
    {
        List<Button> btnCollection;
        int[] field = new int[9];

        Socket serverSocket;
        Socket clientSocket;

        bool myMove = false;


        int[][] winCombinations =
            [
                [0, 1, 2], 
                [3, 4, 5], 
                [ 6, 7, 8],

                [ 0, 3, 6], 
                [ 1, 4, 7], 
                [ 2, 5, 8],

                [ 0, 4, 8], 
                [ 2, 4, 6]
            ];
                

//---------------------------------------
public MainWindow()
        {
            InitializeComponent();

            btnCollection = grid.Children.OfType<Button>().Where(x => x.Name != "btnStart").ToList();

            foreach (var btn in btnCollection)
            {
                btn.IsEnabled = false;
                btn.Click += Btn_Click;
            }

            btnStart.Click += BtnStart_Click;
        }

        //---------------------------------------
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80));
                serverSocket.Listen(10);

                label.Content = "Server online";
                label.Foreground = new SolidColorBrush(Colors.Lime);

                btnStart.IsEnabled = false;
                btnStart.Background = new SolidColorBrush(Colors.Gray);

                Task.Run(WaitForClient);
            }
            catch { }
            
        }

        private void WaitForClient()
        {
            clientSocket = serverSocket?.Accept();
            myMove = Convert.ToBoolean(new Random().Next(0, 2));
            clientSocket.Send(Encoding.ASCII.GetBytes(myMove ? "Enemy move" : "Your move"));

            Dispatcher.Invoke(() => {
                if (myMove)
                {
                    label.Content = "Your move";
                }
                else { label.Content = "Enemy move";  }

                label.Foreground = new SolidColorBrush(Colors.Green);

                foreach (var btn in btnCollection)
                {
                    btn.IsEnabled = true;
                    btn.Background = new SolidColorBrush(Colors.Gray);
                }
            });

            Task.Run(GameLogic);
        }

        private void GameLogic()
        {
            byte[] buffer = new byte[10];
            int bytesCount;

            try
            {
                while (true)
                {
                    if (myMove) Dispatcher.Invoke(() => label.Content = "Your move");
                    else 
                    {
                        Dispatcher.Invoke(() => label.Content = "Enemy move");
                        clientSocket?.Send(Encoding.ASCII.GetBytes("\rInput number from 1 to 9: "));

                        if ((bytesCount = clientSocket.Receive(buffer)) > 0)
                        {
                            int number = buffer[0] - 48;

                            if (number > 0 && number < 10) 
                            {
                                Dispatcher?.Invoke(() =>
                                {
                                    Button btn = btnCollection[number - 1];
                                    int value = field[number - 1];

                                    if (value == 0)
                                    {
                                        field[number -1 ] = 2;
                                        btn.Background = new SolidColorBrush(Colors.Red);
                                        myMove = true;

                                        int winner = CheckWinner();
                                        if (winner > 0)
                                        {
                                            Dispatcher.Invoke(() => MessageBox.Show(winner == 1 ? "You win!" : "Enemy wins!"));
                                            Application.Current.Shutdown();
                                        }
                                        else if (winner == -1)
                                        {
                                            Dispatcher.Invoke(() => MessageBox.Show("It's a draw!"));
                                            Application.Current.Shutdown();
                                        }
                                    }
                                });
                            }
                        }
                    }
                }

            }
            catch { }
            finally
            {
                clientSocket?.Close();
                Application.Current.Shutdown();
            }
        }

        //---------------------------------------
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (myMove)
            {
                Button? btn = sender as Button;
                int index = btnCollection.IndexOf(btn);
                int value = field[index];

                if (value == 0)
                {
                    field[index] = 1;
                    btn.Background = new SolidColorBrush(Colors.Blue);
                    myMove = false;

                    int winner = CheckWinner();
                    if (winner > 0)
                    {
                        Dispatcher.Invoke(() => MessageBox.Show(winner == 1 ? "You win!" : "Enemy wins!"));
                        Application.Current.Shutdown();
                    }
                    else if (winner == -1)
                    {
                        Dispatcher.Invoke(() => MessageBox.Show("It's a draw!"));
                        Application.Current.Shutdown();
                    }
                }
            }
        }

        private int CheckWinner()
        {
            foreach (var comb in winCombinations)
            {
                int a = comb[0];
                int b = comb[1];
                int c = comb[2];

                if (field[a] != 0 && field[a] == field[b] && field[b] == field[c])
                {
                    return field[a];
                }
            }
            return field.Contains(0) ? 0 : -1;
        }

    }
}