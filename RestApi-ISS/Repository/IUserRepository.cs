using Iss.User;

namespace RestApi_ISS.Repository
{
    public interface IUserRepository
    {
        public AppUser GetUser(string username, string password);
    }
}
