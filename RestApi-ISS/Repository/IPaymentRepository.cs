using Iss.Entity;

namespace Iss.Repository
{
    public interface IPaymentRepository
    {
        void AddOneAd();
        void AddOneAdSet();
        void AddOneCampaign();
        void RemoveOneAd();
        void RemoveOneCampaign();
        void RemoveOneAdSet();
        void AddSubscription(string name);
    }
}
