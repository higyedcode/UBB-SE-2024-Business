using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;
using Iss.Repository;
using RestApi_ISS.Service;

namespace Iss.Service
{
    /// <summary>
    /// Service class for managing influencers.
    /// </summary>
    public class InfluencerService : IInfluencerService
    {
        private IInfluencerRepository influencerRepository = new InfluencerRepository();

        public InfluencerService(IInfluencerRepository influencerRepository)
        {
            this.influencerRepository = influencerRepository;
        }

        public InfluencerService()
        {
        }

        /// <summary>
        /// Retrieves a list of influencers.
        /// </summary>
        /// <returns>A list of <see cref="Influencer"/> objects representing influencers.</returns>
        public List<Influencer> GetInfluencers()
        {
            return this.influencerRepository.GetInfluencers();
        }

        public Influencer GetInfluencerById(int id)
        {
            return this.influencerRepository.GetInfluencerById(id);
        }

        public void AddInfluencer(Influencer influencer)
        {
            this.influencerRepository.AddInfluencer(influencer);
        }

        public void UpdateInfluencer(Influencer influencer)
        {
            this.influencerRepository.UpdateInfluencer(influencer);
        }

        public void DeleteInfluencer(int id)
        {
            this.influencerRepository.DeleteInfluencer(id);
        }
    }
}
