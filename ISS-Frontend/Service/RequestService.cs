using ISS_Frontend.Entity;
using System.Net.Http;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;

namespace ISS_Frontend.Service
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient httpClient;

        public RequestService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public void AddRequest(Request request)
        {
            var response = httpClient.PostAsJsonAsync("api/Request/add", request).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add request: {response.ReasonPhrase}");
            }
        }

        public void DeleteRequest(int id)
        {
            var response = httpClient.DeleteAsync($"api/Request/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to delete request: {response.ReasonPhrase}");
            }
        }

        public List<Request> GetAllRequestsInfluencer()
        {
            var response = httpClient.GetAsync("api/Request/getAllRequestsInfluencer").Result;
            if(response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<List<Request>>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve requests: {response.ReasonPhrase}");
            }
        }

        public List<Request> GetAllRequestsAddAccount()
        {
            var response = httpClient.GetAsync("api/Request/getAllRequestsAddAccount").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<List<Request>>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve requests: {response.ReasonPhrase}");
            }
        }

        public Request GetRequestById(int id)
        {
            var response = httpClient.GetAsync($"api/Request/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<Request>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve request: {response.ReasonPhrase}");
            }

        }

        public void UpdateRequest(Request request)
        {
            var response = httpClient.PutAsJsonAsync($"api/Reviews/{request.RequestId}", request).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to update review: {response.ReasonPhrase}");
            }
        }
    }
}
