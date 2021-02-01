using APIPractice.Model;
using Internclap.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice.Interfaces
{
    public interface IRoleRepository: IRepository<Role>
    {
        Task<int> search(string rolename);
    }
}
