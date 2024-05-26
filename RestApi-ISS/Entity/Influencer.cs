using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Influencer
    {
        public string InfluencerId { get; set; }
        public string InfluencerName { get; set; }
        public int FollowerCount { get; set; }
        public int CollaborationPrice { get; set; }
        public List<Collaboration> Collaborations { get; set; }

        public Influencer()
        {
        }

        public Influencer(string userId, string name, int followerCount, int collaborationPrice)
        {
            this.InfluencerId = userId;
            this.InfluencerName = name;
            this.FollowerCount = followerCount;
            this.CollaborationPrice = collaborationPrice;
        }

        public Influencer(string name, int followerCount, int collaborationPrice)
        {
            this.InfluencerName = name;
            this.FollowerCount = followerCount;
            this.CollaborationPrice = collaborationPrice;
        }

        public override string ToString()
        {
            return InfluencerName + " with " + FollowerCount + " followers. Costs: " + CollaborationPrice + "$";
        }
    }
}
