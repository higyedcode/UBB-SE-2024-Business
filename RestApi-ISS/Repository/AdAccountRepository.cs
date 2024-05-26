using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Iss.Database;
using Iss.Entity;

using Microsoft.Data.SqlClient;

namespace Iss.Repository
{
    public class AdAccountRepository : IAdAccountRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DatabaseContext databaseContext = new DatabaseContext();

        public AdAccount GetAdAccount(string nameOfCompany, string password)
        {
            AdAccount adAccount = null;
            adAccount = databaseContext.AdAccount
                .Where(account => account.NameOfCompany == nameOfCompany &&
                account.Password == password)
                .FirstOrDefault();

            return adAccount;
        }

        public void AddAdAccount(AdAccount adAccount)
        {
            databaseContext.AdAccount.Add(adAccount);
            databaseContext.SaveChanges();
        }

        public List<Ad> GetAdsForCurrentUser()
        {
            // MessageBox.Show(User.User.GetInstance().Id);
            List<Ad> ads = new List<Ad>();

            ads = databaseContext.Ad
                .Where(ad => ad != null && ad.AdAccountId == User.User.GetInstance().Id)
                .ToList();

            return ads;
        }

        public List<AdSet> GetAdSetsForCurrentUser()
        {
            List<AdSet> adSets = new List<AdSet>();

            adSets = databaseContext.AdSet
                .Where(adSet => adSet.AdAccountId == User.User.GetInstance().Id)
                .ToList();

            return adSets;
        }

        public List<Campaign> GetCampaignsForCurrentUser()
        {
            List<Campaign> campaigns = new List<Campaign>();

            campaigns = databaseContext.Campaign
                .Where(campaign => campaign.AdAccountId == User.User.GetInstance().Id)
                .ToList();

            return campaigns;
        }
        public void EditAdAccount(string nameOfCompany, string url, string password, string location)
        {
            AdAccount adAccount = databaseContext.AdAccount
                .Where(account => account.AdAccountId == User.User.GetInstance().Id)
                .FirstOrDefault();

            adAccount.NameOfCompany = nameOfCompany;
            adAccount.SiteUrl = url;
            adAccount.Password = password;
            adAccount.HeadquartersLocation = location;

            databaseContext.ChangeTracker.Clear();

            databaseContext.AdAccount
                .Update(adAccount);

            databaseContext.SaveChanges();
        }
    }
}
