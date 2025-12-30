using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.DTOs;
using ProductsManagement.Models;
using ProductsManagement.Services;

namespace ProductsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;
        public ProductsController(IProductService productService)
        {
            service = productService;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(service.GetAllProducts());
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(int id)
        {
            var response = service.GetProductById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductRequestDto products)
        {
            var pro = service.AddProduct(products);
            return CreatedAtAction(nameof(GetProductById), new {id=pro.Id}, pro);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct(int id, Products products)
        {
            try
            {
                service.UpdateProduct(id, products);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id) 
        {
            try
            {
                service.DeleteProductById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
