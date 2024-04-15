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

        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            if (menuSplitView.IsPaneOpen == false) { menuSplitView.IsPaneOpen = true; rightContent.Margin = new Thickness(270, 0, 0, 0); }
            else if (menuSplitView.IsPaneOpen == true) { menuSplitView.IsPaneOpen = false; rightContent.Margin = new Thickness(80, 0, 0, 0); }
        }
        private void btnAdminMng_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminManagement));
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        { 
        
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeleteFirebase_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void loadFirebase()
        {
            try
            {
                List<UserDetail> ud = new List<UserDetail>();
                ud = await firebaseHelper.GetUserDetails();
                UserInfoList.ItemsSource = ud;
                ListStaticData.users = ud;
            }catch(Exception ex)
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

       
    }
}
