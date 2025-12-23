using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._12._2024_CW2
{
    internal class MusicGroup
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string? Genre { get; set; }

        public int? UserId { get; set; }
        public List<User>? User { get; set; }
    }
}
