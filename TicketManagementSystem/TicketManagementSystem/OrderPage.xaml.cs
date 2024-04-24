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
using static TicketManagementSystem.Class.FirebaseHelper;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketManagementSystem
{
    public sealed partial class OrderPage : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();

        public OrderPage()
        {
            this.InitializeComponent();
            LoadData();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string timestamp = button.Tag.ToString();

                // Call the DeleteFoodDrinkEntry method from FirebaseHelper to delete the record
                await firebaseHelper.DeleteFoodDrinkEntry(timestamp);

                // Refresh the ListBox data
                LoadData();
            }
        }

        private async void LoadData()
        {
            var entries = await firebaseHelper.GetFoodDrinkEntries();
            listBox.ItemsSource = entries;
        }
        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            if (menuSplitView.IsPaneOpen == false) { menuSplitView.IsPaneOpen = true; rightContent.Margin = new Thickness(270, 0, 0, 0); }
            else if (menuSplitView.IsPaneOpen == true) { menuSplitView.IsPaneOpen = false; rightContent.Margin = new Thickness(80, 0, 0, 0); }
        }
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HelpManagement));
        }
        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OrderPage));
        }
        private void btnTrainMng_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainManagement));
        }
        private void btnViewUser_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewUserList));
        }

    }

}

