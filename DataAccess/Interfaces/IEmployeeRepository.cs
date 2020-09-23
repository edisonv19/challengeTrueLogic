using API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployees();
    }
}
