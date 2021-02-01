using APIPractice.Interfaces;
using APIPractice.Model;
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
        public IRoleRepository _roleRepository { get; }

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper, IRoleRepository roleRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }


       [HttpPost]
       public async Task<ActionResult<CreateEmployeeDto>> CreateEmployee (CreateEmployeeDto employee)
        {
            var newemployee = _mapper.Map<Employee>(employee);
            var rolestring = employee.Userrole;
            var roleid = await _roleRepository.search(rolestring);
            newemployee.RoleId = roleid;

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

        [HttpPatch]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(EmployeeDto employee)
        {
            Employee findemployeee = await _employeeRepository.Find(employee.ID);
            

            if (findemployeee == null) return BadRequest("invalid id");

           
            var emp = _mapper.Map<EmployeeDto,Employee>(employee, findemployeee);
            try
            {
                await _employeeRepository.Update(emp);
                var newemployee = _mapper.Map<EmployeeDto>(emp);
                return Ok(newemployee);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
            }
            return BadRequest(employee);
        }

    }
}
