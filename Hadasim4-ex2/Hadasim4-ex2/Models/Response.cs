using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadasim4_ex2.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        
        public string StatusMessage { get; set; }
        
        public Employee Employee { get; set; }
      
        public List<Employee> ItsEmployees{ get; set; }

        public CoronaDetails corona { get; set; }

        public List<CoronaDetails> itsCoronaDetails { get; set; }

        public List<CoronaSummary> itsCoronaSummary { get; set; }

        public int NotVaccinated { get; set; }
    }
}
