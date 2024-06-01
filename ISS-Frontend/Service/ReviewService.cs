using ISS_Frontend.Entity;
using System.Net.Http;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;

namespace ISS_Frontend.Service
{
    public class ReviewService : IReviewService
    {
        private static readonly ReviewService TheInstance = new(new HttpClient());
        private readonly HttpClient httpClient;

        public ReviewService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public static ReviewService Instance
        {
            get { return TheInstance; }
        }

        public List<ReviewClass> GetAllReviews()
        {
            var response = httpClient.GetAsync("api/Review/getallReviews").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<List<ReviewClass>>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve reviews: {response.ReasonPhrase}");
            }
        }

        public ReviewClass GetReviewById(int id)
        {
            var response = httpClient.GetAsync($"api/Reviews/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<ReviewClass>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve review: {response.ReasonPhrase}");
            }
        }

        public void AddReview(ReviewClass review)
        {
            var response = httpClient.PostAsJsonAsync("api/Review/add", review).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add review: {response.ReasonPhrase}");
            }
        }

        public void UpdateReview(ReviewClass review)
        {
            var response = httpClient.PutAsJsonAsync($"api/Reviews/{review.Id}", review).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to update review: {response.ReasonPhrase}");
            }
        }

        public void DeleteReview(int id)
        {
            var response = httpClient.DeleteAsync($"api/Reviews/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to delete review: {response.ReasonPhrase}");
            }
        }
    }
}
