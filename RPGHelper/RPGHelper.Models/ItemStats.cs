using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Models
{
    public class ItemStats
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Attack { get; set; }

        [Required]
        public double Defence { get; set; }

        public int ItemId { get; set; }

        [Required]
        public virtual Item Item { get; set; }
    }
}
