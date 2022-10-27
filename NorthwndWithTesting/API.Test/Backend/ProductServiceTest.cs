using API.Backend;
using API.Backend.Services;
using API.Backend.Services.Products;
using API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Test.Backend
{
    [TestClass]
    public class ProductServiceTest
    {
        private Mock<NORTHWNDContext> _dbContextMock;
        private Mock<IProductService> _productSCMock;
        public ProductServiceTest()
        {
            _dbContextMock = new Mock<NORTHWNDContext>();
            _productSCMock = new Mock<IProductService>();   
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
        public void GetAllProductsTest()
        {
           

            //https://stackoverflow.com/questions/54219742/mocking-ef-core-dbcontext-and-dbset
            //Use the Moq.EntityFrameworkCore package.
            _dbContextMock.Setup(s => s.Products)
                .ReturnsDbSet(GetMockProducts());

            IProductService productSC = new ProductService(_dbContextMock.Object);

            productSC.GetProducts();
        }

        [TestMethod]
        public void DeleteProduct()
        {
            
            _dbContextMock.Setup(s => s.Products)
                 .ReturnsDbSet(GetMockProducts());

            _dbContextMock.Setup(s => s.Remove(It.IsAny<Product>())).Verifiable();

            _dbContextMock.Setup(s => s.SaveChanges()).Verifiable();

            IProductService productSC = new ProductService(_dbContextMock.Object);
            productSC.DeleteProduct(1);
        }

        [TestMethod]
        public void AddProduct()
        {

            var newProduct = new Product() { ProductName = "MockProduct6", ProductId = 6 };


            _dbContextMock.Setup(s => s.Products)
                 .ReturnsDbSet(GetMockProducts());

            _dbContextMock.Setup(s => s.SaveChanges()).Verifiable();

            IProductService productSC = new ProductService(_dbContextMock.Object);
            productSC.AddProduct(newProduct);
        }
    }
}
