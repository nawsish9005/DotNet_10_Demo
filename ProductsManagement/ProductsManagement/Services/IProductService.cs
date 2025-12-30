using ProductsManagement.DTOs;
using ProductsManagement.Models;

namespace ProductsManagement.Services
{
    public interface IProductService
    {
        IEnumerable<Products> GetAllProducts();
        Products GetProductById(int id);
        ProductResponseDto AddProduct(ProductRequestDto products);
        void UpdateProduct(int id, Products product);
        void DeleteProductById(int id);
    }
}
