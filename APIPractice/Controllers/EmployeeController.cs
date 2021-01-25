using APIPractice.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


       [HttpPost]
       public async Task<ActionResult<EmployeeDto>> CreateEmployee (EmployeeDto employee)
        {
            var newemployee = _mapper.Map<Employee>(employee);

            try
            {
              await _employeeRepository.Save(newemployee);

            }
            catch (Exception e)
            {

                ModelState.AddModelError("Error", e.Message);
            }

            return Ok(employee);
        }
    }
}
