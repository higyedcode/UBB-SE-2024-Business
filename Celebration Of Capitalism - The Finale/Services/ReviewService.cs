using Celebration_Of_Capitalism___The_Finale.Models;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Celebration_Of_Capitalism___The_Finale.Services
{
    public class ReviewService : IReviewService
    {

        public int AddReview(Review review)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json");
                content.GetType();

                HttpResponseMessage response = Task.Run(() => client.PostAsync("https://localhost:7040/api/reviews", content)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                Review? result = JsonConvert.DeserializeObject<Review>(responseBody);
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
                HttpResponseMessage response = Task.Run(() => client.DeleteAsync("https://localhost:7040/api/reviews/" + id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            // return reviewRepository.DeleteReview(id);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync("https://localhost:7040/api/reviews")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<Review>? result = JsonConvert.DeserializeObject<List<Review>>(responseBody);
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

        public Review? GetReview(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync("https://localhost:7040/api/reviews" + id)).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<Review>? result = JsonConvert.DeserializeObject<List<Review>>(responseBody);
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

        public IEnumerable<Review> GetReviewsForProduct(int productId)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync("https://localhost:7040/api/reviews")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<Review>? result = JsonConvert.DeserializeObject<List<Review>>(responseBody);
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

        public IEnumerable<Review> GetReviewsFromUser(int userId)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = Task.Run(() => client.GetAsync("https://localhost:7040/api/reviews")).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();  // error-prone
                string responseBody = Task.Run(() => response.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
                List<Review>? result = JsonConvert.DeserializeObject<List<Review>>(responseBody);
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

        public bool UpdateReview(int id, Review review)
        {
            try
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json");

                HttpResponseMessage response = Task.Run(() => client.PutAsync("https://localhost:7040/api/reviews" + id, content)).GetAwaiter().GetResult();
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
