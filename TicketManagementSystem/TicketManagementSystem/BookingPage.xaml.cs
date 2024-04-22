using Firebase.Database;
using Firebase.Database.Query;
using LiteDB;
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
            Frame.Navigate(typeof(UserManagement));
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
                cbxOrigin.SelectedIndex = 0;
                cbxDestination.SelectedIndex = 0;
            }
            // Catch any exceptions
            catch (Exception ex)
            {
                string errorMessage = ex.Message; 
            }
        }

        private async void SearchTrains()
        {
            try
            {
                cbxTrain.Items.Clear();
                cbxReturnTrain.Items.Clear();
                txtReturnDepartTime.Text = "NA";
                txtReturnETA.Text = "NA";
                txtReturnSeat.Text = "0";
                txtReturnPrice.Text = "0";
                tbDepartTime.Text = "NA";
                tbArrivalTime.Text = "NA";
                seat.Text = "0";
                price.Text = "0.00";
                List<TrainDetails> trainDetails = new List<TrainDetails>();
                trainDetails = await firebaseHelper.GetAllRoute();
                int pax;
                if (int.TryParse(txtPax.Text, out pax))
                {
                    ListStaticData.noOfPax = pax;
                }
                else
                {
                    DisplayDialog("Error Input", "Must be a number");
                }

                if(cbReturn.IsChecked == true)
                {
                    spReturnInformation.Visibility = Visibility.Visible;
                }

                foreach (TrainDetails detail in trainDetails)
                {
                    string origin = detail.origin.ToUpper();
                    string userOrigin = cbxOrigin.SelectedItem.ToString();
                    string destination = detail.destination.ToUpper();
                    string userDestination = cbxDestination.SelectedItem.ToString();

                    string departDate = detail.departdate.ToString();
                    string userDepartDate = dpDepartDate.Date.ToString("dd-MM-yyyy");
                    string userReturnDate = dpReturnDate.Date.ToString("dd-MM-yyyy");
                    int trainNo = detail.trainID;

                    //depart information
                    if (userOrigin.Equals(origin) && userDestination.Equals(destination) && userDepartDate.Equals(departDate))
                    {                       
                        cbxTrain.Items.Add(trainNo);
                    }
                    //return information
                    if (userDestination.Equals(origin) && userOrigin.Equals(destination) && userReturnDate.Equals(departDate))
                    {
                        cbxReturnTrain.Items.Add(trainNo);
                    }
                }
                cbxTrain.SelectedIndex = 0;
                cbxReturnTrain.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                DisplayDialog("Error Message",ex.Message);
            }
        }

        decimal departPrice, returnPrice, totalTicketPrice;

        private async void cbxTrain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtTotal.Text = string.Empty;
            var selectedItem = cbxTrain.SelectedItem;

            if (selectedItem != null)
            {
                List<TrainDetails> trainDetails = new List<TrainDetails>();
                trainDetails = await firebaseHelper.GetAllRoute();
                var i = 1;
                foreach (TrainDetails detail in trainDetails)
                {
                    if (selectedItem.Equals(detail.trainID))
                    {
                        tbDepartTime.Text = detail.departtime.ToString();
                        tbArrivalTime.Text = detail.arrivaltime.ToString();
                        seat.Text = "240";
                        price.Text = detail.price.ToString();
                    }
                }
                departPrice = decimal.Parse(price.Text);
                returnPrice = decimal.Parse(txtReturnPrice.Text);
                totalTicketPrice = departPrice + returnPrice;
                txtTotal.Text = totalTicketPrice.ToString("N2");
            }
        }

        private async void cbxReturnTrain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtTotal.Text = string.Empty;
            var selectedItem = cbxReturnTrain.SelectedItem;

            if (selectedItem != null)
            {
                List<TrainDetails> trainDetails = new List<TrainDetails>();
                trainDetails = await firebaseHelper.GetAllRoute();
                var i = 1;
                foreach (TrainDetails detail in trainDetails)
                {
                    if (selectedItem.Equals(detail.trainID))
                    {
                        txtReturnDepartTime.Text = detail.departtime.ToString();
                        txtReturnETA.Text = detail.arrivaltime.ToString();
                        txtReturnSeat.Text = detail.availableseat.ToString();
                        txtReturnPrice.Text = detail.price.ToString();
                    }
                }
                departPrice = decimal.Parse(price.Text);
                returnPrice = decimal.Parse(txtReturnPrice.Text);
                totalTicketPrice = departPrice + returnPrice;
                txtTotal.Text = totalTicketPrice.ToString("N2");
            }
        }

        private async void DisplayDialog(string title, string content)
        {
            ContentDialog noDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"

            };

            ContentDialogResult result = await noDialog.ShowAsync();
        }

        private void cbReturn_Checked(object sender, RoutedEventArgs e)
        {
            spReturn.Visibility = Visibility.Visible;
        }

        private void cbReturn_Unchecked(object sender, RoutedEventArgs e)
        {
            spReturn.Visibility = Visibility.Collapsed;
        }
    }
}
