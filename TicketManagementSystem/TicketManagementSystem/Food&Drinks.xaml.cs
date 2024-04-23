using Firebase.Database;
using Firebase.Database.Query;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Globalization;
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

    public sealed partial class Food_Drinks : Page
    {
        public double TotalPrice { get; set; } = 0;
        private int _quantity1 = 0; // Quantity for first food item
        private int _quantity2 = 0; // Quantity for second food item (assuming two items)
        private ContentDialog _currentDialog; // Variable to track the current dialog
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();
        public Food_Drinks()
        {
            this.InitializeComponent();
        }

        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            if (menuSplitView.IsPaneOpen == false)
            {
                menuSplitView.IsPaneOpen = true;
                rightContent.Margin = new Thickness(270, 0, 0, 0);
            }
            else if (menuSplitView.IsPaneOpen == true)
            {
                menuSplitView.IsPaneOpen = false;
                rightContent.Margin = new Thickness(80, 0, 0, 0);
            }
        }

        private void btnTrainMng_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BookingPage));
        }

        private void btnUserMng_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserManagement));
        }

        private void btnFood_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Food_Drinks));
        }

        private async void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (int.TryParse(textBox.Text, out int quantity))
            {
                if (quantity < 0) // Prevent negative quantity
                {
                    textBox.Text = "0";
                    ShowAlert("Quantity cannot be negative.", textBox);
                }
                else if (quantity > 5) // Limit quantity to maximum 5
                {
                    textBox.Text = ""; // Clear the text box
                    ShowAlert("Maximum quantity per item is 5.", textBox);
                }
            }
            else
            {
                textBox.Text = ""; // Clear the text box
                ShowAlert("Please enter a valid quantity.", textBox);
            }

            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            // Assuming prices are stored in variables (replace with actual price retrieval logic)
            double price1 = 5.0; // Price of first food item
            double price2 = 7.0; // Price of second food item
            _quantity1 = int.TryParse(quantityTextBox1.Text, out int qty1) ? qty1 : 0;
            _quantity2 = int.TryParse(quantityTextBox2.Text, out int qty2) ? qty2 : 0;
            TotalPrice = (_quantity1 * price1) + (_quantity2 * price2);
            totalPriceTextBox.Text = TotalPrice.ToString("C"); // Format as currency
        }

        private async void ConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            // Open Payment dialog only if no other dialog is open
            if (_currentDialog == null)
            {
                // Save data to Firebase using FirebaseHelper
                await firebaseHelper.SaveFoodDrinkEntry(_quantity1, _quantity2);

                Payment paymentDialog = new Payment();
                _currentDialog = paymentDialog;
                await paymentDialog.ShowAsync();
                _currentDialog = null; // Reset current dialog after it's closed
            }
        }
        private bool _alertShown = false;

        private async void ShowAlert(string message, TextBox textBox)
        {
            // Show alert only if no other dialog is open and alert hasn't been shown before
            if (_currentDialog == null && !_alertShown)
            {
                _alertShown = true; // Set flag to true to indicate that alert has been shown
                var dialog = new ContentDialog
                {
                    Title = "Alert",
                    Content = message,
                    CloseButtonText = "OK"
                };

                await dialog.ShowAsync();
                textBox.Text = ""; // Clear the text box
            }
        }
    }

}
