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
    public sealed partial class AdminProfile : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public AdminProfile()
        {
            this.InitializeComponent();
            loadData();
        }

        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AreAllTextboxesFilled() && AdminGender.SelectedIndex != 0)//1. All filled
            {
                try
                {
                    AdminDetail ad = new AdminDetail();
                    ad.AdminName = AdminName.Text;
                    ad.Gender = ((ComboBoxItem)AdminGender.SelectedItem).Content.ToString();
                    ad.Email = ConvertToLowerCase(AdminEmail.Text);
                    ad.Phone = AdminPhone.Text;
                    ad.IC = AdminIC.Text;
                    ad.AdminId = AdminID.Text;

                    await firebaseHelper.UpdateAdmin(ad);

                    DisplayDialog("Success", "Update Successfully");
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "Error : " + ex.Message;
                }
            }
            else
                ErrorMessage.Text = "Please fill in all infromation.";
        }

        private void btnUserMng_Click(object sender, RoutedEventArgs e)
        {
            // admin management
        }

        private void btnTrainMng_Click(object sender, RoutedEventArgs e)
        {
            //change to view route
        }

        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            if (menuSplitView.IsPaneOpen == false) { menuSplitView.IsPaneOpen = true; rightContent.Margin = new Thickness(270, 0, 0, 0); }
            else if (menuSplitView.IsPaneOpen == true) { menuSplitView.IsPaneOpen = false; rightContent.Margin = new Thickness(80, 0, 0, 0); }
        }

        private async void loadData()
        {
            AdminDetail ad = await firebaseHelper.GetAdminDetailsByEmail(GlobalVariable.CurrentAdminEmail);

            AdminName.Text = ad.AdminName;
            AdminPhone.Text = ad.Phone;
            AdminEmail.Text = ad.Email;
            AdminID.Text = ad.AdminId;
            AdminIC.Text = ad.IC;
            foreach (ComboBoxItem item in AdminGender.Items)
            {
                if (item.Content.ToString() == ad.Gender)
                {
                    // Set the selected item
                    AdminGender.SelectedItem = item;
                    break;
                }
            }

        }

        private string ConvertToLowerCase(string input)
        {
            return input.ToLower();
        }

        private bool AreAllTextboxesFilled()
        {
            // Check if all textboxes are not empty
            return AdminName.Text != "" &&
                   AdminIC.Text != "" &&
                   AdminID.Text != "" &&
                   AdminEmail.Text != "" &&
                   AdminPhone.Text != "";
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
        }


    }
}
