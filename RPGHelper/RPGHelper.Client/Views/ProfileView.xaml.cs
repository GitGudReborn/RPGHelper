using Microsoft.Win32;
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

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (rdoBtnOwn.IsChecked == true)
            {
                if (avatarPic.Source != null)
                {
                    var imagePath = ((BitmapImage)avatarPic.Source).UriSource.AbsolutePath;

                    imagePath = Uri.UnescapeDataString(imagePath);

                    string extension = imagePath.Substring(imagePath.Length - 4).ToLower();

                    if (extension == ".jpg" || extension == "jpeg")
                    {
                        var imageName = $"{Utilities.RandomString(10)}.jpg";
                        using (var fileStream = new FileStream($@"..\..\Media\ProfilePictures\{imageName}", FileMode.Create))
                        {
                            BitmapEncoder encoder = new JpegBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(new Uri(imagePath, UriKind.Absolute)));
                            encoder.Save(fileStream);

                        }
                        _userService.ChangeProfilePicture(imageName);
                    }
                    else if (extension == ".png")
                    {
                        var imageName = $"{Utilities.RandomString(10)}.PNG";
                        using (var fileStream = new FileStream($@"..\..\Media\ProfilePictures\{imageName}", FileMode.Create))
                        {
                            BitmapEncoder encoder = new PngBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(new Uri(imagePath, UriKind.Absolute)));
                            encoder.Save(fileStream);

                        }
                        _userService.ChangeProfilePicture(imageName);
                    }
                    ProfilePic.Source = avatarPic.Source;
                    avatarPic.Source = null;
                }
                else
                {
                    MessageBox.Show("Image cannot be empty");
                }
            }
            else
            {

            }
        }
    }
}
