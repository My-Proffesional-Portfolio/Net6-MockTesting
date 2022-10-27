using API.Backend.Services.Employees;
using API.Backend.Services.Suppliers;
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
    public class SuppliersControllerTest
    {
        private Mock<ISupplierService> _suppliersSCMock;
        private SuppliersController _suppliersController;

        public SuppliersControllerTest()
        {
            _suppliersSCMock = new Mock<ISupplierService>();
            _suppliersController = new SuppliersController(_suppliersSCMock.Object);
        }

        public List<Supplier> GetMockSuppliers()
        {
            var suppliers = new List<Supplier>
            {
                new Supplier() { CompanyName = "MockSupplier1", SupplierId = 1 },
                new Supplier() { CompanyName = "MockSupplier2", SupplierId = 2 },
                new Supplier() { CompanyName = "MockSupplier3", SupplierId = 3 },
                new Supplier() { CompanyName = "MockSupplier4", SupplierId = 4 },
                new Supplier() { CompanyName = "MockSupplier5", SupplierId = 5 }
            };
            return suppliers;
        }
        [TestMethod]
        public void GetTest()
        {
            var employees = GetMockSuppliers().Select(s => s.CompanyName).ToList();

            _suppliersSCMock.Setup(s => s.GetAllSuppliers()).ReturnsAsync(employees);

            var result = _suppliersController.Get().GetAwaiter().GetResult();
            var okResult = result as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var idForDelete = 2;

            _suppliersSCMock.Setup(s => s.DeleteSupplier(idForDelete)).Verifiable();

            var result = _suppliersController.Delete(idForDelete);

            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }

        [TestMethod]
        public void PostTest()
        {
            var newSupplier = new Supplier() { CompanyName = "MockSupplier1", SupplierId = 11};

            _suppliersSCMock.Setup(s => s.AddSupplier(It.IsAny<Supplier>())).ReturnsAsync(newSupplier);
            var result = _suppliersController.Post(newSupplier).GetAwaiter().GetResult();

            var okResult = result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
    }
}
