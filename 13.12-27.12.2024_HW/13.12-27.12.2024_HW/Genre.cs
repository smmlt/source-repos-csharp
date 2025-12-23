using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._12_27._12._2024_HW
{
    internal class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game>? Games { get; set; } = new();

        public override string ToString() => $"ID: {Id} | {Name} | {Games.Count} Games";
    }
}
