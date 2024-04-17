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
    public sealed partial class AdminChangePassword : Page
    {
        private int MIN_LENGTH = 8;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public AdminChangePassword()
        {
            this.InitializeComponent();
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
        private void btnUserMng_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminManagement));
        }

        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminDetail ad = await firebaseHelper.GetAdminDetailsByEmail(GlobalVariable.CurrentAdminEmail);

            if (CurPw.Password == ad.Password)
            {
                string newpw = NewPw.Password;
                string confpw = ConfPw.Password;
                if (newpw.Length >= MIN_LENGTH && NumberUpperCase(newpw) >= 1 && NumberLowerCase(newpw) >= 1 && NumberDigits(newpw) >= 1)
                {
                    if (newpw.Equals(confpw) && newpw.Equals(CurPw.Password))
                    {
                        ErrorMessage.Text = "New Password Cannot Same As Current Password";
                        NewPw.Password = string.Empty;
                        ConfPw.Password = string.Empty;
                        NewPw.Focus(FocusState.Programmatic);
                    }
                    else if (newpw.Equals(confpw))
                    {
                        ad.Password = confpw;

                        await firebaseHelper.UpdateAdmin(ad);
                        ErrorMessage.Visibility = Visibility.Collapsed;
                        DisplayDialog("Success", "Update Successfully");
                        CurPw.Password = "";
                        NewPw.Password = "";
                        ConfPw.Password = "";
                    }
                    else
                    {
                        ErrorMessage.Text = "New Password Not Equal with Confirm Password";
                    }
                }
                else
                {
                    ErrorMessage.Text = "Not fulfil the password requirement.";
                }
            }
            else
                ErrorMessage.Text = "Please Enter Current Password.";
        }
        private int NumberUpperCase(string str)
        {
            int upperCase = 0;  // The number of uppercase letters

            // Count the uppercase characters in str.
            foreach (char ch in str)
            {
                if (char.IsUpper(ch))
                {
                    upperCase++;
                }
            }

            // Return the number of uppercase characters.
            return upperCase;
        }

        private int NumberLowerCase(string str)
        {
            int lowerCase = 0;  // The number of lowercase letters

            // Count the lowercase characters in str.
            foreach (char ch in str)
            {
                if (char.IsLower(ch))
                {
                    lowerCase++;
                }
            }

            // Return the number of lowercase characters.
            return lowerCase;
        }

        private int NumberDigits(string str)
        {
            int digits = 0;  // The number of digits

            // Count the digits in str.
            foreach (char ch in str)
            {
                if (char.IsDigit(ch))
                {
                    digits++;
                }
            }

            // Return the number of digits.
            return digits;
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

            if(result == ContentDialogResult.None)
            {
                this.Frame.Navigate(typeof(AdminManagement));
            }
        }
    }
}
