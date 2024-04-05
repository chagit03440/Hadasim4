using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadasim4_ex2.Models
{
    public class CoronaDetails
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public DateTime? VaccineDate { get; set; }
        public string VaccineManufacturers { get; set; }
        
    }
}
