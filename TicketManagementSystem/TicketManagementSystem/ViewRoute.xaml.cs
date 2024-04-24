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
    public sealed partial class ViewRoute : Page
    {

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public ViewRoute()
        {
            this.InitializeComponent();

            loadFirebase();
        }

        private async void loadFirebase()
        {
            try
            {
                List<TrainDetails> trainDetailsList = new List<TrainDetails>();
                trainDetailsList = await firebaseHelper.GetAllRoute();

                foreach (TrainDetails trainDetail in trainDetailsList)
                {
                    Border lineBorder = new Border();
                    lineBorder.BorderThickness = new Thickness(0, 0, 0, 1); // Bottom border only
                    lineBorder.BorderBrush = new SolidColorBrush(Colors.Black); // Adjust color as needed


                    //Border border = new Border();
                    //Border border = new Border();
                    //border.BorderThickness = new Thickness(1); // Adjust border thickness as needed
                    //border.BorderBrush = new SolidColorBrush(Colors.Black); // Adjust border color as needed
                    //border.Margin = new Thickness(0, 0, 0, 0); // Add margin between each border (adjust as needed)

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
                    departTimeTextBlock.Text = "Departure Time: " + trainDetail.departtime;

                    TextBlock price = new TextBlock();
                    price.Text = "Price: " + trainDetail.price.ToString();

                    // Add the UI elements to the container
                    trainDetailsContainer.Children.Add(trainIDTextBlock);
                    trainDetailsContainer.Children.Add(trainOriginTextBlock);
                    trainDetailsContainer.Children.Add(trainDestinationTextBlock);
                    trainDetailsContainer.Children.Add(departDateTextBlock);
                    trainDetailsContainer.Children.Add(departTimeTextBlock);
                    trainDetailsContainer.Children.Add(price);

                    // Add the border to the container

                    //trainDetailsContainer.Children.Add(lineBorder);

                    // Add the line separator to the container
                    trainDetailsContainer.Children.Add(lineBorder);

                }
            }
            catch (Exception e)
            {
                DisplayDialog("Error", "Error Message: " + e.Message);
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
