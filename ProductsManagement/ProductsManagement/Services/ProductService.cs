using ProductsManagement.Data;
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
        public Products AddProduct(Products products)
        {
            var newProduct = context.Products.Add(products);
            context.SaveChanges();
            return newProduct.Entity;
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
