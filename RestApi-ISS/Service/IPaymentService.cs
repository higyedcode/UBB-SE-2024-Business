using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    public interface IPaymentService
    {
        void AddOneAd();
        void AddOneAdSet();
        void AddOneCampaign();
        void AddBasicSubscription();
        void AddSilverSubscription();
        void AddGoldSubscription();
    }
}
