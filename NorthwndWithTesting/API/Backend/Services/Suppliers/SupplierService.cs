using API.Backend.Repositories.Employees;
using API.Backend.Repositories.Suppliers;
using API.DataAccess;

namespace API.Backend.Services.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly NORTHWNDContext _dbContext;
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository, NORTHWNDContext dbContext)
        {
            _supplierRepository = supplierRepository;
            _dbContext = dbContext;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            var newSupplier = await _supplierRepository.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
            return newSupplier;

        }

        public async void DeleteSupplier(int SupplierId)
        {
            var supplierForDelete = _supplierRepository.FindByExpresion(f=> f.SupplierId == SupplierId).FirstOrDefault();
            _supplierRepository.Delete(supplierForDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<string>> GetAllSuppliers ()
        {
            var allSuppliers = await _supplierRepository.GetAllAsync();
            var allSuppliersList =  allSuppliers.Select(s=> s.CompanyName).ToList();
            return allSuppliersList;
        }
    }
}
