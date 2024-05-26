using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Frontend.Entity
{
    /// <summary>
    /// Represents a set of advertisements targeting a specific audience.
    /// </summary>
    public class AdSet
    {
        /// <summary>
        /// Gets or sets the ID of the ad set.
        /// </summary>
        public string AdSetId { get; set; }

        public string AdAccountId { get; set; }

        public string CampaignId { get; set; }

        /// <summary>
        /// Gets or sets the name of the ad set.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of ads included in the ad set.
        /// </summary>
        public List<Ad> Ads { get;  set; }

        /// <summary>
        /// Gets or sets the target audience for the ad set.
        /// </summary>
        public string TargetAudience { get; set; }

        public AdSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdSet"/> class with specified ID, name, and target audience.
        /// </summary>
        /// <param name="id">The ID of the ad set.</param>
        /// <param name="name">The name of the ad set.</param>
        /// <param name="targetAudience">The target audience for the ad set.</param>
        public AdSet(string id, string name, string targetAudience)
        {
            this.AdSetId = id;
            this.Name = name;
            this.TargetAudience = targetAudience;
            this.Ads = new List<Ad>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdSet"/> class with specified name, target audience, and list of ads.
        /// </summary>
        /// <param name="name">The name of the ad set.</param>
        /// <param name="targetAudience">The target audience for the ad set.</param>
        /// <param name="ads">The list of ads included in the ad set.</param>
        public AdSet(string name, string targetAudience, List<Ad> ads)
        {
            this.Ads = ads;
            this.Name = name;
            this.TargetAudience = targetAudience;
        }

        public AdSet(string id, string name, List<Ad> ads, string targetAudience)
        {
            this.AdSetId = id;
            this.Name = name;
            this.Ads = ads;
            this.TargetAudience = targetAudience;
        }

        /// <summary>
        /// Adds a new ad to the ad set.
        /// </summary>
        /// <param name="ad">The ad to be added.</param>
        public void AddAd(Ad ad)
        {
            this.Ads.Add(ad);
        }

        /// <summary>
        /// Removes an ad from the ad set.
        /// </summary>
        /// <param name="ad">The ad to be removed.</param>
        public void RemoveAd(Ad ad)
        {
            this.Ads.Remove(ad);
        }

        /// <summary>
        /// Returns a string representation of the ad set.
        /// </summary>
        /// <returns>A string containing the ad set name and target audience.</returns>
        public override string ToString()
        {
            return "ADSET NAME: " + this.Name + "-" + "TARGET AUDIENCE: " + this.TargetAudience;
        }
    }
}
