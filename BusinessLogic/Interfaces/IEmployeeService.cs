﻿using API.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeDto>> GetEmployees();
        public Task<EmployeeDto> GetEmployee(int id);
    }
}
