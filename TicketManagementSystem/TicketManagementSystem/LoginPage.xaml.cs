using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TicketManagementSystem.Class;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using System.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketManagementSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class LoginPage : Page
    {
        private bool isAdmin = false;
        private bool isUser = false;

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text == "")
            {
                ErrorMessage.Visibility = Visibility.Visible;
                ErrorMessage.Text = "Please Insert Valid Email.";
            }
            else //1. No Empty Email
            {
                if (PasswordTextBox.Password == "")
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    ErrorMessage.Text = "Please Insert Password.";
                }
                else //2. No Empty Password
                {
                    if (!isAdmin && !isUser)
                    {
                        ErrorMessage.Visibility = Visibility.Visible;
                        ErrorMessage.Text = "Please Choose User or Admin.";
                    }
                    else if (isUser)
                    {
                        string email = EmailTextBox.Text;
                        string password = PasswordTextBox.Password;
                        UserDetail userDetails = await firebaseHelper.GetUserDetailsByEmail(ConvertToLowerCase(email));

                        if (userDetails != null)
                        {
                            if (userDetails.Password.Equals(password))
                            {
                                ErrorMessage.Visibility = Visibility.Collapsed;
                                GlobalVariable.CurrentUserID = userDetails.UserId;
                                GlobalVariable.CurrentUserEmail = userDetails.Email;

                                this.Frame.Navigate(typeof(UserManagement));
                            }
                            else
                            {
                                ErrorMessage.Visibility = Visibility.Visible;
                                ErrorMessage.Text = "Incorrect Password.";
                                PasswordTextBox.Password = string.Empty;
                                PasswordTextBox.Focus(FocusState.Programmatic);
                            }
                        }
                        else
                        {
                            ErrorMessage.Visibility = Visibility.Visible;
                            ErrorMessage.Text = "Email cannot find";
                            PasswordTextBox.Password = string.Empty;
                            EmailTextBox.Focus(FocusState.Programmatic);
                        }
                    }
                    else if (isAdmin)
                    {
                        string email = EmailTextBox.Text;
                        string password = PasswordTextBox.Password;
                        AdminDetail adminDetails = await firebaseHelper.GetAdminDetailsByEmail(ConvertToLowerCase(email));

                        if (adminDetails != null)
                        {
                            if (adminDetails.Password.Equals(password))
                            {
                                ErrorMessage.Visibility = Visibility.Collapsed;
                                GlobalVariable.CurrentAdminID = adminDetails.AdminId;
                                GlobalVariable.CurrentAdminEmail = adminDetails.Email;

                                this.Frame.Navigate(typeof(AdminManagement));
                            }
                            else
                            {
                                ErrorMessage.Visibility = Visibility.Visible;
                                ErrorMessage.Text = "Incorrect Password.";
                                PasswordTextBox.Password = string.Empty;
                                PasswordTextBox.Focus(FocusState.Programmatic);
                            }
                        }
                        else
                        {
                            ErrorMessage.Visibility = Visibility.Visible;
                            ErrorMessage.Text = "Email cannot find";
                            PasswordTextBox.Password = string.Empty;
                            EmailTextBox.Focus(FocusState.Programmatic);
                        }

                    }
                }
            }
        }


        private void LoginBtnUser_Click(object sender, RoutedEventArgs e)
        {
            LoginBtnAdmin.Background.Opacity = 0.2;
            LoginBtnUser.Background.Opacity = 0.8;
            isUser = true;
            isAdmin = false;
        }

        private void LoginBtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            LoginBtnUser.Background.Opacity = 0.2;
            LoginBtnAdmin.Background.Opacity = 0.8;
            isAdmin = true;
            isUser = false;
        }

        private void SignUpNew_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewUserRegister));
        }

        private string ConvertToLowerCase(string input)
        {
            return input.ToLower();
        }

        private void ForgetPw_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ForgetPassword));
        }

        private void LoginEnter_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                LoginBtn_Click(sender, e);
            }
        }

        private void LoginUserNameEnter_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                PasswordTextBox.Focus(FocusState.Programmatic);
            }
        }
    }
}
