using RPGHelper.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RPGHelper.Models
{
    public class User
    {
        public User()
        {
            this.Heroes = new List<Hero>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Password { get; set; }

        public string FirstName { get; set; } = "N/A";

        public string LastName { get; set; } = "N/A";

        public string Email { get; set; } = "N/A";

        public Gender Gender { get; set; } = Gender.NotSpecified;

        public DateTime? Birthdate { get; set; }

        public string ImgPath { get; set; } = "anonymous-person.png";

        [NotMapped]
        public BitmapImage ImageSource { get; set; }

        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
