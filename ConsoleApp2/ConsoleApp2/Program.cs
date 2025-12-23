using System.Net;
using System.Text;
using System.Web;

namespace ConsoleApp2
{
    internal class Program
    {
        static string connectionString = @"Server=localhost\SQLEXPRESS;
                                        Database=HospitalServer;
                                        Trusted_Connection=True;
                                        Encrypt=False;
                                        TrustServerCertificate=True";
        static async Task Main()
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://127.0.0.1:80/");
            server.Start();
            Console.WriteLine("Сервер запущен на http://127.0.0.1:80/");

            try
            {
                while (true)
                {
                    HttpListenerContext client = await server.GetContextAsync();
                    _ = Task.Run(() => ManageClient(client));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally { server.Stop(); }
        }

        private static async void ManageClient(HttpListenerContext client)
        {
            HttpListenerRequest request = client.Request;
            HttpListenerResponse response = client.Response;

            if (request.HttpMethod == "GET")
            {
                byte[] buffer = Encoding.UTF8.GetBytes(MainPage());
                response.ContentLength64 = buffer.Length;
                response.ContentType = "text/html; charset=UTF-8";

                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
            else if (request.HttpMethod == "POST")
            {
                using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string data = await reader.ReadToEndAsync();
                    var parameters = HttpUtility.ParseQueryString(data);

                    string fullName = parameters["fullName"];
                    string birthDate = parameters["birthDate"];
                    string symptoms = parameters["symptoms"];

                    string department = GetDepartmentBySymptoms(symptoms);
                    DateTime appointmentTime = GetNextAvailableTime();

                    using (var db = new HospitalContext(connectionString))
                    {
                        var patient = new Patient
                        {
                            FullName = fullName,
                            BirthDate = DateTime.Parse(birthDate),
                            Symptoms = symptoms
                        };

                        db.Patients.Add(patient);
                        db.SaveChanges();

                        var appointment = new Appointment
                        {
                            PatientId = patient.Id,
                            Date = appointmentTime.Date,
                            Time = appointmentTime.TimeOfDay,
                            Department = department
                        };

                        db.Appointments.Add(appointment);
                        db.SaveChanges();
                    }

                    string responseText = $"Запись успешна! Ваш приём {appointmentTime:yyyy-MM-dd HH:mm} в {department}";
                    byte[] buffer = Encoding.UTF8.GetBytes(responseText);
                    response.ContentLength64 = buffer.Length;
                    response.ContentType = "text/plain; charset=UTF-8";

                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    response.OutputStream.Close();
                }
            }
        }
        //private static string MainPage()
        //{
        //    return @"
        //        <html>
        //            <head><title>Запись к врачу</title></head>
        //            <body>
        //                <h1>Добро пожаловать в больницу</h1>
        //                <form method='post'>
        //                    <label>ФИО:</label>
        //                    <input type='text' name='fullName' required/><br>
        //                    <label>Дата рождения:</label>
        //                    <input type='date' name='birthDate' required/><br>
        //                    <label>Симптомы:</label>
        //                    <textarea name='symptoms' required></textarea><br>
        //                    <input type='submit' value='Записаться'/>
        //                </form>
        //            </body>
        //        </html>";
        //}

        private static string MainPage()
        {
            return @"
                    <html>
                        <head>
                            <title>Запись к врачу</title>
                            <style>
                                body {
                                    margin: 0;
                                    height: 100vh;
                                    display: flex;
                                    justify-content: center;
                                    align-items: center;
                                    background-color: #f4f4f9; /* фон для всего экрана */
                                }

                                .form-container {
                                    display: flex;
                                    justify-content: center;
                                    align-items: center;
                                    width: 100%;
                                }

                                .form-wrapper {
                                    background-color: #fff;
                                    border-radius: 8px;
                                    padding: 30px;
                                    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                                    width: 80%;
                                    max-width: 500px;
                                    text-align: center;
                                    margin-bottom: 20px;
                                }

                                label {
                                    font-size: 16px;
                                    margin-bottom: 5px;
                                    display: block;
                                }

                                input[type='text'],
                                input[type='date'],
                                textarea {
                                    width: 100%;
                                    padding: 10px;
                                    margin-bottom: 15px; /* Добавлено расстояние между полями */
                                    border: 1px solid #ddd;
                                    border-radius: 4px;
                                }

                                textarea {
                                    height: 100px;
                                }

                                input[type='submit'] {
                                    background-color: #4CAF50;
                                    color: white;
                                    border: none;
                                    padding: 15px 20px;
                                    cursor: pointer;
                                    font-size: 16px;
                                    width: 100%;
                                    border-radius: 4px;
                                }

                                input[type='submit']:hover {
                                    background-color: #45a049;
                                }
                            </style>
                        </head>
                        <body>
                            <div class='form-container'>
                                <div class='form-wrapper'>
                                    <h1>Записаться на прием к врачу</h1>
                                    <form method='post'>
                                        <label>ФИО:</label>
                                        <input type='text' name='fullName' required /><br>

                                        <label>Дата рождения:</label>
                                        <input type='date' name='birthDate' required /><br>

                                        <label>Симптомы:</label>
                                        <textarea name='symptoms' required></textarea><br>

                                        <input type='submit' value='Записаться' />
                                    </form>
                                </div>
                            </div>
                        </body>
                    </html>";
        }




        private static string GetDepartmentBySymptoms(string symptoms)
        {
            var symptomsLower = symptoms.ToLower();

            if (symptomsLower.Contains("кашель") || symptomsLower.Contains("простуда"))
                return "Терапевт";
            if (symptomsLower.Contains("боль в сердце"))
                return "Кардиолог";
            if (symptomsLower.Contains("головная боль"))
                return "Невролог";
            return "Общий врач";
        }

        private static DateTime GetNextAvailableTime()
        {
            using (var db = new HospitalContext(connectionString))
            {
                DateTime now = DateTime.Now;
                DateTime todayStart = now.Date.AddHours(9);
                DateTime todayEnd = now.Date.AddHours(17).AddMinutes(30);

                var lastAppointment = db.Appointments
                    .Where(a => a.Date >= now.Date)
                    .OrderByDescending(a => a.Date)
                    .ThenByDescending(a => a.Time)
                    .FirstOrDefault();

                DateTime nextTime;

                if (lastAppointment != null)
                {
                    nextTime = lastAppointment.Date.Add(lastAppointment.Time).AddMinutes(30);
                    Console.WriteLine($"Последняя запись: {lastAppointment.Date} {lastAppointment.Time}");
                }
                else
                {
                    nextTime = todayStart;
                    Console.WriteLine("Записей нет");
                }

                if (now >= todayEnd)
                {
                    nextTime = now.Date.AddDays(1).AddHours(9);
                }
                else if (nextTime < now)
                {
                    nextTime = now.AddMinutes(30);
                    if (nextTime > todayEnd)
                        nextTime = now.Date.AddDays(1).AddHours(9);
                }
                Console.WriteLine($"time: {nextTime}");
                return nextTime;
            }
        }

    }
}