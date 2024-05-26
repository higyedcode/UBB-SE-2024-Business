using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Frontend.Entity
{
    public class Request(string collaborationTitle, string adOverview, string contentRequirements, string compensation, DateTime startDate, DateTime endDate, bool influencerAccept, bool adAccountAccept)
    {
        public string CollaborationTitle { get; set; } = collaborationTitle;
        public string AdOverview { get; set; } = adOverview;
        public string ContentRequirements { get; set; } = contentRequirements;
        public string Compensation { get; set; } = compensation;
        public DateTime StartDate { get; set; } = startDate;
        public DateTime EndDate { get; set; } = endDate;

        public bool InfluencerAccept { get; set; } = influencerAccept;
        public bool AdAccountAccept { get; set; } = adAccountAccept;

        public int RequestId { get; set; }
        public AdAccount AdAccount { get; set; }
        public Influencer Influencer { get; set; }

        public string AdAccountId { get; set; }
        public string InfluencerId { get; set; }

        public override string ToString()
        {
            return this.CollaborationTitle;
        }
    }
}
