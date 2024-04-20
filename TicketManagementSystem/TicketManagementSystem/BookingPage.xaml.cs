using Firebase.Database;
using Firebase.Database.Query;
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
            SearchTrains();
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
                List<TrainDetails> trainDetails = new List<TrainDetails>();
                trainDetails = await firebaseHelper.GetAllRoute();

                // Create a HashSet to store unique origins and destinations
                HashSet<string> uniqueOrigins = new HashSet<string>();
                HashSet<string> uniqueDestinations = new HashSet<string>();

                foreach (TrainDetails detail in trainDetails)
                {
                    string origin = detail.origin.ToUpper();
                    string destination = detail.destination.ToUpper();

                    uniqueOrigins.Add(origin);
                    uniqueDestinations.Add(destination);
                }

                // Add unique origins and destinations to ComboBoxes
                foreach (string origin in uniqueOrigins)
                {
                    cbxOrigin.Items.Add(origin);
                }

                foreach (string destination in uniqueDestinations)
                {
                    cbxDestination.Items.Add(destination);
                }
            }
            // Catch any exceptions
            catch (Exception ex)
            {
                // Handle the exception
            }
        }

        private async void SearchTrains()
        {
            try
            {
                //changeToTrain class
                List<TrainDetails> trainDetails = new List<TrainDetails>();
                trainDetails = await firebaseHelper.GetAllRoute();
                var i = 1;
                foreach (TrainDetails detail in trainDetails)
                {
                    string origin = detail.origin.ToUpper();
                    //string userOrigin = cbxOrigin.SelectedItem.ToString();

                    string departDate = detail.departdate.ToString();
                    string userDepartDate = dpDepartDate.Date.ToString("dd/M/yyyy");

                    //if (userOrigin.Equals(origin) && userDepartDate.Equals(departDate))
                    //{
                    //    cbxTrain.Items.Add("Train" + i);
                    //    i++;
                    //}
                }
                cbxTrain.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        private void cbxTrain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 获取用户选择的项
            var selectedItem = cbxTrain.SelectedItem;

            // 在这里执行你想要的操作，例如获取用户选择项的相关细节等
            // 例如：
            if (selectedItem != null)
            {
                
            }
        }
    }
}
