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
    public sealed partial class AdminEditUser : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public AdminEditUser()
        {
            this.InitializeComponent();

            loadData();
        }

        private async void loadData()
        {
            UserDetail ud = await firebaseHelper.GetUserDetailsByUserId(ListStaticData.userId);

            UserName.Text = ud.UserName;
            UserPhone.Text = ud.Phone;
            UserEmail.Text = ud.Email;
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

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveModify(null);
        }

        private async void SaveModify(Type destPage)
        {
            UserDetail ud = await firebaseHelper.GetUserDetailsByUserId(ListStaticData.userId);

            if (AreAllTextboxesFilled() && UserGender.SelectedIndex != 0)//1. All filled
            {
                try
                {
                    ud.UserName = UserName.Text;
                    ud.Gender = ((ComboBoxItem)UserGender.SelectedItem).Content.ToString();
                    ud.Email = ConvertToLowerCase(UserEmail.Text);
                    ud.Phone = UserPhone.Text;

                    GlobalVariable.CurrentUserEmail = ud.Email;

                    await firebaseHelper.UpdateUser(ud);

                    DisplayDialog("Success", "Update Successfully", destPage);
                }
                catch (Exception ex)
                {
                    DisplayDialog("ERROR", "Error : " + ex.Message, null);
                }
            }
            else
                DisplayDialog("ERROR", "Please fill in all infromation.",null);
        }

        private async void ModifyNoSave(Type destPage)
        {
            UserDetail ud = await firebaseHelper.GetUserDetailsByUserId(ListStaticData.userId);

            if (ud.UserName != UserName.Text || ud.Email != ConvertToLowerCase(UserEmail.Text) || ud.Phone != UserPhone.Text || ud.Gender != ((ComboBoxItem)UserGender.SelectedItem).Content.ToString())
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

        private bool AreAllTextboxesFilled()
        {
            // Check if all textboxes are not empty
            return UserName.Text != "" &&
                   UserIC.Text != "" &&
                   UserEmail.Text != "" &&
                   UserPhone.Text != "";
        }

        private string ConvertToLowerCase(string input)
        {
            return input.ToLower();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            ModifyNoSave(typeof(ViewUserList));
        }
    }
}
