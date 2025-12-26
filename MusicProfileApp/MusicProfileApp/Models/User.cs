using System;
using System.Collections.Generic;

namespace MusicProfileApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public bool Newsletter { get; set; }

        // Связь с любимыми группами
        public List<FavoriteBand> FavoriteBands { get; set; } = new List<FavoriteBand>();
    }
}
