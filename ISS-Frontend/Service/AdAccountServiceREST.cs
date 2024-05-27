using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using ISS_Frontend.Service;
using ISS_Frontend.Entity;

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class AdAccountRequest
{
    public string CompanyName { get; set; }
    public string DomainOfActivity { get; set; }
    public string Password { get; set; }
    public string SiteUrl { get; set; }
    public string HeadQuarters { get; set; }
    public string CIF { get; set; }
    public string AuthorisingInstitution { get; set; }
}

public class EditAccountRequest
{
    public string NameOfCompany { get; set; }
    public string Url { get; set; }
    public string Password { get; set; }
    public string Location { get; set; }
}

public class AdAccountServiceRest : IAdAccountService
{
    private readonly HttpClient httpClient;

    public AdAccountServiceRest(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public void Login(string email, string password)
    {
        var loginRequest = new LoginRequest { Username = email, Password = password };


        var response = httpClient.PostAsJsonAsync("api/AdAccount/login", loginRequest).Result;

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new InvalidOperationException("Unauthorized. Please check your credentials.");
            }
            else
            {
                throw new Exception($"Failed to login: {response.ReasonPhrase}");
            }
        }
    }

    public AdAccount GetAccount()
    {
        var response = httpClient.GetAsync("api/AdAccount/account").Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<AdAccount>().Result;
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
        else
        {
            throw new Exception($"Failed to retrieve account: {response.ReasonPhrase}");
        }
    }

    public List<Ad> GetAdsForCurrentUser()
    {
        var response = httpClient.GetAsync("api/AdAccount/ads").Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<List<Ad>>().Result;
        }
        else
        {
            throw new Exception($"Failed to retrieve ads: {response.ReasonPhrase}");
        }
    }

    public List<AdSet> GetAdSetsForCurrentUser()
    {
        var response = httpClient.GetAsync("api/AdAccount/adsets").Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<List<AdSet>>().Result;
        }
        else
        {
            throw new Exception($"Failed to retrieve ad sets: {response.ReasonPhrase}");
        }
    }

    public List<Campaign> GetCampaignsForCurrentUser()
    {
        var response = httpClient.GetAsync("api/AdAccount/campaigns").Result;
        if (response.IsSuccessStatusCode)
        {
            return response.Content.ReadFromJsonAsync<List<Campaign>>().Result;
        }
        else
        {
            throw new Exception($"Failed to retrieve campaigns: {response.ReasonPhrase}");
        }
    }

    public void AddAdAccount(AdAccount addAccount)
    {
        AdAccountRequest adAccountRequest = new AdAccountRequest();
        adAccountRequest.AuthorisingInstitution = addAccount.AuthorisingInstituion;
        adAccountRequest.HeadQuarters = addAccount.HeadquartersLocation;
        adAccountRequest.SiteUrl = addAccount.SiteUrl;
        adAccountRequest.CompanyName = addAccount.NameOfCompany;
        adAccountRequest.DomainOfActivity = addAccount.DomainOfActivity;
        adAccountRequest.Password = addAccount.Password;
        adAccountRequest.CIF = addAccount.TaxIdentificationNumber;

        var response = httpClient.PostAsJsonAsync("api/AdAccount/add", adAccountRequest).Result;
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to add account: {response.ReasonPhrase}");
        }
    }

    public void EditAdAccount(string nameOfCompany, string url, string password, string location)
    {
        var editAccountRequest = new EditAccountRequest
        {
            NameOfCompany = nameOfCompany,
            Url = url,
            Password = password,
            Location = location
        };

        var response = httpClient.PutAsJsonAsync("api/AdAccount/edit", editAccountRequest).Result;
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to edit account: {response.ReasonPhrase}");
        }
    }
}
