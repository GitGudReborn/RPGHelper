using RPGHelper.Client.ViewModels;
using RPGHelper.Data;
using RPGHelper.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
            var user = AuthenticationService.GetCurrentUser();

            string path = Environment.CurrentDirectory;
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, $@"..\..\Media\ProfilePictures\{user.ImgPath ?? "anonymous-person.png"}"));

            var uri = new Uri(newPath, UriKind.Absolute);

            var image = new BitmapImage(uri);
            user.ImageSource = image;
            var pvm = new ProfileViewModel()
            {
                User = user

            };
            DataContext = pvm;           
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = AuthenticationService.GetCurrentUser();

            string path = Environment.CurrentDirectory;
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, $@"..\..\Media\ProfilePictures\{user.ImgPath ?? "anonymous-person.png"}"));

            var uri = new Uri(newPath, UriKind.Absolute);

            var image = new BitmapImage(uri);
            user.ImageSource = image;
            var pvm = new ProfileViewModel()
            {
                User = user

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
            DataContext = new AboutViewModel();
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var newLoginWindow = new Login();
            newLoginWindow.Show();
            this.Close();
            AuthenticationService.Logout();
        }
    }
}
