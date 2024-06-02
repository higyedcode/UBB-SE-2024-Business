using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public interface ICampaignService
    {
        public void AddCampaign(Campaign campaignToAdd);
        public Campaign GetCampaignByName(Campaign campaignToGetByName);
        public void DeleteCampaign(Campaign campaignToDelete);
        public void AddAdSetToCampaign(Campaign campaignToAddAdSet, AdSet adSet);
        public void DeleteAdSetFromCampaign(Campaign campaignToDeleteAdSet, AdSet adSet);
        public void UpdateCampaign(Campaign campaignToUpdate);
    }
}
