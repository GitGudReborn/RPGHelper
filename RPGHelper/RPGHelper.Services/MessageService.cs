using RPGHelper.Data;
using RPGHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Services
{
    public class MessageService
    {
        public void SendMessage(string usernameSelected, string subject, string content)
        {
            using (var context = new RPGHelperContext())
            {
                int userId = AuthenticationService.GetCurrentUser().Id;

                var sender = context.Users.FirstOrDefault(u => u.Id == userId);

                var recipient = context.Users.FirstOrDefault(u => u.Username == usernameSelected);

                Message msg = new Message
                {
                    Subject = subject,
                    Content = content,
                    Sender = sender,
                    Recipient = recipient,
                    SentOn = DateTime.Now
                };

                context.Messages.Add(msg);
                context.SaveChanges();
            }
        }
    }
}
