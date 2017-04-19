using Microsoft.Win32;
using RPGHelper.Client.ViewModels;
using RPGHelper.Data;
using RPGHelper.Models;
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
        private MessageService _messageService = new MessageService();
        private static string foundUsername = "";
        private static int currentlyOpenedInboxMsgId = -1;
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
            friendsCombobox.ItemsSource = _userService.GetFriendsUsernames(AuthenticationService.GetCurrentUser().Id, nameFilter.Text);

            InboxListView.ItemsSource = _messageService.GetReceivedMessages(AuthenticationService.GetCurrentUser().Id);
            OutboxListView.ItemsSource = _messageService.GetSentMessages(AuthenticationService.GetCurrentUser().Id);
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchArgument = searchBox.Text.Trim();
            foundUsername = string.Empty;
            addFriendButton.IsEnabled = false;
            searchStatusText.Foreground = new SolidColorBrush(Colors.MediumVioletRed);
            if (searchArgument.Equals(string.Empty))
            {
                searchStatusText.Text = "Username field cannot be empty!";
                searchBox.Focus();
                return;
            }
            if (!_userService.UserExists(searchArgument))
            {
                searchStatusText.Text = "No such user found!";
                searchBox.Focus();
                searchBox.SelectAll();
                return;
            }

            searchStatusText.Foreground = new SolidColorBrush(Colors.Green);

            foundUsername = searchBox.Text;
            searchStatusText.Text = $"User ({foundUsername}) found, press Add to make friend.";
            addFriendButton.IsEnabled = true;
            addFriendButton.Focus();

        }

        private void AddFriendButton_Click(object sender, RoutedEventArgs e)
        {
            addFriendButton.IsEnabled = false;
            searchBox.Text = string.Empty;
            if (_userService.HasFriend(foundUsername))
            {
                searchStatusText.Foreground = new SolidColorBrush(Colors.Blue);
                searchStatusText.Text = $"User ({foundUsername}) is already your friend.";
                foundUsername = string.Empty;
                return;
            }

            _userService.AddFriend(foundUsername);
            searchStatusText.Foreground = new SolidColorBrush(Colors.Green);
            searchStatusText.Text = $"User ({foundUsername}) added to friends.";
            foundUsername = string.Empty;
            searchBox.Focus();

            lvFriends.ItemsSource = _userService.GetFriends(AuthenticationService.GetCurrentUser().Id);
            friendsCombobox.ItemsSource = _userService.GetFriendsUsernames(AuthenticationService.GetCurrentUser().Id, nameFilter.Text);
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchButton_Click(sender, e);
            }
        }

        private void IgnoreSpace_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void RemoveFriendButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            User user = button.DataContext as User;
            string username = user.Username;

            _userService.RemoveFriend(username);
            searchStatusText.Foreground = new SolidColorBrush(Colors.Blue);
            searchStatusText.Text = $"User ({username}) removed from friends.";
            lvFriends.ItemsSource = _userService.GetFriends(AuthenticationService.GetCurrentUser().Id);
            friendsCombobox.ItemsSource = _userService.GetFriendsUsernames(AuthenticationService.GetCurrentUser().Id, nameFilter.Text);
        }

        private void ApplyFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            outboxStatus.Foreground = new SolidColorBrush(Colors.Blue);
            outboxStatus.Text = $"Filter applied.";
            friendsCombobox.ItemsSource = _userService.GetFriendsUsernames(AuthenticationService.GetCurrentUser().Id, nameFilter.Text);
        }

        private void RemoveFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            outboxStatus.Foreground = new SolidColorBrush(Colors.Blue);
            outboxStatus.Text = $"Filter removed.";
            nameFilter.Text = string.Empty;
            friendsCombobox.ItemsSource = _userService.GetFriendsUsernames(AuthenticationService.GetCurrentUser().Id, nameFilter.Text);
        }

        private void ClearMsg_Click(object sender, RoutedEventArgs e)
        {
            msgSubjectBox.Text = string.Empty;
            msgContentBox.Text = string.Empty;
            outboxStatus.Foreground = new SolidColorBrush(Colors.Blue);
            outboxStatus.Text = $"Fields cleared.";
        }

        private void SendMsg_Click(object sender, RoutedEventArgs e)
        {
            outboxStatus.Foreground = new SolidColorBrush(Colors.MediumVioletRed);

            string usernameSelected = friendsCombobox.Text;

            if (usernameSelected == string.Empty)
            {
                outboxStatus.Text = $"You must select a recipient!";
                return;
            }

            if (msgSubjectBox.Text.Length == 0)
            {
                outboxStatus.Text = $"Message subject cannot be empty!";
                return;
            }

            if (msgContentBox.Text.Length == 0)
            {
                outboxStatus.Text = $"Message content cannot be empty!";
                return;
            }

            if (msgSubjectBox.Text.Length > 25)
            {
                outboxStatus.Text = $"Message subject lengt exceeded!";
                msgSubjectBox.Text = msgSubjectBox.Text.Substring(0, 25);
                msgSubjectBox.Focus();
                return;
            }

            if (msgContentBox.Text.Length > 500)
            {
                outboxStatus.Text = $"Message content length exceeded!";
                msgContentBox.Text = msgContentBox.Text.Substring(0, 500);
                msgContentBox.Focus();
                return;
            }

            _messageService.SendMessage(usernameSelected, msgSubjectBox.Text, msgContentBox.Text);
            outboxStatus.Foreground = new SolidColorBrush(Colors.Green);
            outboxStatus.Text = $"Message to {usernameSelected} sent!";
            msgSubjectBox.Text = string.Empty;
            msgContentBox.Text = string.Empty;
            OutboxListView.ItemsSource = _messageService.GetSentMessages(AuthenticationService.GetCurrentUser().Id);
        }

        private void NameFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ApplyFilterBtn_Click(sender, e);
            }
        }

        private void MsgSubjectBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (msgSubjectBox.Text.Length >= 25)
            {
                if (e.Key != Key.Delete && e.Key != Key.Back)
                {
                    e.Handled = true;
                    outboxStatus.Foreground = new SolidColorBrush(Colors.MediumVioletRed);
                    outboxStatus.Text = "Subject text length allowed: 25 characters!";
                }
            }
            else
            {
                outboxStatus.Foreground = new SolidColorBrush(Colors.Blue);
                outboxStatus.Text = $"Subject characters left: {25 - msgSubjectBox.Text.Length}";
            }
        }

        private void MsgContentBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (msgContentBox.Text.Length >= 500)
            {
                if (e.Key != Key.Delete && e.Key != Key.Back)
                {
                    e.Handled = true;
                    outboxStatus.Foreground = new SolidColorBrush(Colors.MediumVioletRed);
                    outboxStatus.Text = "Content text length allowed: 500 characters!";
                }
            }
            else
            {
                outboxStatus.Foreground = new SolidColorBrush(Colors.Blue);
                outboxStatus.Text = $"Content characters left: {500 - msgContentBox.Text.Length}";
            }
        }

        private void MsgSubject_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Message msg = InboxListView.SelectedItem as Message;
                int msgId = msg.Id;

                currentlyOpenedInboxMsgId = msgId;

                Message message = _messageService.GetMessageById(msgId);

                InboxfromTextBlock.Text = message.Sender.Username;
                InboxContentBox.Text = message.Content;
                InboxOnTextBlock.Text = message.SentOn.ToString("dd'-'MM'-'yyyy H:mm");
                InboxListView.ItemsSource = _messageService.GetReceivedMessages(AuthenticationService.GetCurrentUser().Id);
            }
        }

        private void DeleteMsgFromInboxList(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Message msg = button.DataContext as Message;
            int msgId = msg.Id;

            _messageService.MarkAsDeleted(msgId);

            if (currentlyOpenedInboxMsgId != -1)
            {
                if (currentlyOpenedInboxMsgId == msgId)
                {
                    InboxfromTextBlock.Text = string.Empty;
                    InboxOnTextBlock.Text = string.Empty;
                    InboxContentBox.Text = string.Empty;
                    currentlyOpenedInboxMsgId = -1;
                }
            }
            InboxListView.ItemsSource = _messageService.GetReceivedMessages(AuthenticationService.GetCurrentUser().Id);
        }

        private void InboxDeleteCurrentMsgBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentlyOpenedInboxMsgId != -1)
            {

                InboxfromTextBlock.Text = string.Empty;
                InboxOnTextBlock.Text = string.Empty;
                InboxContentBox.Text = string.Empty;
                _messageService.MarkAsDeleted(currentlyOpenedInboxMsgId);
                currentlyOpenedInboxMsgId = -1;

                InboxListView.ItemsSource = _messageService.GetReceivedMessages(AuthenticationService.GetCurrentUser().Id);
            }
        }

        private void MsgSubjectOutbox_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Message msg = OutboxListView.SelectedItem as Message;
                int msgId = msg.Id;

                Message message = _messageService.GetMessageById(msgId);

                OutboxfromTextBlock.Text = message.Sender.Username;
                OutboxContentBox.Text = message.Content;
                OutboxOnTextBlock.Text = message.SentOn.ToString("dd'-'MM'-'yyyy H:mm");
            }
        }
    }
}
