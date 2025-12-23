using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._12._2024_CW2
{
    internal class LogIn
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int? UserId { get; set; }
        public User ThisUser { get; set; }
    }
}
