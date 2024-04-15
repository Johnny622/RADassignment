using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
    public sealed partial class ViewUserList : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public ViewUserList()
        {
            this.InitializeComponent();
            loadFirebase();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListStaticData.userId = btn.Tag.ToString();
            this.Frame.Navigate(typeof(AdminEditUser));
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if (btn.Tag != null)
                {
                    UserDetail curUser = await firebaseHelper.GetUserDetailsByUserId(btn.Tag.ToString());
                    ContentDialog deleteConfirmation = new ContentDialog()
                    {
                        Title = "Delete Confirmation",
                        Content = "Do You Want To Delete User\n-> " + curUser.UserName + " ? \nWARNING!! : ANY DELETE CANNOT BE UNDO.",
                        CloseButtonText = "Cancel",
                        SecondaryButtonText = "Delete"
                    };

                    ContentDialogResult result = await deleteConfirmation.ShowAsync();

                    if (result == ContentDialogResult.Secondary)
                    {
                        await firebaseHelper.DeleteUser(btn.Tag.ToString());
                        loadFirebase();
                        DisplayDialog("Success", "User Deleted Successfully");
                    }
                }

            }
            catch (Exception theException)
            {
                // Handle all other exceptions.
                DisplayDialog("Error", "Error Message: " + theException.Message);
            }
        }

        private async void loadFirebase()
        {
            try
            {
                List<UserDetail> ud = new List<UserDetail>();
                ud = await firebaseHelper.GetUserDetails();
                UserInfoList.ItemsSource = ud;
                ListStaticData.users = ud;
            }
            catch (Exception ex)
            {
                DisplayDialog("Error", "Error Message: " + ex.Message);
            }
        }
        private async void DisplayDialog(string title, string content)
        {
            ContentDialog noDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await noDialog.ShowAsync();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminManagement));
        }
    }
}
