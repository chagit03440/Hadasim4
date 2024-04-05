using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadasim4_ex2.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? PositiveResultDate { get; set; }
        public DateTime? RecoveryDate { get; set; }
        public string? PhotoPath { get; set; } // Path to store the uploaded photo

    }
}
