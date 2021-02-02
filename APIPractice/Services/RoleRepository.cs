using APIPractice.Data;
using APIPractice.Interfaces;
using APIPractice.Model;
using Internclap.Core.Interfaces;
using Internclap.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice.Services
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly EmployeeContext _dataContext;

        public RoleRepository(EmployeeContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<int> search (string rolename)
        {
            var id = await _dataContext.Roles.Where(c => rolename.ToLower() == c.Name.ToLower()).Select(c => c.Id).FirstOrDefaultAsync();
            return id;
        }
    }
}
