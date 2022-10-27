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
    public class ProductControllerTest
    {
        private Mock<IProductService> _productSCMock;
        private ProductsController _productsController;

        public ProductControllerTest()
        {
            _productSCMock = new Mock<IProductService>();
            _productsController = new ProductsController(_productSCMock.Object);
        }

        public List<Product> GetMockProducts()
        {
            var products = new List<Product>
            {
                new Product() { ProductName = "MockProduct1", ProductId = 1 },
                new Product() { ProductName = "MockProduct2", ProductId = 2 },
                new Product() { ProductName = "MockProduct3", ProductId = 3 },
                new Product() { ProductName = "MockProduct4", ProductId = 4 },
                new Product() { ProductName = "MockProduct5", ProductId = 5 }
            };
            return products;
        }
        [TestMethod]
        public void GetTest()
        {
            var products = GetMockProducts().Select(s => s.ProductName).ToList();

            _productSCMock.Setup(s => s.GetProducts()).Returns(products);

            var result = _productsController.Get();
            var okResult = result as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var idForDelete = 12;

            _productSCMock.Setup(s => s.DeleteProduct(idForDelete)).Verifiable();

            var result = _productsController.Delete(idForDelete);

            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }

        [TestMethod]
        public void PostTest()
        {
            var newProduct = new Product() { ProductName = "MockProduct11", ProductId = 11 };

            _productSCMock.Setup(s => s.AddProduct(newProduct)).Returns(newProduct);
            var result = _productsController.Post(newProduct);

            var okResult = result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
    }
}
