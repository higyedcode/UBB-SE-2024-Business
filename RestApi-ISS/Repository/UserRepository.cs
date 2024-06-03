using Iss.Database;
using Iss.Entity;
using Iss.Repository;
using Iss.User;
using Microsoft.Data.SqlClient;

namespace RestApi_ISS.Repository
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext databaseContext = new DatabaseContext();

        public User GetUser(string username, string password)
        {
            User user = null;
            user = databaseContext.Users
                .Where(userr => userr.Name == username &&
                userr.Password == password)
                .FirstOrDefault();
            return user;
        }
    }
}
