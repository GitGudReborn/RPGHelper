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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = AuthenticationService.GetCurrentUser();


            var user = _userService.GetUser(currentUser.Id, _context);

            user.Username = usernameBox.Text;
            user.Password = passwordBox.Text;

            _context.SaveChanges();

            AuthenticationService.Login(user.Username, user.Password);
            MessageBox.Show("Changes saved to DB");
        }
    }
}
