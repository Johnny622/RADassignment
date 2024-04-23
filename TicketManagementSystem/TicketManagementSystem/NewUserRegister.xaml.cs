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
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
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
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();
        private Windows.Storage.StorageFile file;
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
                    if (isExistEmail == false)
                    {
                        if (isPasswordEqual())
                        {
                            if (isMyKadEqual())
                            {
                                if (file != null)
                                {
                                    var stream = await file.OpenStreamForReadAsync();

                                    Guid fileName = Guid.NewGuid();

                                    var str = await firebaseStorageHelper.UploadFile(stream, fileName + file.FileType.ToString());
                                    try
                                    {
                                        UserDetail ud = new UserDetail();
                                        ud.UserName = SignUpFullName.Text;
                                        ud.Gender = ((ComboBoxItem)SignUpGender.SelectedItem).Content.ToString();
                                        ud.Email = ConvertToLowerCase(SignUpEmail.Text);
                                        ud.Phone = SignUpContact.Text;
                                        ud.IC = SignUpMyKad.Text;
                                        ud.Password = SignUpPassword.Password;
                                        ud.ProfileName = fileName + file.FileType.ToString();
                                        ud.ProfileURL = str;

                                        await firebaseHelper.AddUserDetail(ud);

                                        DisplayDialog("Success", "Sign Up Successfully");
                                    }
                                    catch (Exception ex)
                                    {
                                        ErrorMessage.Text = "Error : " + ex.Message;
                                    }
                                }
                                else
                                    ErrorMessage.Text = "Error : Picture havent choose.";
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
        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".jpeg");
                picker.FileTypeFilter.Add(".png");

                file = await picker.PickSingleFileAsync();

                using (var fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    // Create a BitmapImage to hold the image
                    BitmapImage bitmapImage = new BitmapImage();

                    // Set the source of the BitmapImage to the file stream
                    bitmapImage.SetSource(fileStream);

                    // Set the Source property of the image control
                    imgProfile.Source = bitmapImage;
                }


            }
            catch (Exception theException)
            {
                // Handle all other exceptions.
                DisplayDialog("Error", "Error Message: " + theException.Message);

            }
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

        private void StackPanel_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                SignUpSubmitBtn_Click(sender, e);
            }
        }
    }
}
