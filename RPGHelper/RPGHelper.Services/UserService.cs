using RPGHelper.Data;
using RPGHelper.Models;
using RPGHelper.Models.Enum;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void ChangeProfilePicture(string imageName)
        {
            using (var context = new RPGHelperContext())
            {
                var userId = AuthenticationService.GetCurrentUser().Id;

                var user = context.Users.FirstOrDefault(u => u.Id == userId);

                string oldImage = user.ImgPath;

                if (oldImage != "anonymous-person.png" && !oldImage.Contains("stock"))
                {
                    try
                    {
                        File.Delete($@"..\..\Media\ProfilePictures\{oldImage}");
                    }
                    catch (Exception)
                    {
                    }
                }

                user.ImgPath = imageName;
                context.SaveChanges();
                AuthenticationService.Refresh();
            }
        }

        public void EditProfile(string firstName, string lastName, string email, DateTime? date, string password, string genderValue)
        {
            using (var context = new RPGHelperContext())
            {
                int userId = AuthenticationService.GetCurrentUser().Id;

                var user = context.Users.FirstOrDefault(u => u.Id == userId);

                user.FirstName = firstName;
                user.LastName = lastName;
                user.Email = email;
                user.Birthdate = date;
                user.Password = password;

                Gender gen = Gender.NotSpecified;

                Enum.TryParse(genderValue, out gen);

                user.Gender = gen;

                context.SaveChanges();

                AuthenticationService.Logout();
                AuthenticationService.Login(user.Username, user.Password);
            }
        }
    }
}
