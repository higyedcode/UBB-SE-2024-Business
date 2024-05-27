using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using ISS_Frontend.Entity;
using ISS_Frontend.Service;

public class AddAdRequest
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public string SelectedImagePath { get; set; }
    public string Link { get; set; }
}

public class UpdateAdRequest
{
    public string AdId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public string SelectedImagePath { get; set; }
    public string Link { get; set; }
}

public class AdServiceRest : IAdService
{
    private readonly HttpClient httpClient;

    public AdServiceRest(HttpClient httpClient)
    {
        this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public void AddAd(Ad adToAdd)
    {
        AddAdRequest addAdRequest = new AddAdRequest
        {
            ProductName = adToAdd.ProductName,
            Description = adToAdd.Description,
            SelectedImagePath = adToAdd.Photo,
            Link = adToAdd.WebsiteLink
        };

        HttpResponseMessage response = httpClient.PostAsJsonAsync("api/ad/add", addAdRequest).Result;
        response.EnsureSuccessStatusCode();
    }

    public List<Ad> GetAdsThatAreNotInAdSet()
    {
        HttpResponseMessage response = httpClient.GetAsync("api/ad/not-in-adset").Result;
        response.EnsureSuccessStatusCode();
        return response.Content.ReadFromJsonAsync<List<Ad>>().Result;
    }

    public void UpdateAd(Ad adToUpdate)
    {
        UpdateAdRequest updateAdRequest = new UpdateAdRequest
        {
            AdId = adToUpdate.AdId,
            ProductName = adToUpdate.ProductName,
            Description = adToUpdate.Description,
            SelectedImagePath = adToUpdate.Photo,
            Link = adToUpdate.WebsiteLink
        };

        HttpResponseMessage response = httpClient.PutAsJsonAsync("api/ad/update", updateAdRequest).Result;
        response.EnsureSuccessStatusCode();
    }

    public Ad GetAdByName(string adName)
    {
        HttpResponseMessage response = httpClient.GetAsync($"api/ad/by-name/{adName}").Result;
        response.EnsureSuccessStatusCode();
        return response.Content.ReadFromJsonAsync<Ad>().Result;
    }

    public void DeleteAd(Ad adToDelete)
    {
        HttpResponseMessage response = httpClient.DeleteAsync($"api/ad/delete/{adToDelete.ProductName}").Result;
        response.EnsureSuccessStatusCode();
    }

    public List<Ad> GetAdsFromAdSet(string adSetId)
    {
        HttpResponseMessage response = httpClient.GetAsync($"api/ad/from-adset/{adSetId}").Result;
        response.EnsureSuccessStatusCode();
        return response.Content.ReadFromJsonAsync<List<Ad>>().Result;
    }
}
