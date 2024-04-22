using System;
using System.Collections.Generic;
using System.Globalization;
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
    public sealed partial class DisplayRoute : Page
    {
        public static TrainDetails selectedTrain = null;

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public DisplayRoute()
        {
           
            this.InitializeComponent();
            loadData();
          
        }

        private async void loadData()
        {
            List<TrainDetails> trainDetailsList = new List<TrainDetails>();
            trainDetailsList = await firebaseHelper.GetAllRoute();

            foreach (TrainDetails trainDetail in trainDetailsList)
            {
                Border lineBorder = new Border();
                lineBorder.BorderThickness = new Thickness(0, 0, 0, 1); // Bottom border only
                lineBorder.BorderBrush = new SolidColorBrush(Colors.Black); // Adjust color as needed

                Button trainButton = new Button();
                trainButton.Click += TrainButton_Click; // Attach event handler
               
                trainButton.Background = new SolidColorBrush(Colors.Transparent); // Set background color to transparent 
                trainButton.BorderBrush = null; // Remove border
                

                // Create UI elements for each train detail
                TextBlock trainIDTextBlock = new TextBlock();
                trainIDTextBlock.Text = "Train ID: " + trainDetail.trainID;

                TextBlock trainOriginTextBlock = new TextBlock();
                trainOriginTextBlock.Text = "Origin: " + trainDetail.origin;

                TextBlock trainDestinationTextBlock = new TextBlock();
                trainDestinationTextBlock.Text = "Destination: " + trainDetail.destination;

                TextBlock departDateTextBlock = new TextBlock();
                departDateTextBlock.Text = "Departure Date: " + trainDetail.departdate.ToString();

                TextBlock departTimeTextBlock = new TextBlock();
                departTimeTextBlock.Text = "Departure Time: " + trainDetail.departtime.ToString();

                TextBlock priceTextBlock = new TextBlock();
                priceTextBlock.Text = "Price: " + trainDetail.price.ToString();

                trainButton.Tag = trainDetail;

                // Add UI elements to the button
                trainButton.Content = new StackPanel
                {
                    Children = { trainIDTextBlock, trainOriginTextBlock, trainDestinationTextBlock, departDateTextBlock, departTimeTextBlock, priceTextBlock }
                };


                //// Add the UI elements to the container
                //trainDetailsContainer.Children.Add(trainIDTextBlock);
                //trainDetailsContainer.Children.Add(trainOriginTextBlock);
                //trainDetailsContainer.Children.Add(trainDestinationTextBlock);
                //trainDetailsContainer.Children.Add(departDateTextBlock);
                //trainDetailsContainer.Children.Add(departTimeTextBlock);
                //trainDetailsContainer.Children.Add(priceTextBlock);


                trainDetailsContainer.Children.Add(trainButton);


                // Add the line separator to the container
                trainDetailsContainer.Children.Add(lineBorder);

            }
        }

        private void TrainButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            selectedTrain = clickedButton.Tag as TrainDetails;

            if (selectedTrain != null)
            {
                this.Frame.Navigate(typeof(BookingPage));
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainManagement));
        }

        private void DisplayDialog(string title, string content) // done and navigate to login page
        {
            ContentDialog noDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"

            };
        }
    }
}
