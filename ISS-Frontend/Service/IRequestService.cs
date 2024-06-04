using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public interface IRequestService
    {
        List<Request> GetAllRequestsInfluencer();
        List<Request> GetAllRequestsAddAccount();
        Request GetRequestById(int id);
        void AddRequest(Request request);
        void UpdateRequest(Request request);
        void DeleteRequest(int id);
    }
}
