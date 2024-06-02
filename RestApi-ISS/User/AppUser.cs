using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.User
{
    public class AppUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       
        private static AppUser instance = null;
        public static AppUser GetInstance()
        {
            if (instance == null)
            {
                instance = new AppUser();
            }
            return instance;
        }

        private AppUser()
        {
        }
    }
}
