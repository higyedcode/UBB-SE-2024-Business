using Celebration_Of_Capitalism___The_Finale.Models;

namespace Celebration_Of_Capitalism___The_Finale.Services.Interfaces
{
    public interface ICOCProductService
    {
        int AddProduct(COCProduct product);
        bool DeleteProduct(int id);
        bool UpdateProduct(int id, COCProduct product);
        IEnumerable<COCProduct> GetAllProducts();
        COCProduct? GetProduct(int id);
    }
}
