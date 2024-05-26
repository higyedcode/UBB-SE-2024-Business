using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Frontend.Entity
{
    public class Campaign
    {
        public string CampaignId { get; set; }
        public string CampaignName { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

        public string AdAccountId { get; set; }

        public AdAccount? AdAccount { get; set; }

        public List<AdSet> AdSets { get; set; }

        public Campaign()
        {
        }

        public Campaign(string campaignName, DateTime startDate, int duration)
        {
            this.CampaignName = campaignName;
            this.StartDate = startDate;
            this.Duration = duration;
        }

        public Campaign(string campaignName, DateTime startDate, int duration, List<AdSet> adSets)
        {
            this.CampaignName = campaignName;
            this.StartDate = startDate;
            this.Duration = duration;
            this.AdSets = adSets;
        }

        public Campaign(string campaignId, string campaignName, DateTime startDate, int duration)
        {
            this.CampaignId = campaignId;
            this.CampaignName = campaignName;
            this.StartDate = startDate;
            this.Duration = duration;
        }

        public override string ToString()
        {
            return "CAMPAIGN NAME: " + CampaignName + "-" + "START DATE: " + StartDate.ToString() + "-" + "DURATION: " + Duration;
        }
    }
}