using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;
using Iss.Repository;

namespace Iss.Service
{
    public class AdSetService : IAdSetService
    {
        private IAdSetRepository adSetRepository = new AdSetRepository();

        public AdSetService()
        {
        }

        public AdSetService(IAdSetRepository adSetRepository)
        {
            this.adSetRepository = adSetRepository;
        }

        public void AddAdSet(AdSet adSet)
        {
            adSetRepository.AddAdSet(adSet);

            adSet = adSetRepository.GetAdSetByName(adSet);

            foreach (Ad ad in adSet.Ads)
            {
                adSetRepository.AddAdToAdSet(adSet, ad);
            }
        }

        public void AddAdToAdSet(AdSet adSet, Ad ad)
        {
            this.adSetRepository.AddAdToAdSet(adSet, ad);
        }

        public void RemoveAdFromAdSet(AdSet adSet, Ad ad)
        {
            this.adSetRepository.RemoveAdFromAdSet(adSet, ad);
        }

        public List<AdSet> GetAdSetsThatAreNotInCampaign()
        {
            return adSetRepository.GetAdSetsThatAreNotInCampaign();
        }

        public List<AdSet> GetAdSetsInCampaign(string id)
        {
            return adSetRepository.GetAdSetsInCampaign(id);
        }

        public AdSet GetAdSetByName(AdSet adSet)
        {
            return adSetRepository.GetAdSetByName(adSet);
        }

        public void UpdateAdSet(AdSet adSet)
        {
            this.adSetRepository.UpdateAdSet(adSet);
        }

        public void DeleteAdSet(AdSet adSet)
        {
            this.adSetRepository.DeleteAdSet(adSet);
        }
    }
}
