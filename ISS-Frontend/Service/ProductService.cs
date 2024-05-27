using ISS_Frontend.Entity;
using ISS_Frontend.Models;
using System.Net.Http;

namespace ISS_Frontend.Service
{
    public class ProductService : IProductService
    {

        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient) {
            this.httpClient = httpClient;
        }
        public void AddProduct(Product Product)
        {
            var response = httpClient.PostAsJsonAsync("api/Product/AddProduct", Product).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add product: {response.ReasonPhrase}");
            }
        }

        public void EditProduct(Product Product)
        {
            var response = httpClient.PutAsJsonAsync("api/Product/UpdateProduct/" + Product.Id, Product).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to edit product: {response.ReasonPhrase}");
            }
        }

        public Product GetProductById(int ProductId)
        {
            var response = httpClient.GetAsync("api/Product/GetProductById/"+ProductId).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<Product>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve product: {response.ReasonPhrase}");
            }
        }

        public List<Product> GetProducts()
        {
            var response = httpClient.GetAsync("api/Product/GetAllProducts").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<List<Product>>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve products: {response.ReasonPhrase}");
            }
        }

        public void RemoveProduct(int ProductId)
        {
            var response = httpClient.DeleteAsync("api/Product/DeleteProduct/" + ProductId).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to edit product: {response.ReasonPhrase}");
            }
        }
    }
}
