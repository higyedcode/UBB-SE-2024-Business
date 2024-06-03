using Iss.Entity;
using Iss.Repository;
using Iss.User;
using RestApi_ISS.Repository;

namespace RestApi_ISS.Service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private User user;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserService()
        {
            this.userRepository = new UserRepository();
        }
        public void LoginUser(string username, string password)
        {
            User getUser = userRepository.GetUser(username, password);
            if (getUser != null)
            {
                user.Id = getUser.Id;
                user.Name = getUser.Name;
                user.Password = getUser.Password;
            }
            else
            {
                throw new InvalidOperationException("Invalid username or password.");
            }
        }
    }
}
