using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public interface IInfluencerService
    {
        List<Influencer> GetAllInfluencers();
        Influencer GetInfluencerById(int id);
        void AddInfluencer(Influencer influencer);
        void UpdateInfluencer(Influencer influencer);
        void DeleteInfluencer(int id);
    }
}
