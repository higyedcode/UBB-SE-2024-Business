using Celebration_Of_Capitalism___The_Finale.Models;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Celebration_Of_Capitalism___The_Finale.Services
{
    public class COCReviewService : ICOCReviewService
    {
        static string endpoint = "http://localhost:5049";
        public int AddReview(COCReview review)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json");
                content.GetType();

                HttpResponseMessage response = Task.Run(() => client.PostAsync(endpoint + "/api/cocreviews", content)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                COCReview? result = JsonConvert.DeserializeObject<COCReview>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }

                return result.Id;
            }
            catch
            {
                return -1;
            }

            // return reviewRepository.AddReview(review);
        }

        public bool DeleteReview(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.DeleteAsync(endpoint + "/api/cocreviews/" + id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            // return reviewRepository.DeleteReview(id);
        }

        public IEnumerable<COCReview> GetAllReviews()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocreviews")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCReview>? result = JsonConvert.DeserializeObject<List<COCReview>>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }
                return result;
            }
            catch
            {
                return null;
            }

            // return reviewRepository.GetAllReviews();
        }

        public COCReview? GetReview(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocreviews" + id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCReview>? result = JsonConvert.DeserializeObject<List<COCReview>>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }
                return result[0]; // TODO: dubious endpoint?
            }
            catch
            {
                return null;
            }
            // return reviewRepository.GetReview(id);
        }

        public IEnumerable<COCReview> GetReviewsForProduct(int productId)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocreviews")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCReview>? result = JsonConvert.DeserializeObject<List<COCReview>>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }
                // TODO: should really have its own end-point, this is slow
                return result.Where(el => el.ProductId == productId);
            }
            catch
            {
                return null;
            }

            // return reviewRepository.GetReviewsForProduct(productId);
        }

        public IEnumerable<COCReview> GetReviewsFromUser(int userId)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync(endpoint + "/api/cocreviews")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<COCReview>? result = JsonConvert.DeserializeObject<List<COCReview>>(responseBody);
                if (result == null)
                {
                    throw new Exception("???");
                }
                // TODO: should really have its own end-point, this is slow
                return result.Where(el => el.UserId == userId);
            }
            catch
            {
                return null;
            }

            // return reviewRepository.GetReviewsFromUser(userId);
        }

        public bool UpdateReview(int id, COCReview review)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json");

                HttpResponseMessage response = Task.Run(() => client.PutAsync(endpoint + "/api/cocreviews" + id, content)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                return true;
            }
            catch
            {
                return false;
            }

            // return reviewRepository.UpdateReview(id, review);
        }
    }
}
