using System.Text;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Celebration_Of_Capitalism___The_Finale.Models;
using Newtonsoft.Json;

namespace Celebration_Of_Capitalism___The_Finale.Services
{
    public class FavouriteProductService : IFavouriteProductService
    {

        public int AddFavouriteProduct(FavouriteProduct favouriteProduct)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(favouriteProduct), Encoding.UTF8, "application/json");

                List<FavouriteProduct> favourites = GetAllFavouriteProductsOfUser(favouriteProduct.UserId).ToList();
                bool alreadyExists = favourites.Any(product => product.UserId == favouriteProduct.UserId && product.ProductId == favouriteProduct.ProductId);

                if (alreadyExists)
                {
                    throw new Exception("Product is already a favourite!");
                }

                HttpResponseMessage response = Task.Run(() => client.PostAsync("https://localhost:7040/api/favouriteproducts", content)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                FavouriteProduct? result = JsonConvert.DeserializeObject<FavouriteProduct>(responseBody);
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

        public bool DeleteFavouriteProductFromUser(FavouriteProduct favouriteProduct)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.DeleteAsync("https://localhost:7040/api/favouriteproducts/" + favouriteProduct.Id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<FavouriteProduct> GetAllFavouriteProducts()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync("https://localhost:7040/api/favouriteproducts")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<FavouriteProduct>? result = JsonConvert.DeserializeObject<List<FavouriteProduct>>(responseBody);
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

        public IEnumerable<FavouriteProduct> GetAllFavouriteProductsOfUser(int userId)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync("https://localhost:7040/api/favouriteproducts")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<FavouriteProduct>? listFavouriteProduct = JsonConvert.DeserializeObject<List<FavouriteProduct>>(responseBody);
                if (listFavouriteProduct == null)
                {
                    throw new Exception("Fail at getting all favourite products");
                }
                List<FavouriteProduct> result = listFavouriteProduct.Where(favProduct => favProduct.UserId == userId).ToList();
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
                HttpResponseMessage response = Task.Run(() => client.GetAsync("https://localhost:7040/api/favouriteproducts")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<FavouriteProduct>? listFavouriteProduct = JsonConvert.DeserializeObject<List<FavouriteProduct>>(responseBody);
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

        public FavouriteProduct? GetFavouriteProduct(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync("https://localhost:7040/api/favouriteproducts/" + id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                FavouriteProduct? result = JsonConvert.DeserializeObject<FavouriteProduct>(responseBody);
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