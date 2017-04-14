using RPGHelper.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Models
{
    public class HeroStats
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Hp { get; set; }

        [Required]
        public double Mana { get; set; }

        [Required]
        public double Defence { get; set; }

        [Required]
        public double AttackPower { get; set; }

        [Required]
        public Affiliation Affiliation { get; set; }

        [Required]
        public virtual Hero Hero { get; set; }
    }
}
