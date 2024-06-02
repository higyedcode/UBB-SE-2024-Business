using System.Text;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Celebration_Of_Capitalism___The_Finale.Models;
using Newtonsoft.Json;

namespace Celebration_Of_Capitalism___The_Finale.Services
{
    public class COCFavouriteProductService : ICOCFavouriteProductService
    {
        static string endpoint = "http://localhost:5049";
        public int AddFavouriteProduct(COCFavouriteProduct favouriteProduct)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(favouriteProduct), Encoding.UTF8, "application/json");

                List<COCFavouriteProduct> favourites = GetAllFavouriteProductsOfUser(favouriteProduct.UserId).ToList();
                bool alreadyExists = favourites.Any(product => product.UserId == favouriteProduct.UserId && product.ProductId == favouriteProduct.ProductId);

                if (alreadyExists)
                {
                    throw new Exception("Product is already a favourite!");
                }

                HttpResponseMessage response = Task.Run(() => client.PostAsync(endpoint + "/api/cocfavouriteproducts", content)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                COCFavouriteProduct? result = JsonConvert.DeserializeObject<COCFavouriteProduct>(responseBody);
                if (result == null)
                {
                    throw new Exception("Add new favourite product failed");
                }

                return result.Id;
            }
            catch
            {
                return -1;
            }
        }

        public bool DeleteFavouriteProductFromUser(COCFavouriteProduct favouriteProduct)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.DeleteAsync(endpoint + "/api/cocfavouriteproducts/" + favouriteProduct.Id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<COCFavouriteProduct> GetAllFavouriteProducts()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocfavouriteproducts")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCFavouriteProduct>? result = JsonConvert.DeserializeObject<List<COCFavouriteProduct>>(responseBody);
                if (result == null)
                {
                    throw new Exception("Fail at getting all favourite products");
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<COCFavouriteProduct> GetAllFavouriteProductsOfUser(int userId)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocfavouriteproducts")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCFavouriteProduct>? listFavouriteProduct = JsonConvert.DeserializeObject<List<COCFavouriteProduct>>(responseBody);
                if (listFavouriteProduct == null)
                {
                    throw new Exception("Fail at getting all favourite products");
                }
                List<COCFavouriteProduct> result = listFavouriteProduct.Where(favProduct => favProduct.UserId == userId).ToList();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<int> GetAllUserIdsWhoMarkedProductAsFavourite(int productId)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocfavouriteproducts")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCFavouriteProduct>? listFavouriteProduct = JsonConvert.DeserializeObject<List<COCFavouriteProduct>>(responseBody);
                if (listFavouriteProduct == null)
                {
                    throw new Exception("Fail at getting all favourite products");
                }
                var result = from favProduct in listFavouriteProduct
                             where favProduct.ProductId == productId
                             select favProduct.UserId;
                return result.ToList();
            }
            catch
            {
                return null;
            }
        }

        public COCFavouriteProduct? GetFavouriteProduct(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocfavouriteproducts/" + id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                COCFavouriteProduct? result = JsonConvert.DeserializeObject<COCFavouriteProduct>(responseBody);
                if (result == null)
                {
                    throw new Exception("Failed to get favourite product by id");
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}