using ISS_Frontend.Entity;
using ISS_Frontend.Models;

namespace ISS_Frontend.Service
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product GetProductById(int productId);
        public void AddProduct(Product product);
        public void RemoveProduct(int productId);
        public void EditProduct(Product product);

    }
}
