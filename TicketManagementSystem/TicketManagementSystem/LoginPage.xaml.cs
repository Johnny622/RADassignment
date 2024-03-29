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
        private string adminORuser;
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
                    if (isAdmin == false && isUser == false)
                    {
                        ErrorMessage.Visibility = Visibility.Visible;
                        ErrorMessage.Text = "Please Choose User or Admin.";
                    }
                    else if(isUser==true)
                    {
                        ErrorMessage.Visibility = Visibility.Visible;
                        string email = EmailTextBox.Text;
                        string password = PasswordTextBox.Password;
                        UserDetail userDetails = await firebaseHelper.GetUserDetailsByEmail(ConvertToLowerCase(email));

                        if (userDetails != null)
                        {
                            if (userDetails.Password.Equals(password))
                            {
                               GlobalVariable.CurrentUserEmail = userDetails.Email;

                                this.Frame.Navigate(typeof(UserManagement));
                            }
                            else
                                ErrorMessage.Text = "Incorrect Password.";
                        }
                        else
                            ErrorMessage.Text = "Email cannot find";
                    }else if(isAdmin == true)
                    {
                        //go admin section
                        this.Frame.Navigate (typeof(AdminManagement));
                    }
                }
            }
        }


        private void LoginBtnUser_Click(object sender, RoutedEventArgs e)
        {
            LoginBtnAdmin.Background.Opacity = 0.2;
            LoginBtnUser.Background.Opacity = 0.8;
            adminORuser = "user";
            isUser = true;
            isAdmin = false;
        }

        private void LoginBtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            LoginBtnUser.Background.Opacity = 0.2;
            LoginBtnAdmin.Background.Opacity = 0.8;
            adminORuser = "admin";
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
    }
}
