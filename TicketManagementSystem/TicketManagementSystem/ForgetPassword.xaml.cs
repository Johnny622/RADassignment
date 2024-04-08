using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using Firebase.Auth;
using FirebaseAdmin.Auth;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketManagementSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ForgetPassword : Page
    {

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        Random random = new Random();

        public ForgetPassword()
        {
            this.InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void UserVerified_Click(object sender, RoutedEventArgs e)
        {
            if (VerifiedEmail.Text == "" || VerifiedPhone.Text == "") { ErrorMessage.Text = "Please fill the required field"; }
            else { VerifyUserInfo(); }
        }

        private async void VerifyUserInfo()
        {
            try
            {
                UserDetail ud = await firebaseHelper.GetUserDetailsByEmail(ConvertToLowerCase(VerifiedEmail.Text));
                AdminDetail ad = await firebaseHelper.GetAdminDetailsByEmail(ConvertToLowerCase(VerifiedEmail.Text));

                if (ud!=null && ud.Email == ConvertToLowerCase(VerifiedEmail.Text))
                {
                    if (ud.Phone == VerifiedPhone.Text)
                    {
                        string newpw = "";

                        if (ud != null)
                        {
                            newpw = GenerateNewPassword().ToString();
                            ud.Password = newpw;
                            await firebaseHelper.UpdateUser(ud);
                        }
                        ErrorMessage.Visibility = Visibility.Collapsed;
                        NewPwLabel.Visibility = Visibility.Visible;
                        NewPwTextBox.Visibility = Visibility.Visible;
                        BackToLoginPage.Visibility = Visibility.Visible;
                        NewPwTextBox.Text = newpw;
                    }
                    else { ErrorMessage.Text = "Phone Number is not match!"; }
                }
                else if (ad!=null && ad.Email == ConvertToLowerCase(VerifiedEmail.Text))
                {
                    if (ad.Phone == VerifiedPhone.Text)
                    {
                        string newpw = "";

                        if (ad != null)
                        {
                            newpw = GenerateNewPassword().ToString();
                            ad.Password = newpw;
                            await firebaseHelper.UpdateAdmin(ad);
                        }
                        ErrorMessage.Visibility = Visibility.Collapsed;
                        NewPwLabel.Visibility = Visibility.Visible;
                        NewPwTextBox.Visibility = Visibility.Visible;
                        BackToLoginPage.Visibility = Visibility.Visible;
                        NewPwTextBox.Text = newpw;
                    }
                    else { ErrorMessage.Text = "Phone Number is not match!"; }
                }
                else { ErrorMessage.Text = "Email: " + VerifiedEmail.Text + " not found!"; }


            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }

        private string ConvertToLowerCase(string input) { return input.ToLower(); }

        private string GenerateNewPassword()
        {
            string NewPw = RCHAR().ToString() + rchar().ToString() + RCHAR().ToString() + RINT().ToString() + RINT().ToString() + RINT().ToString() + rchar().ToString();
            return NewPw;
        }

        private char RCHAR()
        {
            char randomChar = (char)('A' + random.Next(26));
            return randomChar;
        }
        private char rchar()
        {
            char randomChar = (char)('a' + random.Next(26));
            return randomChar;
        }
        private int RINT()
        {
            int randomNumber = random.Next(10);
            return randomNumber;
        }

    }
}
