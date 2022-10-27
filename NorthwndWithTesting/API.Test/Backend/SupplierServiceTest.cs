using API.Backend.Repositories.Employees;
using API.Backend.Repositories.Suppliers;
using API.Backend.Services.Employees;
using API.Backend.Services.Products;
using API.Backend.Services.Suppliers;
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
    public class SupplierServiceTest
    {

        private Mock<ISupplierRepository> _supplierRepositoryMock;
        private Mock<NORTHWNDContext> _dbContextMock;
        private SupplierService _supplierSC;

        public SupplierServiceTest()
        {
            _supplierRepositoryMock = new Mock<ISupplierRepository>();
            _dbContextMock = new Mock<NORTHWNDContext>();
            _supplierSC = new SupplierService(_supplierRepositoryMock.Object, _dbContextMock.Object);
        }


        [TestMethod]
        public void GetAllSuppliers()
        {
            var suppliers = new List<Supplier>
            {
                new Supplier() { CompanyName = "MockSupplier1", SupplierId = 1 },
                new Supplier() { CompanyName = "MockSupplier2", SupplierId = 2 },
                new Supplier() { CompanyName = "MockSupplier3", SupplierId = 3 },
                new Supplier() { CompanyName = "MockSupplier4", SupplierId = 4 },
                new Supplier() { CompanyName = "MockSupplier5", SupplierId = 5 }
            };

            _supplierRepositoryMock.Setup(s => s.GetAllAsync()).ReturnsAsync(suppliers);

            var suppliersResult = _supplierSC.GetAllSuppliers().GetAwaiter().GetResult();

            Assert.AreEqual(suppliers.Count, suppliersResult.Count);
        }

        [TestMethod]
        public void AddNewSupplier()
        {
            var newSupplier = new Supplier() { CompanyName = "MockSupplier11", SupplierId = 11 };

            _supplierRepositoryMock.Setup(s => s.AddAsync(newSupplier)).ReturnsAsync(newSupplier);
            _dbContextMock.Setup(s => s.SaveChangesAsync(It.IsAny<CancellationToken>())).Verifiable();

            var savedSupplier = _supplierSC.AddSupplier(newSupplier).GetAwaiter().GetResult();

            Assert.AreEqual(newSupplier.SupplierId, savedSupplier.SupplierId);
        }

        [TestMethod]
        public void DeleteSupplier()
        {
            var supplierForDelete = new Supplier() { CompanyName = "MockSupplier12", SupplierId = 12 };
            var supplierQueryable = new List<Supplier>() { supplierForDelete }.AsQueryable();

            _supplierRepositoryMock.Setup(s => s.FindByExpresion(f => f.SupplierId == 12))
                .Returns(supplierQueryable);

            _supplierRepositoryMock.Setup(s => s.Delete(supplierForDelete));
            _dbContextMock.Setup(s => s.SaveChangesAsync(It.IsAny<CancellationToken>())).Verifiable();

            _supplierSC.DeleteSupplier(supplierForDelete.SupplierId);

        }

    }
}
