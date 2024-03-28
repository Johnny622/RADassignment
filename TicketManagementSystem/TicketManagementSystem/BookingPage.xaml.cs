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
    public sealed partial class BookingPage : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public BookingPage()
        {
            this.InitializeComponent();
            loadTrainDetails();
        }

        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            menuSplitView.IsPaneOpen = !menuSplitView.IsPaneOpen;
            if (menuSplitView.IsPaneOpen == true)
            {
                rightContent.Margin = new Thickness(270, 0, 0, 0);
            }
            else
            {
                rightContent.Margin = new Thickness(80, 0, 0, 0);
            }
        }

        private void btnUserMng_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnChooseSeat_Click(object sender, RoutedEventArgs e)
        {
            SeatSelectionDialog dialog = new SeatSelectionDialog();
            await dialog.ShowAsync();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            spGroup2.Visibility = Visibility.Visible;
            string origin = cbxOrigin.SelectedItem?.ToString();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PassengerDetailPage));
        }

        private async void loadTrainDetails()
        {
            try
            {
                //changeToTrain class
                List<PassengerDetails> passengerDetails = new List<PassengerDetails>();
                passengerDetails = await firebaseHelper.GetAllUsers();
                
                foreach(PassengerDetails passenger in passengerDetails)
                {
                    cbxOrigin.Items.Add(passenger.Name);
                    cbxDestination.Items.Add(passenger.Phone);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
