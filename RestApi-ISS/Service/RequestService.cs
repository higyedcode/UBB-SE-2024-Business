using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.User;

using Iss.Entity;
using Iss.Repository;

namespace Iss.Service
{
    internal class RequestService : IRequestService
    {
        private IRequestRepository requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public RequestService()
        {
            this.requestRepository = new RequestRepository();
        }

        public void AddRequest(Request requestToAdd)
        {
            this.requestRepository.AddRequest(requestToAdd);
        }

        public void DeleteRequest(Request requestToDelete)
        {
            this.requestRepository.DeleteRequest(requestToDelete);
        }

        public string GetInfluencerId()
        {
            return this.requestRepository.GetInfluencerId();
        }

        public List<Request> GetRequestsForInfluencer()
        {
            return this.requestRepository.GetRequestsForInfluencer();
        }

        public Request GetRequestWithTitle(string title)
        {
            // parse the requestToDelete list and find the requestToDelete with given title
            List<Request> requestsList = this.requestRepository.GetRequestsList();

            if (requestsList == null)
            {
                return null;
            }

            foreach (Request request in requestsList)
            {
                if (request.CollaborationTitle == title)
                {
                    return request;
                }
            }
            return null;
        }

        public List<Request> GetRequestsForAdAccount()
        {
            return this.requestRepository.GetRequestsForAdAccount();
        }

        public void UpdateRequest(Request requestToUpdate, string newCompensation, string newContentRequirements)
        {
            requestToUpdate.Compensation = newCompensation;
            requestToUpdate.ContentRequirements = newContentRequirements;
            this.requestRepository.UpdateRequest(requestToUpdate);
        }
    }
}
