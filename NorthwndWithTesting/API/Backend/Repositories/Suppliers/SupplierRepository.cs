using API.Backend.Repositories.AsyncOperationInterfaces;
using API.DataAccess;

namespace API.Backend.Repositories.Suppliers
{
    public class SupplierRepository : AsyncBaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(NORTHWNDContext dbContext) : base(dbContext)
        {
        }
    }
}
