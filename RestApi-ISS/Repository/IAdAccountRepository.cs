using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.Entity;

namespace Iss.Repository
{
    public interface IAdAccountRepository
    {
        public AdAccount GetAdAccount(string nameOfCompany, string password);
        public void AddAdAccount(AdAccount adAccountToAdd);
        public List<Ad> GetAdsForCurrentUser();
        public List<AdSet> GetAdSetsForCurrentUser();
        public List<Campaign> GetCampaignsForCurrentUser();
        public void EditAdAccount(string nameOfCompany, string url, string password, string location);
    }
}
