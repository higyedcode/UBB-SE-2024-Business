using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.Entity;
using Iss.Repository;

namespace Iss.Service
{
    internal class CollaborationService : ICollaborationService
    {
        private IColaborationRepository collaborationRepository;

        public CollaborationService(IColaborationRepository collaborationRepository)
        {
            this.collaborationRepository = collaborationRepository;
        }
        public CollaborationService()
        {
            this.collaborationRepository = new CollaborationRepository();
        }
        public void AddCollaboration(Collaboration collaboration)
        {
            collaborationRepository.CreateCollaboration(collaboration);
        }

        public List<Collaboration> GetCollaborationForAdAccount()
        {
            return collaborationRepository.GetCollaborationsForAdAccount();
        }

        public List<Collaboration> GetCollaborationForInfluencer()
        {
            return collaborationRepository.GetCollaborationsForInfluencer();
        }

        public List<Collaboration> GetActiveCollaborationForAdAccount()
        {
            return collaborationRepository.GetCollaborationsForAdAccount().Where(c => c.Status).ToList();
        }
    }
}