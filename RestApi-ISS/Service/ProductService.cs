using Iss.Repository;
using RestApi_ISS.Entity;
using RestApi_ISS.Repository;

namespace RestApi_ISS.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }
        public void AddProduct(Product product)
        {
            repository.AddProduct(product);
        }

        public void DeleteProduct(int id)
        {
            repository.DeleteProduct(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return repository.GetProductById(id);
        }

        public void UpdateProduct(Product product)
        {
            repository.UpdateProduct(product);
        }
    }
}
