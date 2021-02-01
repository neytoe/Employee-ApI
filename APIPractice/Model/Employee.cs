using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice.Model
{
    public class Employee: EmployeeDto
    {
        public int ID { get; set; }
        public int RoleId { get; set; }

      //  public Role Role { get; set; }

       
    }
}
