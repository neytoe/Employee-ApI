using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice
{
    public class CreateEmployeeDto
    {
  
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Userrole { get; set; } = "user";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
    }
}
