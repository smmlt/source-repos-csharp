namespace MusicProfileApp.Models
{
    public class FavoriteBand
    {
        public int Id { get; set; }
        public string BandName { get; set; }

        // Внешний ключ к пользователю
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
