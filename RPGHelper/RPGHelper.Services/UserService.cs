using RPGHelper.Data;
using RPGHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Services
{
    public class UserService
    {
        public User GetUser(string username, RPGHelperContext context)
        {
            var user = context.Users.FirstOrDefault(u => u.Username == username);

            return user;
        }

        public User GetUser(int id, RPGHelperContext context)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }
    }
}
