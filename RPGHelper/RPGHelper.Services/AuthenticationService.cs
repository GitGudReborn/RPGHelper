using RPGHelper.Data;
using RPGHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Services
{
    public static class AuthenticationService
    {
        private static User loggedUser;

        public static bool Login(string username, string password)
        {
            using (var context = new RPGHelperContext())
            {
                loggedUser = context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
            }

            if (loggedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Logout()
        {
            loggedUser = null;
        }

        public static bool IsAuthenticated()
        {
            return loggedUser != null;
        }

        public static User GetCurrentUser()
        {
            return loggedUser;
        }
    }
}
