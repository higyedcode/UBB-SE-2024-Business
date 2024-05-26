using Iss.Database;
using Microsoft.EntityFrameworkCore;
using RestApi_ISS.Entity;

namespace RestApi_ISS.Repository
{
    public class ProductRepository : IProductRepository
    {
        private DatabaseContext databaseContext = new DatabaseContext();

        public ProductRepository()
        {
        }

        public void AddProduct(Product product)
        {
            databaseContext.Product.Add(product);
            databaseContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = databaseContext.Product.Find(id);
            if (productToDelete != null)
            {
                databaseContext.Product.Remove(productToDelete);
                databaseContext.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return databaseContext.Product.ToList();
        }

        public Product GetProductById(int id)
        {
            return databaseContext.Product.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            databaseContext.Product.Update(product);
            databaseContext.SaveChanges();
        }
    }
}
