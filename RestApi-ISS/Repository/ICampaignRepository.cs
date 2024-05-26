using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;

namespace Iss.Repository
{
    public interface ICampaignRepository
    {
        void AddCampaign(Campaign campaignToAdd);
        Campaign GetCampaignByName(Campaign campaignToGetByName);
        void AddAdSetToCampaign(Campaign campaignToAddAdSet, AdSet adSet);
        void DeleteAdSetFromCampaign(Campaign campaignToDeleteAdSet, AdSet adSet);
        void DeleteCampaign(Campaign campaignToDelete);
        void UpdateCampaign(Campaign campaignToUpdate);
    }
}
