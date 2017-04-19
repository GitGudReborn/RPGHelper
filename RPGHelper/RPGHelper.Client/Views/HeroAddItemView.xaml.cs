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
using RPGHelper.Data;
using RPGHelper.Models;

namespace RPGHelper.Client.Views
{
    /// <summary>
    /// Interaction logic for HeroAddItemView.xaml
    /// </summary>
    public partial class HeroAddItemView : Window
    {
        private RPGHelperContext context = new RPGHelperContext();
        private Hero currentHero = new Hero();

        public HeroAddItemView(Hero currentHero)
        {
            InitializeComponent();

            this.currentHero = currentHero;

            ItemsSourceLoad();
        }

        public void ItemsSourceLoad()
        {
            ItemsBox.ItemsSource = context.Items
                .Where(i => !i.ItemOwners.Any(o => o.Id == currentHero.Id))
                .ToList();
        }

        private void SaveHeroItem_Button(object sender, RoutedEventArgs e)
        {
            if (ItemsBox.SelectionBoxItem != null && ItemsBox.SelectionBoxItem != "")
            {
                var currentItem = (Item)ItemsBox.SelectionBoxItem;

                var itemFromDB = context.Items.FirstOrDefault(i => i.Id == currentItem.Id);

                if (itemFromDB != null)
                {

                    this.currentHero.Items.Add(itemFromDB);
                    context.SaveChanges();
                    ItemsSourceLoad();
                    stsBarTextBlock.Foreground = new SolidColorBrush(Colors.Green);
                    stsBarTextBlock.Text = "Success!";
                }
            }
            else
            {
                stsBarTextBlock.Foreground = new SolidColorBrush(Colors.MediumVioletRed);
                stsBarTextBlock.Text = "Select some Item!";
            }
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            stsBarTextBlock.Foreground = new SolidColorBrush(Colors.Blue);

            ItemsBox.Text = string.Empty;

            stsBarTextBlock.Text = "Canceled, all clear!";
        }
    }
}
