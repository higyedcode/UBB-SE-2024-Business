using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public class AddCollaborationRequest
    {
        public string CollaborationTitle { get; set; }
        public string AdOverview { get; set; }
        public string CollaborationFee { get; set; }
        public string ContentRequirement { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }

    public class CollaborationServiceRest : ICollaborationService
    {
        private readonly HttpClient httpClient;

        public CollaborationServiceRest(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public void AddCollaboration(Collaboration collaboration)
        {
            var addCollaborationRequest = new AddCollaborationRequest
            {
                CollaborationTitle = collaboration.CollaborationTitle,
                AdOverview = collaboration.AdOverview,
                CollaborationFee = collaboration.CollaborationFee,
                ContentRequirement = collaboration.ContentRequirement,
                StartDate = collaboration.StartDate,
                EndDate = collaboration.EndDate,
                Status = collaboration.Status
            };

            HttpResponseMessage response = httpClient.PostAsJsonAsync("api/collaboration/add", addCollaborationRequest).Result;
            response.EnsureSuccessStatusCode();
        }

        public List<Collaboration> GetCollaborationForAdAccount()
        {
            HttpResponseMessage response = httpClient.GetAsync("api/collaboration/for-adaccount").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<List<Collaboration>>().Result;
        }

        public List<Collaboration> GetCollaborationForInfluencer()
        {
            HttpResponseMessage response = httpClient.GetAsync("api/collaboration/for-influencer").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<List<Collaboration>>().Result;
        }

        public List<Collaboration> GetActiveCollaborationForAdAccount()
        {
            HttpResponseMessage response = httpClient.GetAsync("api/collaboration/active-for-adaccount").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<List<Collaboration>>().Result;
        }
    }
}
