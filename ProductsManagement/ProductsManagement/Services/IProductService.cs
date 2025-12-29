using ProductsManagement.Models;

namespace ProductsManagement.Services
{
    public interface IProductService
    {
        IEnumerable<Products> GetAllProducts();
        Products GetProductById(int id);
        void AddProduct(Products product);
        void UpdateProduct(int it, Products product);
        void DeleteProductById(int id);
    }
}
