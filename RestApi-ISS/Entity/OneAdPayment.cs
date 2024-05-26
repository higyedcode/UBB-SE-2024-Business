using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class OneAdPayment(int paymentId, int reach, decimal price) : IOneTimePayment
    {
        public int PaymentId { get; set; } = paymentId;
        public int Reach { get; set; } = reach;
        public decimal Price { get; set; } = price;
        public AdAccount Account;

        public int GetNextID()
        {
            int size = Account.GetPayments().Count;
            return size + 1;
        }
    }
}
