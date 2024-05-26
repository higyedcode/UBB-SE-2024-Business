using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class OneAdSetPayment : IOneTimePayment
    {
        public int AdSetPaymentId { get; set; }
        public int Reach { get; set; }
        public decimal Price { get; set; }

        public OneAdSetPayment(int paymentId, int reach, decimal price)
        {
            this.AdSetPaymentId = paymentId;
            this.Reach = reach;
            this.Price = price;
        }
    }
}
