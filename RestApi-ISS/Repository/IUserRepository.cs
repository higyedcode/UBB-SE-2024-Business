using Iss.User;

namespace RestApi_ISS.Repository
{
    public interface IUserRepository
    {
        public User GetUser(string username, string password);
    }
}
