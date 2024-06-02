using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public interface IAdSetService
    {
        public void AddAdSet(AdSet adSetToAdd);
        public void AddAdToAdSet(AdSet adSet, Ad adToAdd);
        public void RemoveAdFromAdSet(AdSet adSet, Ad adToRemove);
        public List<AdSet> GetAdSetsThatAreNotInCampaign();
        public List<AdSet> GetAdSetsInCampaign(string id);
        public AdSet GetAdSetByName(AdSet adSet);
        public void UpdateAdSet(AdSet adSetToUpdate);
        public void DeleteAdSet(AdSet adSetToDelete);
    }
}
