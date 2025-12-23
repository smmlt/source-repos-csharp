using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17._01._2025_cw
{
    internal class Resume
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string City { get; set; }
        public decimal DesiredSalary { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }

        public override string ToString()
        {
            return $"Name: {FullName}, Age: {Age}, Position: {Position}, City: {City}, Salary: {DesiredSalary}, Phone number: {PhoneNumber}, Email: {Email}, Years of experience: {YearsOfExperience}";
        }
    }
}
