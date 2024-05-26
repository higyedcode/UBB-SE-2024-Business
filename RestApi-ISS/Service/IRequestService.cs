using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;

namespace Iss.Service
{
    internal interface IRequestService
    {
        public void AddRequest(Request requestToAdd);
        public void DeleteRequest(Request requestToDelete);
        public string GetInfluencerId();
        public List<Request> GetRequestsForInfluencer();
        public Request GetRequestWithTitle(string title);
        public List<Request> GetRequestsForAdAccount();
        public void UpdateRequest(Request requestToUpdate, string newCompensation, string newContentRequirements);
    }
}
