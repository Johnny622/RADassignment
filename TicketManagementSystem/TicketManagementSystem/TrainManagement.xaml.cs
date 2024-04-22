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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketManagementSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TrainManagement : Page
    {
       // FirebaseHelper firebaseHelper = new FirebaseHelper();
        public TrainManagement()
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
        private void addRoutebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddRoute));
        }
        private void deleteRoutebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DeleteRoute));
        }
        private void viewRoutebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DisplayRoute));
        }
    }
}