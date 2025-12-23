using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._12._2024_CW2
{
    internal class Game
    {
        public int id {  get; set; }
        public string Name { get; set; }
        public string? Genre { get; set; }
        public DateOnly? YearOfPublication { get; set; }
        public double? Rating { get; set; }
        public bool? Selling { get; set; }

        public override string ToString() => $"{Name}\t | {Genre}\t | {YearOfPublication}\t | {Rating}\t | {Selling}";
    }
}
