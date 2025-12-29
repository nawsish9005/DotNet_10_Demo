using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Models;

namespace ProductsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<Products> product = new List<Products>
            {
                new Products {Id=1, Name="Laptop", Description="Laptop", Price=25500.1M},
                new Products {Id=2, Name="Mobile",Description="Mobile", Price=20000.2M},
                new Products { Id = 3, Name = "Bag", Description = "Bag", Price = 1500.5M }
            };

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(product);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(int id)
        {
            var response = product.FirstOrDefault(x => x.Id == id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct(int id, Products products)
        {
            var existProduct = product.FirstOrDefault(p => p.Id == id);
            if (existProduct == null)
            {
                return NotFound();
            }
            existProduct.Name = products.Name;
            existProduct.Description = products.Description;
            existProduct.Price = products.Price;
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id) 
        { 
            var pro = product.FirstOrDefault(x=>x.Id == id);
            if (pro == null)
            {
                return NotFound();
            }
            product.Remove(pro);
            return NoContent(); 
        }
    }
}
