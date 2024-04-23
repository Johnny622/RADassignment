using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
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

        private void ConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            // Open Payment dialog
            Payment paymentDialog = new Payment();
            _ = paymentDialog.ShowAsync();
        }

        private async void ShowAlert(string message, TextBox textBox)
        {
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
