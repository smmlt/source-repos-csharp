using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _20._12._2024_HW
{
    internal class League
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }

        public List<Player>? Players { get; set; } = new();

        public override string ToString() => $"{Id}: {Name} - {Description}";
    }
}
