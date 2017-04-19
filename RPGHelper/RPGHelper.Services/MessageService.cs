using RPGHelper.Data;
using RPGHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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

        public IEnumerable GetReceivedMessages(int id)
        {
            using (var context = new RPGHelperContext())
            {
                return context.Messages.Include("Sender").Where(m => m.RecipientId == id && m.IsDeleted == false).OrderByDescending(o => o.SentOn).ToList();
            }
        }

        public Message GetMessageById(int msgId)
        {
            using (var context = new RPGHelperContext())
            {
               var msg = context.Messages.Include("Sender").Include("Recipient").FirstOrDefault(m => m.Id == msgId);

                msg.IsRead = true;
                context.SaveChanges();

                return msg;
            }
        }

        public void MarkAsDeleted(int msgId)
        {
            using (var context = new RPGHelperContext())
            {
                var msg = context.Messages.Include("Sender").Include("Recipient").FirstOrDefault(m => m.Id == msgId);

                msg.IsDeleted = true;
                context.SaveChanges();
            }
        }

        public IEnumerable GetSentMessages(int id)
        {
            using (var context = new RPGHelperContext())
            {
                return context.Messages.Include("Recipient").Where(m => m.Sender.Id == id).OrderByDescending(o => o.SentOn).ToList();
            }
        }
    }
}
