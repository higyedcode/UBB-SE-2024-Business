using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;
using Iss.Repository;

namespace Iss.Service
{
    /// <summary>
    /// Service class for managing influencers.
    /// </summary>
    public class InfluencerService
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
    }
}
