using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public class AddAdSetRequest
    {
        public string Name { get; set; }

        public string TargetAudience { get; set; }

        public List<string> AdsNames { get; set; }
    }

    public class UpdateAdSetRequest
    {
        public string AdSetId { get; set; }
        public string Name { get; set; }
        public string TargetAudience { get; set; }
    }

    public class AdSetServiceRest : IAdSetService
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl;

        public AdSetServiceRest(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public void AddAdSet(AdSet adSetToAdd)
        {
            AddAdSetRequest addAdSetRequest = new AddAdSetRequest
            {
                Name = adSetToAdd.Name,
                TargetAudience = adSetToAdd.TargetAudience,
                AdsNames = adSetToAdd.Ads.Select(ad => ad.ProductName).ToList()
            };

            var response = httpClient.PostAsJsonAsync("api/adset/add", addAdSetRequest).Result;
            response.EnsureSuccessStatusCode();
        }

        public void AddAdToAdSet(AdSet adSet, Ad adToAdd)
        {
            var response = httpClient.PostAsJsonAsync<object>($"api/{adSet.Name}/ads/{adToAdd.ProductName}", null).Result;
            response.EnsureSuccessStatusCode();
        }

        public void RemoveAdFromAdSet(AdSet adSet, Ad adToRemove)
        {
            var response = httpClient.DeleteAsync($"api/{baseUrl}{adSet.Name}/ads/{adToRemove.ProductName}").Result;
            response.EnsureSuccessStatusCode();
        }

        public List<AdSet> GetAdSetsThatAreNotInCampaign()
        {
            var response = httpClient.GetAsync("api/adset/notincampaign").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<List<AdSet>>().Result;
        }

        public List<AdSet> GetAdSetsInCampaign(string id)
        {
            var response = httpClient.GetAsync($"api/adset/incampaign/{id}").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<List<AdSet>>().Result;
        }

        public AdSet GetAdSetByName(AdSet adSet)
        {
            var response = httpClient.GetAsync("api/adset/getbyname/" + adSet.Name).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<AdSet>().Result;
        }

        public void UpdateAdSet(AdSet adSetToUpdate)
        {
            UpdateAdSetRequest updateAdSetRequest = new UpdateAdSetRequest
            {
                AdSetId = adSetToUpdate.AdSetId,
                Name = adSetToUpdate.Name,
                TargetAudience = adSetToUpdate.TargetAudience
            };

            var response = httpClient.PutAsJsonAsync("api/adset/update", updateAdSetRequest).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteAdSet(AdSet adSetToDelete)
        {
            var response = httpClient.DeleteAsync($"api/adset/{adSetToDelete.Name}").Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
