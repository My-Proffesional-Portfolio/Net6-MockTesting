using API.DataAccess;

namespace API.Backend.Services.Suppliers
{
    public interface ISupplierService
    {
        Task<List<string>> GetAllSuppliers();
        void DeleteSupplier(int SupplierId);
        Task<Supplier> AddSupplier(Supplier supplier);
    }
}
