using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace _13._12._2024_CW
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
        public List<Game>? Games { get; set; } = new();
    }

    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int StudioId { get; set; }
        public Studio? Studio { get; set; }
        public List<Genre> Genres { get; set; } = new();
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; } = new();
    }

    class MyDBContext : DbContext
    {
        public DbSet<Studio> Studios => Set<Studio>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genres => Set<Genre>();

        string connectionString;

        public MyDBContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using (MyDBContext db = new MyDBContext(@"Server=localhost\SQLEXPRESS;
                                                    Database=GameStudio;
                                                    Trusted_Connection=True;
                                                    Encrypt=False;
                                                    TrustServerCertificate=True"))
            {
                Studio studio1 = new Studio { Name = "Valve",           Country = "USA" };
                Studio studio2 = new Studio { Name = "GSC Game World",  Country = "Ukraine" };
                Studio studio3 = new Studio { Name = "Ubisoft",         Country = "France" };
                db.Studios.AddRange(studio1, studio2, studio3);
                db.SaveChanges();

                Genre genre1 = new Genre { Name = "Shooter" };
                Genre genre2 = new Genre { Name = "RPG" };
                Genre genre3 = new Genre { Name = "Action-Adventure" };
                db.Genres.AddRange(genre1, genre2, genre3);
                db.SaveChanges();

                Game game1 = new Game { Title = "Counter-Strike",     StudioId = studio1.Id };
                Game game2 = new Game { Title = "Half-Life",          StudioId = studio1.Id };
                Game game3 = new Game { Title = "S.T.A.L.K.E.R.",     StudioId = studio2.Id };
                Game game4 = new Game { Title = "S.T.A.L.K.E.R. 2",   StudioId = studio2.Id };
                Game game5 = new Game { Title = "Assassin's Creed",   StudioId = studio3.Id };
                Game game6 = new Game { Title = "Far Cry",            StudioId = studio3.Id };
                db.Games.AddRange(game1, game2, game3, game4, game5, game6);

                game1.Genres.Add(genre1);
                game2.Genres.Add(genre1);
                game3.Genres.Add(genre2);
                game4.Genres.Add(genre2);
                game5.Genres.Add(genre3);
                game6.Genres.Add(genre3);

                db.SaveChanges();

                var studios = db.Studios.Include(s => s.Games).ThenInclude(g => g.Genres).ToList();
                foreach (var studio in studios)
                {
                    Console.WriteLine($"\n{studio.Name} ({studio.Country})");

                    foreach (var game in studio.Games)
                    {
                        Console.Write($"\tGame: {game.Title}\t");

                        foreach (var genre in game.Genres)
                        {
                            Console.Write($" (Genres: {genre.Name})");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
