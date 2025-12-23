using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace POST_Server_26._02._2025_CW_
{
    internal class Program
    {
        static string main = @"<html>
                                  <head>
                                      <title>Main page</title>
                                      <meta charset=""utf-8"">
                                  </head>
                                  <body>
                                      <div>
                                          <h1>Введіть текст:</h1>
                                          <form method=""post"">
                                              <input type=""text"" name=""userText"" placeholder=""Введіть щось..."" />
                                              <input type=""submit"" value=""Відправити"" />
                                          </form>
                                      </div>
                                  </body>
                              </html>";

        static string second = @"<html>
                                    <head>
                                        <title>Second page</title>
                                        <meta charset=""utf-8"">
                                    </head>
                                    <body>
                                        <div>
                                            <h1>Ви ввели:</h1>
                                            <p>{text}</p>
                                            <a href=""http://127.0.0.1:80/main/"">На головну</a>
                                        </div>
                                    </body>
                                </html>";

        static string dateTime = @"<html>
                                          <head>
                                              <title>Current Date and Time</title>
                                              <meta charset=""utf-8"">
                                          </head>
                                          <body>
                                              <h1>Дата и время</h1>
                                              <p>{dateTime}</p>
                                              <a href=""http://127.0.0.1:80/main/"">На головну</a>
                                          </body>
                                      </html>";

        static string random = @"<html>
                                       <head>
                                           <title>Random Number</title>
                                           <meta charset=""utf-8"">
                                       </head>
                                       <body>
                                           <h1>Рандомное число</h1>
                                           <p>{randomNumber}</p>
                                           <a href=""http://127.0.0.1:80/main/"">На головну</a>
                                       </body>
                                   </html>";

        static string imagePage = @"<html>
                                        <head>
                                            <title>Random Image</title>
                                            <meta charset=""utf-8"">
                                        </head>
                                        <body>
                                            <h1>Случайное изображение</h1>
                                            <img src=""{imageUrl}"" alt=""Random Image"" />
                                            <a href=""http://127.0.0.1:80/main/"">На головну</a>
                                        </body>
                                    </html>";
        //------------------------------------------------------


        static async Task Main(string[] args)
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://127.0.0.1:80/main/");

            try
            {
                server.Start();
                Console.WriteLine("Waiting for connection...");

                while (true)
                {
                    HttpListenerContext client = await server.GetContextAsync();
                    _ = Task.Run(()=> ManageClient(client));
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { server.Stop(); }
        }

        private static async void ManageClient(HttpListenerContext client)
        {
            HttpListenerRequest request = client.Request;
            HttpListenerResponse response = client.Response;

            if (request.HttpMethod == "GET")
            {
                byte[] buffer = Encoding.UTF8.GetBytes(main);
                response.ContentLength64 = buffer.Length;
                response.ContentType = "text/html; CharSet=UTF-8";

                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
            else if (request.HttpMethod == "POST")
            {
                using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string data = await reader.ReadToEndAsync();
                    string text = data.Split('=')[1];

                    // залежно від запиту юзера виводити йому дані:
                    // 1. сторінка з датою та часом
                    // 2. будь-який api на ваш вибір
                    // 3. рандомне число

                    string textContent = "";

                    if (text.Contains("date"))
                    {
                        textContent = dateTime.Replace("{dateTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else if (text.Contains("random"))
                    {
                        Random rand = new Random();
                        textContent = random.Replace("{randomNumber}", rand.Next(1, 100).ToString());
                    }
                    else if (text.Contains("image"))
                    {
                        string imageUrl = GetRandomImageUrl();
                        textContent = imagePage.Replace("{imageUrl}", imageUrl);
                    }
                    else
                    {
                        textContent = second.Replace("{text}", text);
                    }

                    byte[] buffer = Encoding.UTF8.GetBytes(textContent);
                    response.ContentLength64 = buffer.Length;
                    response.ContentType = "text/html; CharSet=UTF-8";

                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    response.OutputStream.Close();
                }
            }
        }
        private static string GetRandomImageUrl()
        {
            Random rand = new Random();
            int width = rand.Next(200, 800);
            int height = rand.Next(200, 800);
            return $"https://picsum.photos/{width}/{height}";
        }
    }
}
