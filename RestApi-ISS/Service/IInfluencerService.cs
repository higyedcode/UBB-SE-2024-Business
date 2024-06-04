using Iss.Entity;

namespace RestApi_ISS.Service
{
    public interface IInfluencerService
    {
        public List<Influencer> GetInfluencers();
        public Influencer GetInfluencerById(int id);
        public void AddInfluencer(Influencer influencer);
        public void UpdateInfluencer(Influencer influencer);
        public void DeleteInfluencer(int id);
    }
}
