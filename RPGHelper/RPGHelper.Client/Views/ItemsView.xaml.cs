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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RPGHelper.Models;
using RPGHelper.Services;

namespace RPGHelper.Client.Views
{
    /// <summary>
    /// Interaction logic for ItemsView.xaml
    /// </summary>
    public partial class ItemsView : UserControl
    {
        private List<Item> items = new List<Item>();
        public ItemsView()
        {
            InitializeComponent();
            items = ItemService.GetAllItems();
            DataContext = items;
        }

        private void DetailsShow_Click(object sender, RoutedEventArgs e)
        {
            var details = new ItemDetails();
            details.Show();
        }
    }
}
