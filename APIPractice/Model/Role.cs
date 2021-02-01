using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public List<Employee> Employees { get; set; }
    }
}
