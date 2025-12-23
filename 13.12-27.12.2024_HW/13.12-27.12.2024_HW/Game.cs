using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._12_27._12._2024_HW
{
    internal class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly? ReleaseYear { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; } = new();

        public override string ToString()
        {
            return $"ID: {Id} | {Title} | Realese year: {ReleaseYear} (Studio: {Studio?.Name}, Genre: {Genre?.Name})";
        }
    }
}
