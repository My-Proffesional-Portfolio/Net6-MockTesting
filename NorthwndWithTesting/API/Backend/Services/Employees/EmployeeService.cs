using API.Backend.Repositories.Employees;
using API.DataAccess;

namespace API.Backend.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly NORTHWNDContext _dbContext;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, NORTHWNDContext dbContext)
        {
            _employeeRepository = employeeRepository;
            _dbContext = dbContext;
        }

        public List<string> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll().Select(s => s.FirstName);
            var employeesList = employees.ToList();
            return employeesList;
        }

        public void DeleteEmployee(int employeeId)
        {
            var selectedEmployee = _employeeRepository.GetById(employeeId);
            _employeeRepository.Delete(selectedEmployee);
            _dbContext.SaveChanges();

        }

        public Employee AddEmployee(Employee newEmployee)
        {
            _employeeRepository.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;

        }
    }
}
