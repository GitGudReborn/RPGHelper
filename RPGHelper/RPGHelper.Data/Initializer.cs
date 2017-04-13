using RPGHelper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Data
{
    public class Initializer : DropCreateDatabaseIfModelChanges<RPGHelperContext>
    {
        protected override void Seed(RPGHelperContext context)
        {
            User seedUser1 = new User
            {
                Username = "Stoyan",
                Password = "123"
            };

            User seedUser2 = new User
            {
                Username = "Maria",
                Password = "123"
            };

            User seedUser3 = new User
            {
                Username = "Jean",
                Password = "123"
            };


            context.Users.Add(seedUser1);
            context.Users.Add(seedUser2);
            context.Users.Add(seedUser3);

            context.SaveChanges();
        }
    }
}
