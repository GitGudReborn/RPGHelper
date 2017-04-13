using RPGHelper.Client.ViewModels;
using RPGHelper.Data;
using RPGHelper.Services;
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

namespace RPGHelper.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RPGHelperContext context = new RPGHelperContext();
        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            var pvm = new ProfileViewModel()
            {
                User = AuthenticationService.GetCurrentUser()
            };
            DataContext = pvm;           
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var pvm = new ProfileViewModel()
            {
                User = AuthenticationService.GetCurrentUser()
            };
            DataContext = pvm;
        }

        private void HeroesBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new HeroesViewModel();
        }

        private void ItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ItemsViewModel();
        }

        private void ImportExportBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ImportExportViewModel();
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var newLoginWindow = new Login();
            newLoginWindow.Show();
            this.Close();
            AuthenticationService.Logout();
            MessageBox.Show("You are no longed loged in");
        }
    }
}
