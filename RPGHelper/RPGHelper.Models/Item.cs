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
    public class Item
    {
        public Item()
        {
            this.ItemOwners = new List<Hero>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public string Description { get; set; } = "No description";

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public Rarity Rarity { get; set; }

        [Required]
        public ItemType ItemType { get; set; }

        [Required]
        public Slot Slot { get; set; }

        public int ItemStatsId { get; set; }

        [Required]
        public virtual ItemStats ItemStats { get; set; }

        public virtual ICollection<Hero> ItemOwners { get; set; }
    }
}
