using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class OneCampaignPayment : IOneTimePayment
    {
        public int CampaignPaymentId { get; set; }
        public int Reach { get; set; }
        public decimal Price { get; set; }

        public OneCampaignPayment(int paymentId, int reach, decimal price)
        {
            this.CampaignPaymentId = paymentId;
            this.Reach = reach;
            this.Price = price;
        }
    }
}
