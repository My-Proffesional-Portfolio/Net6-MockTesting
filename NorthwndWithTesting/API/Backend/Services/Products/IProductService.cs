using API.DataAccess;

namespace API.Backend.Services.Products
{
    public interface IProductService
    {
        List<string> GetProducts();
        Product AddProduct(Product product);
        void DeleteProduct(int productID);
    }
}
