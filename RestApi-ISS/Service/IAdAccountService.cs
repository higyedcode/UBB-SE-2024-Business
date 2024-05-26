using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;

namespace Iss.Service
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
