using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Models
{
    public class Hero
    {
        public Hero()
        {
            this.Items = new List<Item>();
            this.Minions = new List<Minion>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal Gold { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public virtual ICollection<Minion> Minions { get; set; }

        [Required]
        public virtual HeroStats HeroStats { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
