using Microsoft.EntityFrameworkCore;

namespace _11._12._2024_CW
{
    class Quest
    {
        public int id { get; set; }
        public string Title { get; set; }
        public decimal? Reward { get; set; }

        public int? PlayerId { get; set; }
        public Player? Player { get; set; }
    }

    class Player
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public int? GuildId { get; set; }
        public Guild? Guild { get; set; }

        public List<Quest> Quests { get; set; } = new List<Quest>();
    }

    class Guild
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; } = new List<Player> { };
    }

    class MYDBContext : DbContext
    {
        public DbSet<Quest> Quests => Set<Quest>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Guild> Guilds => Set<Guild>();

        string connectString;

        public MYDBContext(string connectString)
        {
            this.connectString = connectString;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectString);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using (MYDBContext db = new MYDBContext(@"Server=localhost\SQLEXPRESS;
                                                      Database=Game;
                                                      Trusted_Connection=True;
                                                      Encrypt=False;
                                                      TrustServerCertificate=True"))
            {
                // добавить
                Guild g1 = new Guild() { Name = "Aliance"};
                Guild g2 = new Guild() { Name = "Horda" };
                db.Guilds.AddRange(g1, g2);
                db.SaveChanges();

                Player p1 = new Player() { Name = "Jack", Level = 1,    GuildId = g1.id };
                Player p2 = new Player() { Name = "Anna", Level = 10,   GuildId = g1.id };
                Player p3 = new Player() { Name = "Mark", Level = 7,    GuildId = g2.id };
                db.Players.AddRange(p1, p2, p3);
                db.SaveChanges();

                Quest q1 = new Quest() { Title = "Find princess",   Reward = 5,    PlayerId = p1.id };
                Quest q2 = new Quest() { Title = "Defeat boss",     Reward = 10,   PlayerId = p2.id };
                Quest q3 = new Quest() { Title = "Not die",         Reward = 1,    PlayerId = p3.id };
                Quest q4 = new Quest() { Title = "Escape",          Reward = 2,    PlayerId = p3.id };
                db.Quests.AddRange(q1, q2, q3, q4);
                db.SaveChanges();

                // Include().ThenInclude()

                var quests = db.Quests
                    .Include(p => p.Player)
                    .ThenInclude(g => g.Guild)
                    .ToList();

                foreach (var q in quests)
                {
                    Console.WriteLine($"{q.Title} | {q.Player?.Name} | {q.Player?.Guild?.Name}");
                }
            }
        }
    }
}
