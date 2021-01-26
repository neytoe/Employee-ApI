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


        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee (int id)
        {
            
            try
            {
                var findemployee =await _employeeRepository.Find(id);
                if (findemployee == null) return NotFound(id);

                var employee = _mapper.Map<EmployeeDto>(findemployee);
                return Ok(employee);

            }
            catch (Exception e)
            {

                ModelState.AddModelError("Error", e.Message);
            }


            return NotFound(id);

        }

        [HttpGet]
        public async Task<ActionResult<EmployeeDto>> GetAllEmployees()
        {
            try
            {
                var employee = await _employeeRepository.FindAll();

                return Ok(employee);
            }
            catch (Exception e)
            {

                ModelState.AddModelError("Error", e.Message);
            }

            return NotFound();
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee (int id)
        {
              await _employeeRepository.Delete(id);

            var findemployee = await _employeeRepository.Find(id);
            if (findemployee == null)
            {
                return Ok("Employee Successfully deleted");
            }

            
            return BadRequest("Error deleting employee");
        }

    }
}
