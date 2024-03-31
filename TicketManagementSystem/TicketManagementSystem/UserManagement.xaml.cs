using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TicketManagementSystem.Class;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class UserManagement : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public UserManagement()
        {
            this.InitializeComponent();
            WelcomeMessage();
        }

        private async void WelcomeMessage()
        {
            UserDetail userDetails = await firebaseHelper.GetUserDetailsByEmail(GlobalVariable.CurrentUserEmail);
            WelcomeMsg.Text = "Welcome , " + userDetails.UserName.ToString() + " !";
        }

        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            if (menuSplitView.IsPaneOpen == false) { menuSplitView.IsPaneOpen = true; rightContent.Margin = new Thickness(270, 0, 0, 0); }
            else if (menuSplitView.IsPaneOpen == true) { menuSplitView.IsPaneOpen = false; rightContent.Margin = new Thickness(80, 0, 0, 0); }
        }

        private void btnTrainMng_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BookingPage));
        }

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserProfile));
        }

        private void ChangePwBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ChangePassword));
        }

        private void DeleteAccBtn_Click(object sender, RoutedEventArgs e)
        {
            //handle delete account
        }

        private void HelpfulLinkBtn_Click(object sender, RoutedEventArgs e)
        {
            //display another page with helpful infromation
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            //handle logout
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
