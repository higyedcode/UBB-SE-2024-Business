using Celebration_Of_Capitalism___The_Finale.Models;

namespace Celebration_Of_Capitalism___The_Finale.Services.Interfaces
{
    public interface IProductService
    {
        int AddProduct(Product product);
        bool DeleteProduct(int id);
        bool UpdateProduct(int id, Product product);
        IEnumerable<Product> GetAllProducts();
        Product? GetProduct(int id);
    }
}
