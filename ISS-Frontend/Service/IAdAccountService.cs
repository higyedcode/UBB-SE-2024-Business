using ISS_Frontend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ISS_Frontend.Service
{
    public interface IAdAccountService
    {
        public void Login(string email, string password);
        public AdAccount GetAccount();
        public List<Ad> GetAdsForCurrentUser();
        public List<AdSet> GetAdSetsForCurrentUser();
        public List<Campaign> GetCampaignsForCurrentUser();
        public void AddAdAccount(AdAccount addAccount);
        public void EditAdAccount(string nameOfCompany, string url, string password, string location);
    }
}
