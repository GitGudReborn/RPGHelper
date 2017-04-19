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
    /// Interaction logic for ItemEditView.xaml
    /// </summary>
    public partial class ItemEditView : Window
    {
        private Item currentItem;
        private RPGHelperContext context = new RPGHelperContext();

        public ItemEditView()
        {
            InitializeComponent();
            currentItem = ItemsView.GetCurrentItem();
            DataContext = currentItem;
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
            decimal cost = decimal.Parse(Cost.Text);
            string description = Description.Text;
            string itemType = ItemType.Text;
            string rarity = Rarity.Text;
            string slot = Slot.Text;

            double attack = double.Parse(Attack.Text);
            double defence = double.Parse(Defence.Text);

            Item item = context.Items.Find(currentItem.Id);

            item.Cost = cost;
            item.Name = name;
            item.Description = description;
            item.ItemType = (ItemType)Enum.Parse(typeof(ItemType),itemType);
            item.Slot = (Slot) Enum.Parse(typeof(Slot), slot);
            item.Rarity = (Rarity) Enum.Parse(typeof(Rarity), rarity);

            ItemStats itemStat = context.ItemStatistics.FirstOrDefault(st=> st.Item.Id==currentItem.Id);
            itemStat.Attack = attack;
            itemStat.Defence = defence;
            item.ItemStats = itemStat;

            context.SaveChanges();
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
