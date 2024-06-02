using ISS_Frontend.Service;

public class PaymentServiceRest : IPaymentService
{
    private readonly HttpClient httpClient;

    public PaymentServiceRest(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public void AddOneAd()
    {
        var response = httpClient.PostAsync("api/Payment/add-ad", null).Result;
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to add ad: {response.ReasonPhrase}");
        }
    }

    public void AddOneAdSet()
    {
        var response = httpClient.PostAsync("api/Payment/add-adset", null).Result;
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to add ad set: {response.ReasonPhrase}");
        }
    }

    public void AddOneCampaign()
    {
        var response = httpClient.PostAsync("api/Payment/add-campaign", null).Result;
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to add campaign: {response.ReasonPhrase}");
        }
    }

    public void AddBasicSubscription()
    {
        var response = httpClient.PostAsync("api/Payment/add-subscription/basic", null).Result;
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to add Basic subscription: {response.ReasonPhrase}");
        }
    }

    public void AddSilverSubscription()
    {
        var response = httpClient.PostAsync("api/Payment/add-subscription/silver", null).Result;
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to add Silver subscription: {response.ReasonPhrase}");
        }
    }

    public void AddGoldSubscription()
    {
        var response = httpClient.PostAsync("api/Payment/add-subscription/gold", null).Result;
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to add Gold subscription: {response.ReasonPhrase}");
        }
    }
}
