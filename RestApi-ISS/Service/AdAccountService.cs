using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;
using Iss.Repository;
using Iss.User;

namespace Iss.Service
{
    public class AdAccountService : IAdAccountService
    {
        private IAdAccountRepository adAccountRepository;

        public AdAccountService(IAdAccountRepository adAccountRepository)
        {
            this.adAccountRepository = adAccountRepository;
        }

        public AdAccountService()
        {
            this.adAccountRepository = new AdAccountRepository();
        }

        public void Login(string username, string password)
        {
            AdAccount adAccount = adAccountRepository.GetAdAccount(username, password);
            if (adAccount != null)
            {
                User.User.GetInstance().Id = adAccount.AdAccountId;
                User.User.GetInstance().Name = adAccount.NameOfCompany;
                User.User.GetInstance().Password = adAccount.Password;
            }
            else
            {
                throw new InvalidOperationException("Invalid username or password.");
            }
        }

        public AdAccount GetAccount()
        {
            return adAccountRepository.GetAdAccount(User.User.GetInstance().Name, User.User.GetInstance().Password);
        }

        public List<Ad> GetAdsForCurrentUser()
        {
            return adAccountRepository.GetAdsForCurrentUser();
        }

        public List<AdSet> GetAdSetsForCurrentUser()
        {
            return adAccountRepository.GetAdSetsForCurrentUser();
        }

        public List<Campaign> GetCampaignsForCurrentUser()
        {
            return adAccountRepository.GetCampaignsForCurrentUser();
        }

        public void AddAdAccount(AdAccount account)
        {
            this.adAccountRepository.AddAdAccount(account);
        }

        public void EditAdAccount(string nameOfCompany, string url, string password, string location)
        {
            this.adAccountRepository.EditAdAccount(nameOfCompany, url, password, location);
        }
    }
}
