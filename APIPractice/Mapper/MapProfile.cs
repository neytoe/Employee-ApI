using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice.Mapper
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
