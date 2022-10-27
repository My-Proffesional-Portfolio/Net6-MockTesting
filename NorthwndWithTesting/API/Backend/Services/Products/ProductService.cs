using API.DataAccess;

namespace API.Backend.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly NORTHWNDContext _dbContext;
        public ProductService(NORTHWNDContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int productID)
        {
            var locateProduct = _dbContext.Products.Where(w => w.ProductId == productID).FirstOrDefault();
            _dbContext.Products.Remove(locateProduct);
            _dbContext.SaveChanges();
        }

        public List<string> GetProducts()
        {
            var products = _dbContext.Products.Select(s => s.ProductName).ToList();
            return products;
        }
    }
}
