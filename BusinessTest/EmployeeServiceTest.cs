using API.BusinessLogic.Interfaces;
using API.BusinessLogic.Mapper;
using API.BusinessLogic.Services;
using API.DataAccess.Interfaces;
using API.Domain.Entities;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTest
{
    [TestClass]
    public class EmployeeServiceTest
    {

        private Mock<IEmployeeRepository> _repositoryMock;
        private IEnumerable<Employee> _employees;
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        public EmployeeServiceTest()
        {
        }

        [TestInitialize]
        public void Initialize()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _mapper = new Mapper(AutoMapperConfiguration.RegisterMappings());
            _employeeService = new EmployeeService(_repositoryMock.Object, _mapper);
            LoadEmployees();
        }

        [TestMethod]
        public void GetEmployees_Ok()
        {
            // Arrange
            _repositoryMock.Setup(x => x.GetEmployees()).Returns(Task.FromResult(_employees));

            // Act
            var employeeDtoList = _employeeService.GetEmployees(null).Result;

            // Assert
            Assert.IsNotNull(employeeDtoList);
            Assert.AreNotEqual(0, employeeDtoList.Count());
            Assert.AreEqual(2, employeeDtoList.Count());

            // HourlySalaryEmployee => 120 * HourlySalary * 12 (HourlySalary = 60)
            Assert.AreEqual(86400, employeeDtoList.ElementAt(0).AnualSalary);

            // MonthlySalaryEmployee => MonthlySalary * 12 (HourlySalary = 6000)
            Assert.AreEqual(72000, employeeDtoList.ElementAt(1).AnualSalary);
        }

        [TestMethod]
        public void GetEmployees_ByID_Ok()
        {
            // Arrange
            _repositoryMock.Setup(x => x.GetEmployees()).Returns(Task.FromResult(_employees));

            // Act
            var employeeDtoList = _employeeService.GetEmployees(1).Result;

            // Assert
            Assert.IsNotNull(employeeDtoList);
            Assert.AreNotEqual(0, employeeDtoList.Count());
            Assert.AreEqual(1, employeeDtoList.Count());

            // HourlySalaryEmployee => 120 * HourlySalary * 12 (HourlySalary = 60)
            Assert.AreEqual(86400, employeeDtoList.ElementAt(0).AnualSalary);
        }

        private void LoadEmployees()
        {
            _employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    Name = "Juan",
                    ContractTypeName = "HourlySalaryEmployee",
                    RoleId = 1,
                    RoleName  = "Administrator",
                    RoleDescription = null,
                    HourlySalary = 60,
                    MonthlySalary = 800
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Sebastian",
                    ContractTypeName = "MonthlySalaryEmployee",
                    RoleId = 2,
                    RoleName  = "Contractor",
                    RoleDescription = null,
                    HourlySalary = 80,
                    MonthlySalary = 6000
                }
            };
        }
    }
}
