using API.Domain.Entities;
using AutoMapper;
using Infrastructure.Common.Constants;

namespace API.BusinessLogic.Factories
{
    public class EmployeeFactory
    {
        private readonly IMapper _mapper;

        public EmployeeFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public SalariedEmployee GetEmployee(Employee employee)
        {
            switch (employee.ContractTypeName)
            {
                case Constants.HourlySalaryEmployee:
                    return _mapper.Map<HourlySalaryEmployee>(employee);
                case Constants.MonthlySalaryEmployee:
                    return _mapper.Map<MonthlySalaryEmployee>(employee);
                default:
                    return null;
            }
        }
    }
}
