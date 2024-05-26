using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class GoldSubscription : ISubscription
    {
        private int NumberOfCampaigns { get; set; }
        private decimal Price { get; set; }
        private int Reach { get; set; }

        public GoldSubscription()
        {
        }

        public GoldSubscription(int numberOfCampaigns, decimal price, int reach)
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
