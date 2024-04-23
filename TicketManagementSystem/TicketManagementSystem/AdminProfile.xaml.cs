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
            Window.Current.SizeChanged += Window_SizeChanged;
            loadData();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveModify(null);
        }

        private void btnAdminMng_Click(object sender, RoutedEventArgs e)
        {
            ModifyNoSave(typeof(AdminManagement));
            // admin management
            //this.Frame.Navigate(typeof(AdminManagement));
        }

        private void btnTrainMng_Click(object sender, RoutedEventArgs e)
        {
            ModifyNoSave(typeof(TrainManagement));
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

        private async void DisplayDialog(string title, string content, Type destPage) // done and navigate to login page
        {
            ContentDialog noDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"

            };

            ContentDialogResult result = await noDialog.ShowAsync();
            if (destPage != null)
            {
                if (result == ContentDialogResult.None || result == ContentDialogResult.Primary)
                {
                    this.Frame.Navigate(destPage);
                }
            }
        }

        private void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            // Adjust layout here based on the new window size
            double newWidth = e.Size.Width;
            foreach (UIElement element in AdminProfileGrid.Children)
            {
                if (element is FrameworkElement)
                {
                    // Example: Resize all child elements proportionally based on window width
                    FrameworkElement child = (FrameworkElement)element;
                    child.Width = newWidth * 0.8; // Adjust the factor according to your design
                }
            }
        }

        private async void ModifyNoSave(Type destPage)
        {
            AdminDetail ad = await firebaseHelper.GetAdminDetailsByEmail(GlobalVariable.CurrentAdminEmail);

            if (ad.Email != ConvertToLowerCase(AdminEmail.Text) || ad.Phone != AdminPhone.Text || ad.Gender != ((ComboBoxItem)AdminGender.SelectedItem).Content.ToString())
            {
                ContentDialog noDialog = new ContentDialog
                {
                    Title = "Warning",
                    Content = "You have unsaved modify data!\nDo you want to save it?",
                    CloseButtonText = "Not Save",
                    SecondaryButtonText = "Save"

                };

                ContentDialogResult result = await noDialog.ShowAsync();
                if (result == ContentDialogResult.Secondary)
                {
                    SaveModify(destPage);

                }
                else if (result == ContentDialogResult.None || result == ContentDialogResult.Primary)
                {
                    this.Frame.Navigate(destPage);
                }
            }
            else
            {
                this.Frame.Navigate(destPage);
            }
        }

        private async void SaveModify(Type destPage)
        {
            AdminDetail ad = await firebaseHelper.GetAdminDetailsByEmail(GlobalVariable.CurrentAdminEmail);
            if (AreAllTextboxesFilled() && AdminGender.SelectedIndex != 0)//1. All filled
            {
                try
                {
                    ad.Gender = ((ComboBoxItem)AdminGender.SelectedItem).Content.ToString();
                    ad.Email = ConvertToLowerCase(AdminEmail.Text);
                    ad.Phone = AdminPhone.Text;

                    GlobalVariable.CurrentAdminEmail = ad.Email;

                    await firebaseHelper.UpdateAdmin(ad);

                    DisplayDialog("Success", "Update Successfully", destPage);
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "Error : " + ex.Message;
                }
            }
            else
                ErrorMessage.Text = "Please fill in all infromation.";
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            ModifyNoSave(typeof(HelpManagement));
        }

        private void AdminProfile_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                SubmitBtn_Click(sender, e);
            }
        }

        private void AdminCombo_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                SubmitBtn_Click(sender, e);
            }
        }

        private void btnViewUser_Click(object sender, RoutedEventArgs e)
        {
            ModifyNoSave(typeof(ViewUserList));
        }
    }
}
