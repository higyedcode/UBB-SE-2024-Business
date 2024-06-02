using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    internal interface ICollaborationService
    {
        public void AddCollaboration(Collaboration collaboration);
        public List<Collaboration> GetCollaborationForAdAccount();
        public List<Collaboration> GetCollaborationForInfluencer();
        public List<Collaboration> GetActiveCollaborationForAdAccount();
    }
}
