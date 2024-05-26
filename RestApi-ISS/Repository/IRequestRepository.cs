using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;

namespace Iss.Repository
{
    public interface IRequestRepository
    {
        public string GetInfluencerId();
        public void AddRequest(Request requestToAdd);
        public List<Request> GetRequestsForInfluencer();
        public void DeleteRequest(Request requestToDelete);
        public List<Request> GetRequestsList();
        public List<Request> GetRequestsForAdAccount();
        public void UpdateRequest(Request requestToUpdate);
    }
}
