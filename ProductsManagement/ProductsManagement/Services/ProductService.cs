using ProductsManagement.Data;
using ProductsManagement.DTOs;
using ProductsManagement.Models;

namespace ProductsManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;
        public ProductService(AppDbContext appDbContext)
        {
            context = appDbContext;
        }
        public ProductResponseDto AddProduct(ProductRequestDto productRequestDto)
        {
            var product = new Products
            {
                Id = 0,
                Name = productRequestDto.Name,
                Description = productRequestDto.Description,
                Price = productRequestDto.Price,
            };

            var newProduct = context.Products.Add(product);
            context.SaveChanges();

            var response = new ProductResponseDto
            {
                Id = newProduct.Entity.Id,
                Name = newProduct.Entity.Name,
                Description = newProduct.Entity.Description,
                Price = newProduct.Entity.Price,
            };
            return response;
        }

        public void DeleteProductById(int id)
        {
            var product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            
        }

        public IEnumerable<Products> GetAllProducts()
        {
            var products = context.Products.ToList();
            return products;
        }

        public Products GetProductById(int id)
        {
            var product = context.Products.Find(id);
            return product;
        }

        public void UpdateProduct(int id, Products product)
        {
            var existProduct = context.Products.Find(id);
            if (existProduct != null)
            {
                existProduct.Name = product.Name;
                existProduct.Description = product.Description;
                existProduct.Price = product.Price;
                context.SaveChanges();
            }
        }
    }
}
