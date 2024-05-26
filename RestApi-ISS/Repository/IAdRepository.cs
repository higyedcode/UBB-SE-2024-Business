using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.Entity;

namespace Iss.Repository
{
    public interface IAdRepository
    {
        public void AddAd(Ad adToAdd);
        public Ad GetAdByName(string adName);
        public List<Ad> GetAdsThatAreNotInAdSet();
        public List<Ad> GetAdsForAdSet(string adSetId);
        public void UpdateAd(Ad adToUpdate);
        public void DeleteAd(Ad adToDelete);
    }
}
