using API.BusinessLogic.Factories;
using API.BusinessLogic.Interfaces;
using API.DataAccess.Interfaces;
using API.Domain.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeFactory _employeeFactory;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeeFactory = new EmployeeFactory(_mapper);
        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            var employees = await _employeeRepository.GetEmployees();

            var anualEmployee = employees.Where(x => x.Id == id).Select(y => _employeeFactory.GetEmployee(y)).ToList().FirstOrDefault();

            return _mapper.Map<EmployeeDto>(anualEmployee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees(int? id)
        {
            var employees = await _employeeRepository.GetEmployees();

            var anualEmployees = employees.Where(x => !id.HasValue || x.Id == id.Value).Select(x => _employeeFactory.GetEmployee(x));

            return _mapper.Map<IEnumerable<EmployeeDto>>(anualEmployees);
        }
    }
}
