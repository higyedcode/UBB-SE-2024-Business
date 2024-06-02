using Celebration_Of_Capitalism___The_Finale.Models;

namespace Celebration_Of_Capitalism___The_Finale.Services.Interfaces
{
    public interface ICOCUserService
    {
        int AddUser(COCUser user);
        int UserExists(COCUser user);
        bool DeleteUser(int id);
        bool UpdateUser(int id, COCUser user);
        IEnumerable<COCUser> GetAllUsers();
        COCUser? GetUser(int id);
    }
}
