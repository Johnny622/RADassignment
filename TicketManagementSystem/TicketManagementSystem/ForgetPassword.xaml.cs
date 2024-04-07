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
            bool isEmailCorrect = false;
            bool isPhoneCorrect = false;
            List<UserDetail> userDetails = await firebaseHelper.GetUserDetails();
            List<UserDetail> allUser = new List<UserDetail>();
            allUser = await firebaseHelper.GetUserDetails();
            ListStaticData.users = allUser;

            foreach (UserDetail userDetail in userDetails)
            {
                isEmailCorrect = false;
                isPhoneCorrect = false;
                if (userDetail.Email == ConvertToLowerCase(VerifiedEmail.Text))
                {
                    isEmailCorrect = true;
                    if (isEmailCorrect)
                    {
                        if (userDetail.Phone == VerifiedPhone.Text)
                        {
                            isPhoneCorrect = true;
                            ListStaticData.userId = userDetail.UserId;
                            string newpw = GenerateNewPassword().ToString();
                            var itemToUpdate = ListStaticData.users.SingleOrDefault(r => r.UserId == ListStaticData.userId);
                            if (itemToUpdate != null)
                            {
                                itemToUpdate.Password = newpw;
                                await firebaseHelper.UpdateUser(itemToUpdate);
                            }
                            ErrorMessage.Visibility = Visibility.Collapsed;
                            NewPwLabel.Visibility = Visibility.Visible;
                            NewPwTextBox.Visibility = Visibility.Visible;
                            BackToLoginPage.Visibility = Visibility.Visible;
                            NewPwTextBox.Text = newpw;

                            break;
                        }
                    }
                }
            }
            if (!isEmailCorrect) { ErrorMessage.Text = "Invalid Email"; }
            else if (!isPhoneCorrect) { ErrorMessage.Text = "Invalid Phone Number"; }
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

        private async void LoadFirebase()
        {
            try
            {
                List<UserDetail> allUsers = new List<UserDetail>();
                allUsers = await firebaseHelper.GetUserDetails();
                ListStaticData.users = allUsers;
            }
            catch (Exception theException)
            {
                // Handle all other exceptions.
               NewPwTextBox.Text += theException.Message;
            }
        }
    }
}
