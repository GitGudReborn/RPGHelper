using Microsoft.Win32;
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

namespace RPGHelper.Client.Views
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        private RPGHelperContext _context = new RPGHelperContext();
        private UserService _userService = new UserService();
        public ProfileView()
        {
            InitializeComponent();

            string imgName = AuthenticationService.GetCurrentUser().ImgPath;

            BitmapImage profileImage = new BitmapImage();
            profileImage.BeginInit();
            profileImage.UriSource = new Uri($@"..\..\Media\ProfilePictures\{imgName}", UriKind.Relative);
            profileImage.EndInit();

            ProfilePic.Source = profileImage;
            avatarPic.Source = profileImage;

            
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                avatarPic.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
    }
}
