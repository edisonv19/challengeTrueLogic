using API.Domain.DTOs;
using API.Domain.Entities;
using AutoMapper;

namespace API.BusinessLogic.Mapper.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, HourlySalaryEmployee>();
            CreateMap<Employee, MonthlySalaryEmployee>();
            CreateMap<SalariedEmployee, EmployeeDto>();
        }
    }
}
