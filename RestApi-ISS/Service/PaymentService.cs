using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Repository;

namespace Iss.Service
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository paymentRepository;

        public PaymentService()
        {
            this.paymentRepository = new PaymentRepository();
        }

        public PaymentService(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        public void AddOneAd()
        {
            paymentRepository.AddOneAd();
        }

        public void AddOneAdSet()
        {
            paymentRepository.AddOneAdSet();
        }

        public void AddOneCampaign()
        {
            paymentRepository.AddOneCampaign();
        }

        public void AddBasicSubscription()
        {
            paymentRepository.AddSubscription("Basic");
        }

        public void AddSilverSubscription()
        {
            paymentRepository.AddSubscription("Silver");
        }

        public void AddGoldSubscription()
        {
            paymentRepository.AddSubscription("Gold");
        }
    }
}
