using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TicketManagementSystem.Class;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class SummaryTrainInfo : Page
    {
        public static TrainDetails selectedTrain = null;

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public SummaryTrainInfo()
        {
            this.InitializeComponent();
            loadData();
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

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (HelpManagement));
        }

        private async void loadData()
        {
            List<PassengerDetails> passengerDetails = new List<PassengerDetails>();
            passengerDetails = await firebaseHelper.GetAllPassengers();

            foreach (PassengerDetails passenger in passengerDetails)
            {
                Border lineBorder = new Border();
                lineBorder.BorderThickness = new Thickness(0, 0, 0, 1); // Bottom border only
                lineBorder.BorderBrush = new SolidColorBrush(Colors.Black); // Adjust color as needed

                Button trainButton = new Button();

                trainButton.Background = new SolidColorBrush(Colors.Transparent); // Set background color to transparent 
                trainButton.BorderBrush = null; // Remove border


                // Create UI elements for each train detail
                TextBlock name = new TextBlock();
                name.Text = "Name: " + passenger.Name;

                TextBlock tbGender = new TextBlock();
                tbGender.Text = "Gender: " + passenger.Gender;

                TextBlock tbIC = new TextBlock();
                tbIC.Text = "IC: " + passenger.IC;

                TextBlock tbPhone = new TextBlock();
                tbPhone.Text = "Phone: " + passenger.Phone;

                TextBlock tbSeat = new TextBlock();
                tbSeat.Text = "Seat Number: " + passenger.SeatNumber;

                TextBlock tbCoach = new TextBlock();
                tbCoach.Text = "Coach: " + passenger.Coach;

                trainButton.Tag = passenger;

                // Add UI elements to the button
                trainButton.Content = new StackPanel
                {
                    Children = { name, tbGender, tbIC, tbPhone, tbSeat, tbCoach}
                };

                passengerDetailsContainer.Children.Add(trainButton);


                // Add the line separator to the container
                passengerDetailsContainer.Children.Add(lineBorder);

            }
        }
    }
}
