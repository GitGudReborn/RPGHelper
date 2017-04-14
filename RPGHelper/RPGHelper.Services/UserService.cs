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

        public bool UserExists(string username)
        {
            using (var context = new RPGHelperContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public void Register(string username, string password)
        {
            using (var context = new RPGHelperContext())
            {
                User user = new User
                {
                    Username = username,
                    Password = password
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
