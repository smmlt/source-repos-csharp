using System.Text;
using System.Text.Json;

namespace _16._10_cw
{
    class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int ReleaseYear { get; set; }
        public double Duration { get; set; }
        public string Studio { get; set; }

        public void InputAlbum()
        {
            Console.Write("Enter album title: ");
            Title = Console.ReadLine();

            Console.Write("Enter artist name: ");
            Artist = Console.ReadLine();

            Console.Write("Enter release year: ");
            ReleaseYear = int.Parse(Console.ReadLine());

            Console.Write("Enter album duration (in minutes): ");
            Duration = double.Parse(Console.ReadLine());

            Console.Write("Enter release studio: ");
            Studio = Console.ReadLine();
        }
        public void DisplayAlbum()
        {
            Console.WriteLine("\nAlbum information:");
            Console.WriteLine($"Album title: {Title}");
            Console.WriteLine($"Artist: {Artist}");
            Console.WriteLine($"Release year: {ReleaseYear}");
            Console.WriteLine($"Album duration: {Duration} minutes");
            Console.WriteLine($"Release studio: {Studio}");
        }
        public string SerializeAlbum(Album album)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize(album, options);
        }
        public void SaveToFile(string fileName)
        {
            string? jsonString = SerializeAlbum(this);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                fs.Write(jsonBytes, 0, jsonBytes.Length);
            }
            Console.WriteLine("Album successfully saved to file.");
        }

        public static Album LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found.");
                return null;
            }

            byte[] jsonBytes;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                jsonBytes = new byte[fs.Length];
                fs.Read(jsonBytes, 0, jsonBytes.Length);
            }

            string? jsonString = Encoding.UTF8.GetString(jsonBytes);
            Album album = JsonSerializer.Deserialize<Album>(jsonString);
            Console.WriteLine("Album successfully loaded and deserialized from file.");
            return album;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Album rammsteinAlbum = new Album
            {
                Title = "Mutter",
                Artist = "Rammstein",
                ReleaseYear = 2001,
                Duration = 46.16,
                Studio = "Motor Music"
            };

            string fileName = "rammstein_album.json";
            rammsteinAlbum.SaveToFile(fileName);

            Album loadedAlbum = Album.LoadFromFile(fileName);

            if (loadedAlbum != null)
            {
                loadedAlbum.DisplayAlbum();
            }
        }
    }
}
