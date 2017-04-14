using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Models
{
    public class Minion
    {
        public Minion()
        {
            this.Owners = new List<Hero>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Hp { get; set; }

        [Required]
        public double Attack { get; set; }

        [Required]
        public double Defence { get; set; }

        public virtual ICollection<Hero> Owners { get; set; }
    }
}
