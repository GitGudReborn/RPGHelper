using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RPGHelper.Client.Views;
using RPGHelper.Data;
using RPGHelper.Models;
using RPGHelper.Models.Enum;
using RPGHelper.Services;

namespace RPGHelper.Client.Views
{
    /// <summary>
    /// Interaction logic for AddNewItemView.xaml
    /// </summary>
    public partial class AddNewItemView : Window
    {
        private Item currentItem;
        private RPGHelperContext context = new RPGHelperContext();

        public AddNewItemView()
        {
            InitializeComponent();
        }

        private void Move(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            currentItem = ItemsView.GetCurrentItem();
            string name = Name.Text;
            decimal cost;
            bool result = decimal.TryParse(Cost.Text, out cost);
            string description = Description.Text;
            string itemType = ItemType.Text;
            string rarity = Rarity.Text;
            string slot = Slot.Text;

            double attack;
            double defence;
            bool result1 = double.TryParse(Attack.Text, out attack);
            bool result2 = double.TryParse(Defence.Text,out defence);

            if (name == "Enter Name" || name.Length <= 3)
            {
                MessageBox.Show("Name must be at least 3 characters.");
                return;
            }
            if (!result || !result1 || !result2 || attack <= 0 || defence <= 0 || cost <= 0 )
            {
                MessageBox.Show("Invalid number.");
                return;
            }

            if(itemType == "" || (itemType != "Weapon" && itemType != "Consumable" && itemType != "Utility" && itemType != "Armor"))
            {
                MessageBox.Show("Invalid Item Type.");
                return;
            }

            if (rarity != "Common" && rarity != "Uncommon" && rarity != "Rare" && 
                rarity != "Mythical" && rarity != "Legendary" && rarity != "Ancient" 
                && rarity != "Immortal" && rarity != "Arcana")
            {
                MessageBox.Show("Invalid Rarity");
                return;
            }

            if (slot != "Head" && slot!="Torso" && slot!="Hands" && slot!="Legs" 
                && slot!="Feet" && slot!= "Backpack" && slot!="Weapon")
            {
                MessageBox.Show("Invalid Slot");
                return;
            }
            Item item = new Item();

            item.Cost = cost;
            item.Name = name;
            item.Description = description;
            item.ItemType = (ItemType)Enum.Parse(typeof(ItemType),itemType);
            item.Slot = (Slot) Enum.Parse(typeof(Slot), slot);
            item.Rarity = (Rarity) Enum.Parse(typeof(Rarity), rarity);

            ItemStats itemStat = new ItemStats();
            itemStat.Attack = attack;
            itemStat.Defence = defence;

            //context add items,itemstats,save changes
            ItemService.SaveItem(item, itemStat);
            MessageBox.Show("Item added successfully.");
            ItemsView.items = ItemService.GetAllItems();
            this.Close();
        }

        private void ItemTypeButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            ItemType.Text = button.Content.ToString();
        }

        private void RarityButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            Rarity.Text = button.Content.ToString();
        }

        private void SlotButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            Slot.Text = button.Content.ToString();
        }
    }
}
