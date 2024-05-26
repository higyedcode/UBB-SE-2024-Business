using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;
using Iss.Repository;

namespace Iss.Service
{
    internal class CampaignService : ICampaignService
    {
        private ICampaignRepository campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        public CampaignService()
        {
            this.campaignRepository = new CampaignRepository();
        }

        public void AddCampaign(Campaign campaignToAdd)
        {
            this.campaignRepository.AddCampaign(campaignToAdd);

            Campaign campaignFromRepository = campaignRepository.GetCampaignByName(campaignToAdd);

            if (campaignFromRepository == null)
            {
                Console.WriteLine("Campaign with the specified name was not found.");
                return;
            }

            List<AdSet> currentAdSet = campaignFromRepository.AdSets;

            foreach (AdSet adSet in currentAdSet)
            {
                campaignRepository.AddAdSetToCampaign(campaignFromRepository, adSet);
            }
        }

        public Campaign GetCampaignByName(Campaign campaignToGetByName)
        {
            Campaign campaignToReturn = campaignRepository.GetCampaignByName(campaignToGetByName);
            return campaignToReturn;
        }

        public void DeleteCampaign(Campaign campaignToDelete)
        {
            campaignRepository.DeleteCampaign(campaignToDelete);
        }

        public void AddAdSetToCampaign(Campaign campaignToAddAdSet, AdSet adSet)
        {
            campaignRepository.AddAdSetToCampaign(campaignToAddAdSet, adSet);
        }

        public void DeleteAdSetFromCampaign(Campaign campaignToDeleteAdSet, AdSet adSet)
        {
            campaignRepository.DeleteAdSetFromCampaign(campaignToDeleteAdSet, adSet);
        }

        public void UpdateCampaign(Campaign campaignToUpdate)
        {
            campaignRepository.UpdateCampaign(campaignToUpdate);
        }
    }
}
