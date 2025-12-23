using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._12._2024_HW
{
    internal class Player
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Position { get; set; }
        [Range(18,45)]
        public int Age { get; set; }

        public int? LeagueId { get; set; }
        [ForeignKey("LeagueId")]
        public League? League { get; set; }

        public override string ToString() => $"{Id}: {Name}, {Position}, {Age} age (League: {LeagueId})";
    }
}
