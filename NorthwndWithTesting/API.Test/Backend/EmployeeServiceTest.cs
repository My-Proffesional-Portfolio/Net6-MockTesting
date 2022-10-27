using API.Backend.Repositories.Employees;
using API.Backend.Services.Employees;
using API.DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Test.Backend
{
    [TestClass]
    public class EmployeeServiceTest
    {

        private Mock<IEmployeeRepository> _employeeRepositoryMock;
        private Mock<NORTHWNDContext> _dbContextMock;
        private EmployeeService _employeeSC;
        public EmployeeServiceTest()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();  
            _dbContextMock = new Mock<NORTHWNDContext>();
            _employeeSC = new EmployeeService(_employeeRepositoryMock.Object, _dbContextMock.Object);
        }

        [TestMethod]
        public void GetAllEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee() { FirstName = "MockEmployee1", EmployeeId = 1 },
                new Employee() { FirstName = "MockEmployee2", EmployeeId = 2 },
                new Employee() { FirstName = "MockEmployee3", EmployeeId = 3 },
                new Employee() { FirstName = "MockEmployee4", EmployeeId = 4 },
                new Employee() { FirstName = "MockEmployee5", EmployeeId = 5 }
            };

            _employeeRepositoryMock.Setup(s=> s.GetAll()).Returns(employees);
            var employeesList = _employeeSC.GetAllEmployees();

            Assert.AreEqual(employees.Count, employeesList.Count);

        }

        [TestMethod]
        public void AddEmployee()
        {
            var neEmployee =
                new Employee() { FirstName = "MockEmployee1", EmployeeId = 10 };

            _employeeRepositoryMock.Setup(s => s.Add(neEmployee)).Verifiable();
            _dbContextMock.Setup(s => s.SaveChanges()).Verifiable();

            var newEmploeeAdded = _employeeSC.AddEmployee(neEmployee);

            Assert.AreEqual(neEmployee.FirstName, newEmploeeAdded.FirstName);

        }

        [TestMethod]
        public void DeleteEmployee()
        {
            var employeeForDelete =
                new Employee() { FirstName = "MockEmployee11", EmployeeId = 11 };

            _employeeRepositoryMock.Setup(s => s.GetById(employeeForDelete.EmployeeId)).Returns(employeeForDelete);
            _employeeRepositoryMock.Setup(s => s.Delete(employeeForDelete)).Verifiable();
            _dbContextMock.Setup(s => s.SaveChanges()).Verifiable();

           _employeeSC.DeleteEmployee(employeeForDelete.EmployeeId);

        }
    }
}
