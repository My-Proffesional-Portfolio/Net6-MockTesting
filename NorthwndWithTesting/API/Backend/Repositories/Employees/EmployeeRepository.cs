using API.Backend.Repositories.SyncOperationsInterfaces;
using API.DataAccess;

namespace API.Backend.Repositories.Employees
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NORTHWNDContext dbContext) : base(dbContext)
        {
        }
    }
}
