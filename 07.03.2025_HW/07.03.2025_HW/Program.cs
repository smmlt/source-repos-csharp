using System.Net;
using System.Text;
using System;

namespace _07._03._2025_HW
{
    internal class Program
    {
        static string main = @"<html>
                                  <head>
                                      <title>Main page</title>
                                      <meta charset=\""utf-8\"">
                                  </head>
                                  <body>
                                      <div>
                                          <h1>Введіть текст:</h1>
                                          <form method =\""post\"">
                                              <input type =\""text\"" name=\""userText\"" placeholder=\""Введіть щось...\"" />
                                              <input type =\""submit\"" value=\""Відправити\"" />
                                          </form>
                                      </div>
                                  </body>
                              </html>";

        static string second = @"<html>
                                    <head>
                                        <title>Second page</title>
                                        <meta charset=\""utf-8\"">
                                    </head>
                                    <body>
                                        <div>
                                            <h1>Ви ввели:</h1>
                                            <p>{text}</p>
                                            <a href =\""http://127.0.0.1:80/main/\"">На головну</a>
                                        </div>
                                    </body>
                                </html>";

        static string dateTime = @"<html>
                                          <head>
                                              <title>Current Date and Time</title>
                                              <meta charset=\""utf-8\"">
                                          </head>
                                          <body>
                                              <h1>Дата и время</h1>
                                              <p>{dateTime}</ p >
                                              < a href =\""http://127.0.0.1:80/main/\"">На головну</a>
                                          </ body >
                                      </ html > ";

        static string random = @"<html>
                                       <head>
                                           <title>Random Number</title>
                                           <meta charset=\""utf-8\"">
                                       </head>
                                       <body>
                                           <h1>Рандомное число</h1>
                                           <p>{randomNumber}</ p >
                                           < a href =\""http://127.0.0.1:80/main/\"">На головну</a>
                                       </ body >
                                   </ html > ";

        static string imagePage = @"<html>
                                        <head>
                                            <title>Random Image</title>
                                            <meta charset=\""utf-8\"">
                                        </head>
                                        <body>
                                            <h1>Случайное изображение</h1>
                                            <img src=\""{imageUrl}\"" alt=\""Random Image\"" />
                                            <a href=\""http://127.0.0.1:80/main/\"">На головну</a>
                                        </body>
                                    </html>";

        static string catFactPage = @"<html>
                                        <head>
                                            <title>Cat Fact</title>
                                            <meta charset=\""utf-8\"">
                                        </head>
                                        <body>
                                            <h1>Факт про котиків</h1>
                                            <p>{catFact}</ p >
                                            < a href =\""http://127.0.0.1:80/main/\"">На головну</a>
                                        </ body >
                                    </ html > ";

        static string currencyPage = @"<html>
                                        <head>
                                            <title>Currency Rate</title>
                                            <meta charset=\""utf-8\"">
                                        </head>
                                        <body>
                                            <h1>Курс долара</h1>
                                            <p>1 USD = {usdRate} UAH </ p >
                                            < a href =\""http://127.0.0.1:80/main/\"">На головну</a>
                                        </ body >
                                    </ html > ";

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
                    _ = Task.Run(() => ManageClient(client));
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { server.Stop(); }
        }

        private static async void ManageClient(HttpListenerContext client)
        {
            HttpListenerRequest request = client.Request;
            HttpListenerResponse response = client.Response;

            if (request.HttpMethod == "POST")
            {
                using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string data = await reader.ReadToEndAsync();
                    string text = data.Split('=')[1];
                    string textContent = "";

                    if (text.Contains("date"))
                    {
                        textContent = dateTime.Replace("{dateTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else if (text.Contains("random"))
                    {
                        textContent = random.Replace("{randomNumber}", new Random().Next(1, 100).ToString());
                    }
                    else if (text.Contains("image"))
                    {
                        textContent = imagePage.Replace("{imageUrl}", GetRandomImageUrl());
                    }
                    else if (text.Contains("cat"))
                    {
                        textContent = catFactPage.Replace("{catFact}", await GetCatFact());
                    }
                    else if (text.Contains("currency"))
                    {
                        textContent = currencyPage.Replace("{usdRate}", await GetCurrencyRate());
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
        static async Task<string> GetCatFact()
        {
            using HttpClient client = new HttpClient();
            string json = await client.GetStringAsync("https://catfact.ninja/fact");
            return JObject.Parse(json)["fact"].ToString();
        }

        static async Task<string> GetCurrencyRate()
        {
            using HttpClient client = new HttpClient();
            string json = await client.GetStringAsync("https://api.exchangerate-api.com/v4/latest/UAH");
            return $"1 UAH = {JObject.Parse(json)["rates"]["USD"]} USD";
        }
    }
}
