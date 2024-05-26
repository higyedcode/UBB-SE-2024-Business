using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Frontend.Entity
{
    public class SilverSubscription : ISubscription
    {
        private int NumberOfCampaigns { get; set; }
        private decimal Price { get; set; }
        private int Reach { get; set; }

        public SilverSubscription(int numberOfCampaigns, decimal price, int reach)
        {
            this.NumberOfCampaigns = numberOfCampaigns;
            this.Price = price;
            this.Reach = reach;
        }

        public int GetNumberOfCampaigns()
        {
            return NumberOfCampaigns;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public int GetReach()
        {
            return Reach;
        }
    }
}
