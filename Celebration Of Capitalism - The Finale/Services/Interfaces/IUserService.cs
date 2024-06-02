using Celebration_Of_Capitalism___The_Finale.Models;

namespace Celebration_Of_Capitalism___The_Finale.Services.Interfaces
{
    public interface IUserService
    {
        int AddUser(User user);
        int UserExists(User user);
        bool DeleteUser(int id);
        bool UpdateUser(int id, User user);
        IEnumerable<User> GetAllUsers();
        User? GetUser(int id);
    }
}
