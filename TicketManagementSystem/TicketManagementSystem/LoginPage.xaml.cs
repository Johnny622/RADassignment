using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TicketManagementSystem.Class;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketManagementSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private string adminORuser;
        private bool isAdmin = false;
        private bool isUser = false;

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text == "")
            {
                ErrorMessage.Visibility = Visibility.Visible;
                ErrorMessage.Text = "Please Insert Valid Email.";
            }
            else //1. No Empty Email
            {
                if (PasswordTextBox.Text == "")
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    ErrorMessage.Text = "Please Insert Password.";
                }
                else //2. No Empty Password
                {
                    if (isAdmin == false && isUser == false)
                    {
                        ErrorMessage.Visibility = Visibility.Visible;
                        ErrorMessage.Text = "Please Choose User or Admin.";
                    }
                    else
                    {
                        ErrorMessage.Visibility = Visibility.Collapsed;
                        this.Frame.Navigate(typeof(UserManagement));
                    }
                }
            }
        }

        private void LoginBtnUser_Click(object sender, RoutedEventArgs e)
        {
            LoginBtnAdmin.Background.Opacity = 0.2;
            LoginBtnUser.Background.Opacity = 0.8;
            adminORuser = "user";
            isUser = true;
            isAdmin = false;
        }

        private void LoginBtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            LoginBtnUser.Background.Opacity = 0.2;
            LoginBtnAdmin.Background.Opacity = 0.8;
            adminORuser = "admin";
            isAdmin = true;
            isUser = false;
        }

        //private async void LoadFromFireBase()
        //{
        //    try
        //    {
        //        List<User> allUsers = new List<User>();
        //        allUsers = await firebaseHelper.GetAllUsers();
        //        UserInfoList.ItemsSource = allUsers;

        //    }
        //    catch (Exception theException)
        //    {
        //        // Handle all other exceptions.
        //        DisplayDialog("Error", "Error Message: " + theException.Message);
        //    }
        //}

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewUserRegister));
        }
    }
}
