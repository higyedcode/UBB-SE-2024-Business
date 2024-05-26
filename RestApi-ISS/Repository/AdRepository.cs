using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Iss.Entity;
using Iss.Database;

using Microsoft.Data.SqlClient;

namespace Iss.Repository
{
    internal class AdRepository : IAdRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private string adAcountId = User.User.GetInstance().Id;
        private DatabaseContext databaseContext = new DatabaseContext();

        public AdRepository()
        {
            this.adAcountId = User.User.GetInstance().Id;
        }
        public AdRepository(string adAcountId)
        {
            this.adAcountId = adAcountId;
        }

        public void AddAd(Ad adToAdd)
        {
            adToAdd.AdAccountId = User.User.GetInstance().Id;

            databaseContext.Ad.Add(adToAdd);
            databaseContext.SaveChanges();
        }

        public Ad GetAdByName(string adName)
        {
            Ad ad = databaseContext.Ad.Where(a => a.ProductName == adName).FirstOrDefault();

            return ad;
        }

        public List<Ad> GetAdsThatAreNotInAdSet()
        {
            List<Ad> ads = new List<Ad>();

            ads = databaseContext.Ad.Where(a => a.AdSetId == null && a.AdAccountId == adAcountId).ToList();

            return ads;
        }

        public List<Ad> GetAdsForAdSet(string adSetId)
        {
            List<Ad> ads = new List<Ad>();
            ads = databaseContext.Ad.Where(a => a.AdSetId == adSetId && a.AdAccountId == adAcountId).ToList();

            return ads;
        }

        public void UpdateAd(Ad adToUpdate)
        {
            databaseContext.ChangeTracker.Clear();

            adToUpdate.AdAccountId = User.User.GetInstance().Id;

            databaseContext.Update(adToUpdate);
            databaseContext.SaveChanges();
        }

        public void DeleteAd(Ad adToDelete)
        {
            databaseContext.ChangeTracker.Clear();

            databaseContext.Ad.Remove(adToDelete);
            databaseContext.SaveChanges();
        }
    }
}
