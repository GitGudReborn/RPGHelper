using Microsoft.Win32;
using RPGHelper.Client.ViewModels;
using RPGHelper.Data;
using RPGHelper.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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

            string userGender = AuthenticationService.GetCurrentUser().Gender.ToString();

            if (userGender == "Male")
            {
                maleComboBoxItem.IsSelected = true;
            }
            else if (userGender == "Female")
            {
                femaleComboBoxItem.IsSelected = true;
            }
            else
            {
                notSpecComboBoxItem.IsSelected = true;
            }

            passBox1.Password = AuthenticationService.GetCurrentUser().Password;
            passBox2.Password = passBox1.Password;

            lvFriends.ItemsSource = _userService.GetFriends(AuthenticationService.GetCurrentUser().Id);
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
                if (stock1.IsChecked == true)
                {
                    string img = "stock1.jpg";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock2.IsChecked == true)
                {
                    string img = "stock2.jpg";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock3.IsChecked == true)
                {
                    string img = "stock3.jpg";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock4.IsChecked == true)
                {
                    string img = "stock4.jpg";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock5.IsChecked == true)
                {
                    string img = "stock5.jpg";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock6.IsChecked == true)
                {
                    string img = "stock6.jpg";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock7.IsChecked == true)
                {
                    string img = "stock7.jpg";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock8.IsChecked == true)
                {
                    string img = "stock8.PNG";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock9.IsChecked == true)
                {
                    string img = "stock9.PNG";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock10.IsChecked == true)
                {
                    string img = "stock10.PNG";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock11.IsChecked == true)
                {
                    string img = "stock11.PNG";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
                if (stock12.IsChecked == true)
                {
                    string img = "stock12.PNG";
                    _userService.ChangeProfilePicture(img);
                    UpdateProfilePic(img);
                    return;
                }
            }
        }

        private void UpdateProfilePic(string imgPath)
        {
            string path = Environment.CurrentDirectory;
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, $@"..\..\Media\ProfilePictures\{imgPath ?? "anonymous-person.png"}"));

            var uri = new Uri(newPath, UriKind.Absolute);

            var image = new BitmapImage(uri);
            ProfilePic.Source = image;
        }

        private void Btn_SaveProfileEdit(object sender, RoutedEventArgs e)
        {
            stsBarTextBlock.Foreground = new SolidColorBrush(Colors.MediumVioletRed);
            if (firstNameBox.Text == null || firstNameBox.Text.Length < 3 || firstNameBox.Text.Length > 40)
            {
                stsBarTextBlock.Text = "First name length allowed: 3-40!";
                firstNameBox.Focus();
                firstNameBox.SelectAll();
                return;
            }
            if (lastNameBox.Text == null || lastNameBox.Text.Length < 3 || lastNameBox.Text.Length > 40)
            {
                stsBarTextBlock.Text = "Last name length allowed: 3-40!";
                lastNameBox.Focus();
                lastNameBox.SelectAll();
                return;
            }

            if (emailBox.Text == null || emailBox.Text.Length < 7 || emailBox.Text.Length > 100)
            {
                stsBarTextBlock.Text = "Email not valid!";
                emailBox.Focus();
                emailBox.SelectAll();
                return;
            }

            var date = dateBox.SelectedDate;
            if (date == null)
            {
                stsBarTextBlock.Text = "Date not valid!";
                dateBox.Focus();
                return;
            }

            if (passBox1.Password != passBox2.Password)
            {
                stsBarTextBlock.Text = "Passwords don't match!";
                passBox1.Focus();
                passBox1.Password = "";
                passBox2.Password = passBox1.Password;
                return;
            }

            if (passBox1.Password.Length < 3 || passBox1.Password.Length > 15)
            {
                stsBarTextBlock.Text = "Password length allowed: 3-40!";
                passBox1.Focus();
                passBox1.Password = "";
                passBox2.Password = passBox1.Password;
                return;
            }

            string genderValue = (genderComboBox.SelectedItem as ComboBoxItem).Content.ToString();

            _userService.EditProfile(firstNameBox.Text, lastNameBox.Text, emailBox.Text, date, passBox1.Password, genderValue);

            bdayRun.Text = date.Value.ToString("dd-MM-yyyy");
            firstNameRun.Text = firstNameBox.Text;
            lastNameRun.Text = lastNameBox.Text;
            emailRun.Text = emailBox.Text;
            genderRun.Text = genderValue;

            firstNameBox.Text = string.Empty;
            lastNameBox.Text = string.Empty;
            emailBox.Text = string.Empty;
            passBox1.Password = string.Empty;
            passBox2.Password = passBox1.Password;
            SoundPlayer soundPlayer = new SoundPlayer(@"..\..\Media\successSound.wav");
            soundPlayer.Play();
            stsBarTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            stsBarTextBlock.Text = "Success!";
        }

        private void Btn_CancelProfileEdit(object sender, RoutedEventArgs e)
        {
            stsBarTextBlock.Foreground = new SolidColorBrush(Colors.Blue);
            firstNameBox.Text = string.Empty;
            lastNameBox.Text = string.Empty;
            emailBox.Text = string.Empty;
            passBox1.Password = string.Empty;
            passBox2.Password = passBox1.Password;
            SoundPlayer soundPlayer = new SoundPlayer(@"..\..\Media\cancel.wav");
            soundPlayer.Play();
            stsBarTextBlock.Text = "Canceled, all clear!";
        }
    }
}
