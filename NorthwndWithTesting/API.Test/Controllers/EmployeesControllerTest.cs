using API.Backend.Services.Employees;
using API.Backend.Services.Products;
using API.Controllers;
using API.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Test.Controllers
{
    

    [TestClass]
    public class EmployeesControllerTest
    {
        private Mock<IEmployeeService> _employeeSCMock;
        private EmployeesController _employeesController;

        public EmployeesControllerTest()
        {
            _employeeSCMock = new Mock<IEmployeeService>();
            _employeesController = new EmployeesController(_employeeSCMock.Object);
        }

        public List<Employee> GetMockEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee() { FirstName = "MockEmployee1", EmployeeId = 1 },
                new Employee() { FirstName = "MockEmployee2", EmployeeId = 2 },
                new Employee() { FirstName = "MockEmployee3", EmployeeId = 3 },
                new Employee() { FirstName = "MockEmployee4", EmployeeId = 4 },
                new Employee() { FirstName = "MockEmployee5", EmployeeId = 5 }
            };
            return employees;
        }
        [TestMethod]
        public void GetTest()
        {
            var employees = GetMockEmployees().Select(s => s.FirstName).ToList();

            _employeeSCMock.Setup(s => s.GetAllEmployees()).Returns(employees);

            var result = _employeesController.Get();
            var okResult = result as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var idForDelete = 2;

            _employeeSCMock.Setup(s => s.DeleteEmployee(idForDelete)).Verifiable();

            var result = _employeesController.Delete(idForDelete);

            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }

        [TestMethod]
        public void PostTest()
        {
            var newEmployee = new Employee() { FirstName = "MockEmployee1", EmployeeId = 11 };

            _employeeSCMock.Setup(s => s.AddEmployee(newEmployee)).Returns(newEmployee);
            var result = _employeesController.Post(newEmployee);

            var okResult = result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
    }
}
