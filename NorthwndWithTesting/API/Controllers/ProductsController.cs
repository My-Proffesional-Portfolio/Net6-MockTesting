using API.Backend.Services.Products;
using API.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productSC;
        public ProductsController(IProductService productSC)
        {
            _productSC = productSC;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productSC.GetProducts();
            return Ok(products);
        }
     
        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            var newProduct = _productSC.AddProduct(value);
            return Ok(newProduct);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productSC.DeleteProduct(id);
            return Ok();
        }
    }
}
