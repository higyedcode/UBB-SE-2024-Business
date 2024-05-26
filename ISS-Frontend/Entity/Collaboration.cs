using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Frontend.Entity
{
    public class Collaboration
    {
        public int CollaborationId { get; set; }
        public string CollaborationTitle { get; set; }
        public DateTime StartDate { get; set; }
        public bool Status { get; set; }
        public string ContentRequirement { get; set; }
        public string AdOverview { get; set; }
        public string CollaborationFee { get; set; }
        public DateTime EndDate { get; set; }
        public string? AdAccountId { get; set; }
        public string? InfluencerId { get; set; }

        public Collaboration()
        {
        }

        public Collaboration(int collaborationId, DateTime startDate, bool status, string contentRequirement, string adOverview, string collaborationFee, int days, string collaborationTitle)
        {
            this.CollaborationId = collaborationId;
            this.CollaborationTitle = collaborationTitle;
            this.StartDate = startDate;
            this.Status = status;
            this.ContentRequirement = contentRequirement;
            this.AdOverview = adOverview;
            this.CollaborationFee = collaborationFee;
            this.EndDate = startDate.AddDays(days);
        }

        // collaborationTitle, selectedRequest.adOverview, selectedRequest.compensation, selectedRequest.startDate, selectedRequest.endDate
        public Collaboration(string collaborationTitle, string adOverview, string colaborationFee, string contentRequirement, DateTime startDate, DateTime endDate, bool status)
        {
            // this.CollaborationId = 0;
            this.CollaborationTitle = collaborationTitle;
            this.StartDate = startDate;
            this.Status = status;
            this.ContentRequirement = contentRequirement;
            this.AdOverview = adOverview;
            this.CollaborationFee = colaborationFee;
            this.EndDate = endDate;
        }
    }
}
