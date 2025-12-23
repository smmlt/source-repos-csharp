using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._12._2024_CW2
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Country { get; set; } 
        public bool? IsSubscription { get; set; }
        public List<MusicGroup> MusicGroup { get; set; }

        public int? LogInId { get; set; }
        public LogIn LogIn { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | {Name} | Birth date: {BirthDate} | Country: {Country} |" +
                   $" Subscription: {IsSubscription.HasValue} (Favorit music groups: {MusicGroup}";
        }
    }
}
