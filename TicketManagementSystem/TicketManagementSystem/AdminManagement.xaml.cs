using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TicketManagementSystem.Class;
using Windows.Devices.AllJoyn;
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
    public sealed partial class AdminManagement : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public AdminManagement()
        {
            this.InitializeComponent();
            WelcomeMessage();
        }
        private async void WelcomeMessage()
        {
            AdminDetail ad = await firebaseHelper.GetAdminDetailsByEmail(GlobalVariable.CurrentAdminEmail);
            WelcomeMsg.Text = "Welcome , " + ad.AdminName.ToString() + " !";
        }

        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            if (menuSplitView.IsPaneOpen == false) { menuSplitView.IsPaneOpen = true; rightContent.Margin = new Thickness(270, 0, 0, 0); }
            else if (menuSplitView.IsPaneOpen == true) { menuSplitView.IsPaneOpen = false; rightContent.Margin = new Thickness(80, 0, 0, 0); }
        }

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminProfile));
        }

        private void ChangePwBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminChangePassword));
        }

        private async void DeleteAccBtn_Click(object sender, RoutedEventArgs e)
        {
            List<AdminDetail> adList = await firebaseHelper.GetAdminDetails();
            int count = adList.Count();
            if (count == 1)
            {
                DisplayDialog("Warning", "You Are Not Allowed To Delete Admin Account If Only One Admin Account Left!",null);
            }
            else if (count > 1)
            {
                AdminDetail ad = await firebaseHelper.GetAdminDetailsByEmail(GlobalVariable.CurrentAdminEmail);

                ContentDialog deleteConfirm = new ContentDialog
                {
                    Title = "Delete Admin",
                    Content = "Confirm to PERMANANTLY delete user : " + ad.AdminName + " ? \nAlert : AFTER DELETE CANNOT BE RECOVER.",
                    CloseButtonText = "Cancel",
                    PrimaryButtonText = "OK"
                };

                ContentDialogResult result = await deleteConfirm.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    await firebaseHelper.DeleteAdmin(GlobalVariable.CurrentAdminID);
                    DisplayDialog("Success", "User Deleted Successfully",typeof(LoginPage));
                }
            }
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void AddTrainRoute_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewAdminRegister));
        }

        private void ViewUserBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBar_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private async void DisplayDialog(string title, string content, Type destinationPage) // done and navigate to login page
        {
            ContentDialog noDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"

            };

            ContentDialogResult result = await noDialog.ShowAsync();

            if (destinationPage != null)
            {
                if (result == ContentDialogResult.None || result == ContentDialogResult.Primary)
                {
                    this.Frame.Navigate(destinationPage);
                }
            }
        }
    }
}
