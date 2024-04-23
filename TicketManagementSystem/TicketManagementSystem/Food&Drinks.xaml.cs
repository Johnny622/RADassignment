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

        public Food_Drinks()
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
            Frame.Navigate(typeof(UserManagement));
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            // Logic to increase quantity and update total price
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            // Logic to decrease quantity and update total price
        }

        private void ConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            // Open Payment dialog
            Payment paymentDialog = new Payment();
            _ = paymentDialog.ShowAsync();
        }
    }
}
