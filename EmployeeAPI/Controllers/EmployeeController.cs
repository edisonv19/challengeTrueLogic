using API.BusinessLogic.Interfaces;
using API.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeDto> GetEmployees([FromRoute] int id)
        {
            var employeelist = await _employeeService.GetEmployee(id);
            return employeelist;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var employeelist = await _employeeService.GetEmployees();
            return employeelist;
        }
    }
}
