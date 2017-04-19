using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHelper.Data;
using RPGHelper.Models;

namespace RPGHelper.Services
{
    public class ItemService
    {
        public static  List<Item> GetAllItems()
        {
            using (var context = new RPGHelperContext())
            {
                return context.Items.ToList();
            }
        }

        public static void Remove(Item item)
        {
            using (var context = new RPGHelperContext())
            {
                Item itemToRemove = context.Items.FirstOrDefault(i => i.Id == item.Id);
                ItemStats itemStats = context.ItemStatistics.FirstOrDefault(st => st.Item.Id == item.Id);

                if (itemStats != null)
                {
                    context.ItemStatistics.Remove(itemStats);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("gluposti");
                }
                if (itemToRemove != null)
                {
                    context.Items.Remove(itemToRemove);
                    context.SaveChanges();
                }
            }
        }

        public static Item GetItemById(Item item)
        {
            using (var context = new RPGHelperContext())
            {
                return context.Items.FirstOrDefault(i => i.Id == item.Id);
            }
        }

        public static ItemStats GetItemStatsById(int id)
        {
            using (var context = new RPGHelperContext())
            {
                return context.ItemStatistics.FirstOrDefault(it => it.Item.Id == id);
            }
        }

        public static void SaveChanges(Item item, int id, RPGHelperContext context)
        {
           var itemToSave = context.Items.Find(id);
           itemToSave.Cost = item.Cost;
           itemToSave.Description = item.Description;
           itemToSave.ItemStats = item.ItemStats;
           itemToSave.Name = item.Name;
           itemToSave.Rarity = item.Rarity;
           itemToSave.Slot = item.Slot;
           itemToSave.ItemType = item.ItemType;
           context.SaveChanges();
           
        }
    }
}
