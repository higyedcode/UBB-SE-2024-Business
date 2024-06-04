using ISS_Frontend.Entity;
using System.Net.Http;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;

namespace ISS_Frontend.Service
{
    public class InfluencerService : IInfluencerService
    {

        private readonly HttpClient _httpClient;

        public InfluencerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void AddInfluencer(Influencer influencer)
        {
            var response = this._httpClient.PostAsJsonAsync("api/Influencer/add", influencer).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add influencer: {response.ReasonPhrase}");
            }
        }

        public void DeleteInfluencer(int id)
        {
            var response = _httpClient.DeleteAsync($"api/Influencer/delete/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to delete influencer: {response.ReasonPhrase}");
            }
        }

        public List<Influencer> GetAllInfluencers()
        {
            var response = _httpClient.GetAsync("api/Review/getAllInfluencers").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<List<Influencer>>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve influencer: {response.ReasonPhrase}");
            }
        }

        public Influencer GetInfluencerById(int id)
        {
            var response = _httpClient.GetAsync($"api/Influencer/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<Influencer>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve influencer: {response.ReasonPhrase}");
            }
        }

        public void UpdateInfluencer(Influencer influencer)
        {
            var response = _httpClient.PutAsJsonAsync($"api/Reviews/update", influencer).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to update influencer: {response.ReasonPhrase}");
            }
        }
    }
}
