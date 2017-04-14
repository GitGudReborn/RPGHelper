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
using System.Windows.Shapes;

namespace RPGHelper.Client
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            FocusManager.SetFocusedElement(this, usernameBox);
            InitDB.InitiateDB();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(usernameBox.Text + passwordBox.Password);
            if (AuthenticationService.Login(usernameBox.Text, passwordBox.Password))
            {
                var mainwindow = new MainWindow();
                this.Close();
                mainwindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid args");
            }
        }

        private void usernameAndPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SubmitBtn_Click(sender, e);
            }
        }
    }
}
