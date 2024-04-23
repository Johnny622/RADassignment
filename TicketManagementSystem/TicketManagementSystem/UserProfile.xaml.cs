using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TicketManagementSystem.Class;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.UserDataAccounts;
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
    public sealed partial class UserProfile : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public UserProfile()
        {
            this.InitializeComponent();
            loadData();
        }
        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            if (menuSplitView.IsPaneOpen == false) { menuSplitView.IsPaneOpen = true; rightContent.Margin = new Thickness(270, 0, 0, 0); }
            else if (menuSplitView.IsPaneOpen == true) { menuSplitView.IsPaneOpen = false; rightContent.Margin = new Thickness(80, 0, 0, 0); }
        }

        private void btnTrainMng_Click(object sender, RoutedEventArgs e)
        {
           

        }
        private void btnUserMng_Click(object sender, RoutedEventArgs e)
        {
            ModifyNoSave(typeof(UserManagement));
            //this.Frame.Navigate(typeof(UserManagement));
        }

        private async void loadData()
        {
            UserDetail ud = await firebaseHelper.GetUserDetailsByEmail(GlobalVariable.CurrentUserEmail);

            UserName.Text = ud.UserName;
            UserPhone.Text = ud.Phone;
            UserEmail.Text = ud.Email;
            UserID.Text = ud.UserId;
            UserIC.Text = ud.IC;
            foreach (ComboBoxItem item in UserGender.Items)
            {
                if (item.Content.ToString() == ud.Gender)
                {
                    // Set the selected item
                    UserGender.SelectedItem = item;
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
            return UserName.Text != "" &&
                   UserIC.Text != "" &&
                   UserID.Text != "" &&
                   UserEmail.Text != "" &&
                   UserPhone.Text != "";
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

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveModify(null);
        }

        private async void SaveModify(Type destPage)
        {
            UserDetail ud = await firebaseHelper.GetUserDetailsByEmail(GlobalVariable.CurrentUserEmail);

            if (AreAllTextboxesFilled() && UserGender.SelectedIndex != 0)//1. All filled
            {
                try
                {
                    ud.Gender = ((ComboBoxItem)UserGender.SelectedItem).Content.ToString();
                    ud.Email = ConvertToLowerCase(UserEmail.Text);
                    ud.Phone = UserPhone.Text;

                    GlobalVariable.CurrentUserEmail = ud.Email;

                    await firebaseHelper.UpdateUser(ud);

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

        private async void ModifyNoSave(Type destPage)
        {
            UserDetail ud = await firebaseHelper.GetUserDetailsByEmail(GlobalVariable.CurrentUserEmail);

            if (ud.Email != ConvertToLowerCase(UserEmail.Text) || ud.Phone != UserPhone.Text || ud.Gender != ((ComboBoxItem)UserGender.SelectedItem).Content.ToString())
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

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            ModifyNoSave(typeof(HelpManagement));
            //this.Frame.Navigate(typeof(HelpManagement));
        }

        private void btnFood_Click(object sender, RoutedEventArgs e)
        {
            ModifyNoSave(typeof(Food_Drinks));
            //this.Frame.Navigate(typeof(Food_Drinks));
        }

        private void UserProfile_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                SubmitBtn_Click(sender, e);
            }
        }
        private void UserCombo_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                SubmitBtn_Click(sender, e);
            }
        }

        private void btnTrainBooking_Click(object sender, RoutedEventArgs e)
        {
            ModifyNoSave(typeof(BookingPage));
            //this.Frame.Navigate(typeof(BookingPage));
        }
    }
}
