using API.Backend.Services.Employees;
using API.Backend.Services.Suppliers;
using API.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierSC;
        public SuppliersController(ISupplierService suppliersSC)
        {
            _supplierSC = suppliersSC;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allSuppliers = await _supplierSC.GetAllSuppliers();
            return Ok(allSuppliers);
        }


        // POST api/<SuppliersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Supplier value)
        {
            var newSupplier = await _supplierSC.AddSupplier(value);
            return Ok(newSupplier);
        }



        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _supplierSC.DeleteSupplier(id);
            return Ok();
        }
    }
}
