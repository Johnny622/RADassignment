using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
    public sealed partial class NewUserRegister : Page
    {
        private int MIN_LENGTH = 8;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public NewUserRegister()
        {
            this.InitializeComponent();
        }

        private async void SignUpSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            bool isExistEmail = false;
            if (AreAllTextboxesFilled() && SignUpGender.SelectedIndex != 0)//1. All filled
            {
                if (isEmailEqual())
                {
                    List<UserDetail> userDetails = await firebaseHelper.GetUserDetails();

                    foreach (UserDetail userDetail in userDetails)
                    {
                        if (userDetail.Email == ConvertToLowerCase(SignUpEmail.Text))
                        {
                            isExistEmail = true;
                            break;
                        }
                    }
                    if (isExistEmail==false)
                    {
                        if (isPasswordEqual())
                        {
                            if (isMyKadEqual())
                            {
                                try
                                {
                                    UserDetail ud = new UserDetail();
                                    ud.UserName = SignUpFullName.Text;
                                    ud.Gender = ((ComboBoxItem)SignUpGender.SelectedItem).Content.ToString();
                                    ud.Email = ConvertToLowerCase(  SignUpEmail.Text);
                                    ud.Phone = SignUpContact.Text;
                                    ud.IC = SignUpMyKad.Text;
                                    ud.Password = SignUpPassword.Password;

                                    await firebaseHelper.AddUserDetail(ud);

                                    DisplayDialog("Success", "Sign Up Successfully");
                                }
                                catch (Exception ex)
                                {
                                    ErrorMessage.Text = "Error : " + ex.Message;
                                }
                            }
                            else
                                ErrorMessage.Text = "Both MyKad No. is not same.";
                        }
                    }
                    else
                        ErrorMessage.Text = "Email had exist.";
                }
                else
                    ErrorMessage.Text = "Confirm email is not same with Email.";
            }
            else
                ErrorMessage.Text = "Please fill in all the required infromation.";
        }

        private bool AreAllTextboxesFilled()
        {
            // Check if all textboxes are not empty
            return SignUpEmail.Text != "" &&
                   SignUpPassword.Password != "" &&
                   SignUpFullName.Text != "" &&
                   SignUpMyKad.Text != "" &&
                   SignUpConfEmail.Text != "" &&
                   SignUpConfPassword.Password != "" &&
                   SignUpContact.Text != "" &&
                   SignUpConfMyKad.Text != "";
        }

        private bool isEmailEqual()
        {
            return ConvertToLowerCase(SignUpEmail.Text).Equals(ConvertToLowerCase(SignUpConfEmail.Text));
        }

        private bool isMyKadEqual()
        {
            return SignUpMyKad.Text.Equals(SignUpConfMyKad.Text);
        }

        private bool isPasswordEqual()
        {
            bool tf = false;
            string password = SignUpPassword.Password;
            string ConfPassword = SignUpConfPassword.Password;

            if (password.Length >= MIN_LENGTH && NumberUpperCase(password) >= 1 && NumberLowerCase(password) >= 1 && NumberDigits(password) >= 1)
            {
                if (password.Equals(ConfPassword))
                {
                    tf = true;
                }
                else
                {
                    ErrorMessage.Text = "Both password not same.";
                }
            }
            else
            {
                ErrorMessage.Text = "Not fulfil the password requirement.";
            }
            return tf;
        }

        private string ConvertToLowerCase(string input)
        {
            return input.ToLower();
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

            if (result == ContentDialogResult.None || result == ContentDialogResult.Primary)
            {
                this.Frame.Navigate(typeof(LoginPage));
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
