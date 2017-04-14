using RPGHelper.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

namespace RPGHelper.Client
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            statusText.Text = "Enter username and password";
            
        }

        private void usernameAndPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if (usernameBox.Text.Length == 0 || passwordBox.Password.Length == 0 || repeatpasswordBox.Password.Length == 0)
            {
                statusText.Text = "Enter username and password";
            }
            else
            {
                statusText.Text = "";
            }


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (usernameBox.Text.Length < 3 || usernameBox.Text.Length > 15)
            {
                statusText.Text = "Username length allowed: 3-15";
                return;
            }

            if (passwordBox.Password != repeatpasswordBox.Password)
            {
                statusText.Text = "Passwords don't match!";
                return;
            }

            if (passwordBox.Password.Length < 3 || passwordBox.Password.Length > 15)
            {
                statusText.Text = "Password length allowed: 3-15";
                return;
            }
            else
            {
                UserService userService = new UserService();

                if (userService.UserExists(usernameBox.Text))
                {
                    statusText.Text = "Username is taken :(";
                    return;
                }
                else
                {
                    userService.Register(usernameBox.Text, passwordBox.Password);
                    statusText.Text = "Registering";
                    statusText.Foreground = new SolidColorBrush(Colors.Green);
                    SoundPlayer soundPlayer = new SoundPlayer(@"..\..\Media\successSound.wav");
                    soundPlayer.Play();
                    this.Close();
                }
            }            
        }
    }
}
