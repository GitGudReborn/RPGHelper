using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public DateTime SentOn { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }

        [Required]
        public virtual User Sender { get; set; }

        [ForeignKey("Recipient")]
        public int RecipientId { get; set; }

        [Required]
        public virtual User Recipient { get; set; }
    }
}
