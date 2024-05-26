using ISS_Frontend.Entity;
using ISS_Frontend.Models;
using System.Net.Http;

namespace ISS_Frontend.Service
{
    public class BankAccountService : IBankAccountService
    {

        private readonly HttpClient httpClient;
        public BankAccountService(HttpClient httpClient) {
            this.httpClient = httpClient;
        }
        public void AddBankAccount(BankAccount bankAccount)
        {
            var response = httpClient.PostAsJsonAsync("api/BankAccount/", bankAccount).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to edit account: {response.ReasonPhrase}");
            }
        }

        public void EditBankAccount(BankAccount bankAccount)
        {
            var response = httpClient.PutAsJsonAsync("api/BankAccount/" + bankAccount.Id, bankAccount).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to edit account: {response.ReasonPhrase}");
            }
        }

        public BankAccount GetBankAccountById(int bankAccountId)
        {
            var response = httpClient.GetAsync("api/BankAccount/"+bankAccountId).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<BankAccount>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve bank account: {response.ReasonPhrase}");
            }
        }

        public List<BankAccount> GetBankAccounts()
        {
            var response = httpClient.GetAsync("api/BankAccount").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<List<BankAccount>>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve bank accounts: {response.ReasonPhrase}");
            }
        }

        public void RemoveBankAccount(int bankAccountId)
        {
            var response = httpClient.DeleteAsync("api/BankAccount/" + bankAccountId).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to edit account: {response.ReasonPhrase}");
            }
        }
    }
}
