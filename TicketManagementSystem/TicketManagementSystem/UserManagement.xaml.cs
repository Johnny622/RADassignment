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

        private async void DeleteAccBtn_Click(object sender, RoutedEventArgs e)
        {
            UserDetail ud = await firebaseHelper.GetUserDetailsByEmail(GlobalVariable.CurrentUserEmail);

            ContentDialog deleteConfirm = new ContentDialog
            {
                Title = "Delete User",
                Content = "Confirm to PERMANANTLY delete user : " + ud.UserName + " ? \nAlert : AFTER DELETE CANNOT BE RECOVER.",
                CloseButtonText = "Cancel",
                PrimaryButtonText = "OK"
            };

            ContentDialogResult result = await deleteConfirm.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                await firebaseHelper.DeleteUser(GlobalVariable.CurrentUserID);
                DisplayDialog("Success", "User Deleted Successfully");
            }
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            //handle logout
            this.Frame.Navigate(typeof(LoginPage));
        }
        private async void DisplayDialog(string title, string content) // done and navigate to login page
        {
            ContentDialog noDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"

            };

            ContentDialogResult result = await noDialog.ShowAsync();

            if (result == ContentDialogResult.None || result == ContentDialogResult.Primary)
            {
                this.Frame.Navigate(typeof(LoginPage));
            }
        }
    }
}
