using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public class CampaignDTO
    {
        public string CampaignId { get; set; }
        public string CampaignName { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string AdAccountId { get; set; }
        public List<string> AdSetsNames { get; set; }
    }

    public class CampaignServiceRest : ICampaignService
    {
        private readonly HttpClient httpClient;

        public CampaignServiceRest(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public void AddCampaign(Campaign campaignToAdd)
        {
            List<string> adSetsNames = new List<string>();
            foreach (AdSet adSet in campaignToAdd.AdSets)
            {
                adSetsNames.Add(adSet.Name);
            }

            CampaignDTO campaignDTO = new CampaignDTO
            {
                CampaignId = campaignToAdd.CampaignId,
                CampaignName = campaignToAdd.CampaignName,
                StartDate = campaignToAdd.StartDate,
                Duration = campaignToAdd.Duration,
                AdAccountId = campaignToAdd.AdAccountId,
                AdSetsNames = adSetsNames
            };

            var response = httpClient.PostAsJsonAsync("api/campaign/add", campaignDTO).Result;
            response.EnsureSuccessStatusCode();
        }

        public Campaign GetCampaignByName(Campaign campaignToGetByName)
        {
            var response = httpClient.GetAsync($"api/campaign/getbyname/{campaignToGetByName.CampaignName}").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<Campaign>().Result;
        }

        public void DeleteCampaign(Campaign campaignToDelete)
        {
            var response = httpClient.DeleteAsync($"api/campaign/delete/{campaignToDelete.CampaignName}").Result;
            response.EnsureSuccessStatusCode();
        }

        public void AddAdSetToCampaign(Campaign campaignToAddAdSet, AdSet adSet)
        {
            var response = httpClient.PostAsync($"api/campaign/addadset/{campaignToAddAdSet.CampaignName}/{adSet.Name}", null).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteAdSetFromCampaign(Campaign campaignToDeleteAdSet, AdSet adSet)
        {
            var response = httpClient.DeleteAsync($"api/campaign/deleteadset/{campaignToDeleteAdSet.CampaignName}/{adSet.Name}").Result;
            response.EnsureSuccessStatusCode();
        }

        public void UpdateCampaign(Campaign campaignToUpdate)
        {
            var response = httpClient.PutAsJsonAsync("api/campaign/update", campaignToUpdate).Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
