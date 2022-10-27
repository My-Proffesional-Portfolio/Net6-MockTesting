using API.DataAccess;

namespace API.Backend.Services.Employees
{
    public interface IEmployeeService
    {
        List<string> GetAllEmployees();
        Employee AddEmployee(Employee newEmployee);
        void DeleteEmployee(int employeeId);
    }
}
