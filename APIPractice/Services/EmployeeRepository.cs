using APIPractice.Interfaces;
using APIPractice.Model;
using Internclap.Core.Interfaces;
using Internclap.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice.Services
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        

        public EmployeeRepository(EmployeeContext dataContext) : base(dataContext)
        {
           
        }
    }
}
