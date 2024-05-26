using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Repository;
using Iss.Entity;

namespace Iss.Service
{
    public class AdService : IAdService
    {
        private IAdRepository adRepository;
        public AdService(IAdRepository adRepository)
        {
            this.adRepository = adRepository;
        }

        public AdService()
        {
            this.adRepository = new AdRepository();
        }

        public void AddAd(Ad adToAdd)
        {
            this.adRepository.AddAd(adToAdd);
        }

        public List<Ad> GetAdsThatAreNotInAdSet()
        {
            return this.adRepository.GetAdsThatAreNotInAdSet();
        }

        public void UpdateAd(Ad adToUpdate)
        {
            this.adRepository.UpdateAd(adToUpdate);
        }

        public Ad GetAdByName(string adName)
        {
            return this.adRepository.GetAdByName(adName);
        }

        public void DeleteAd(Ad adToDelete)
        {
            this.adRepository.DeleteAd(adToDelete);
        }

        public List<Ad> GetAdsFromAdSet(string adSetId)
        {
            return this.adRepository.GetAdsForAdSet(adSetId);
        }
    }
}
