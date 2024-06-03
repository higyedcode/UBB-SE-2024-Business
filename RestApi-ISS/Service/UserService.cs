using Iss.Entity;
using Iss.Repository;
using Iss.User;
using RestApi_ISS.Repository;

namespace RestApi_ISS.Service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

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
            User user = userRepository.GetUser(username, password);
            if (user != null)
            {
                User.User.GetInstance().Id = user.Id;
                User.User.GetInstance().Username = user.Name;
                User.User.GetInstance().Password = user.Password;
            }
            else
            {
                throw new InvalidOperationException("Invalid username or password.");
            }
        }
    }
}
