using System.Text;
using Celebration_Of_Capitalism___The_Finale.Models;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Newtonsoft.Json;

namespace Celebration_Of_Capitalism___The_Finale.Services
{
	public class COCProductService : ICOCProductService
    {

        /*
         * COPIED FROM ProudctRepository.cs
         */

        private static IDictionary<string, string> ConvertAttributesFromStringToDict(string string_attributes)
        {
            if (string.IsNullOrEmpty(string_attributes))
            {
                throw new ArgumentException("string_attributes cannot be null or empty");
            }

            const int KEY = 0, VALUE = 1;
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            IEnumerable<string> split_attributes = string_attributes.Split(';');

            foreach (string split_attribute in split_attributes)
            {
                string[] keyValue = split_attribute.Split(':');
                if (keyValue.Length == 2)
                {
                    attributes.Add(keyValue[KEY], keyValue[VALUE]);
                }
            }

            return attributes;
        }

        private static string ConvertAttributesFromDictToString(IDictionary<string, string> dictionary_attributes)
        {
            StringBuilder stringBuilder = new();

            foreach (KeyValuePair<string, string> pair in dictionary_attributes)
            {
                stringBuilder.Append(pair.Key + ':' + pair.Value + ';');
            }

            return stringBuilder.ToString();
        }

        static string endpoint = "http://localhost:5049";

        public int AddProduct(COCProduct product)
        {
            try
            {
                string attributesAsString = ConvertAttributesFromDictToString(product.Attributes);
                COCProductToPostable productToPostable = new COCProductToPostable { Id = product.Id, Attributes = attributesAsString, Brand = product.Brand, Category = product.Category, Description = product.Description, ImageURL = product.ImageURL, Name = product.Name };
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(productToPostable), Encoding.UTF8, "application/json");

                HttpResponseMessage response = Task.Run(() => client.PostAsync(endpoint + "/api/cocproducts", content)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                COCProductToPostable? result = JsonConvert.DeserializeObject<COCProductToPostable>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }

                COCProduct returned = new COCProduct { Id = result.Id, Brand = result.Brand, Category = result.Category, Description = result.Description, Name = result.Name, ImageURL = result.ImageURL, Attributes = ConvertAttributesFromStringToDict(result.Attributes) };

                return returned.Id;
            }
            catch
            {
                return -1;
            }

            // return productRepository.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.DeleteAsync(endpoint + "/api/cocproducts/" + id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            // return productRepository.DeleteProduct(id);
        }

        public IEnumerable<COCProduct> GetAllProducts()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocproducts")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCProductToPostable>? result = JsonConvert.DeserializeObject<List<COCProductToPostable>>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }

                List<COCProduct> returned = new List<COCProduct>();
                result.ForEach(element => returned.Add(new COCProduct { Id = element.Id, Brand = element.Brand, Category = element.Category, Description = element.Description, Name = element.Name, ImageURL = element.ImageURL, Attributes = ConvertAttributesFromStringToDict(element.Attributes) }));

                return returned;
            }
            catch
            {
                return null;
            }

            // return productRepository.GetAllProducts();
        }

        public COCProduct? GetProduct(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocproducts/" + id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                COCProductToPostable? result = JsonConvert.DeserializeObject<COCProductToPostable>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }
                COCProduct returned = new COCProduct { Id = result.Id, Brand = result.Brand, Category = result.Category, Description = result.Description, Name = result.Name, ImageURL = result.ImageURL, Attributes = ConvertAttributesFromStringToDict(result.Attributes) };
                return returned;
            }
            catch
            {
                return null;
            }

            // return productRepository.GetProduct(id);
        }

        public bool UpdateProduct(int id, COCProduct product)
        {
            try
            {
                string attributesAsString = ConvertAttributesFromDictToString(product.Attributes);
                COCProductToPostable productToPostable = new COCProductToPostable { Id = product.Id, Attributes = attributesAsString, Brand = product.Brand, Category = product.Category, Description = product.Description, ImageURL = product.ImageURL, Name = product.Name };
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(productToPostable), Encoding.UTF8, "application/json");

                HttpResponseMessage response = Task.Run(() => client.PutAsync(endpoint + "/api/cocproducts/" + id, content)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                return true;
            }
            catch
            {
                return false;
            }

            // return productRepository.UpdateProduct(id, product);
        }
    }
}
