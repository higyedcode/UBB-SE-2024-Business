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

        public AppUser GetUser(string username, string password)
        {
            AppUser user = null;
            user = databaseContext.AppUser
                .Where(userr => userr.Username == username &&
                userr.Password == password)
                .FirstOrDefault();
            return user;
        }
    }
}
