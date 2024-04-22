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
    public sealed partial class AddRoute : Page

    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<TrainDetails> trainDetails;

        public AddRoute()
        {
            this.InitializeComponent();
            availableseat.Text = "240";

        }

        public async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (AllTextboxesFilled())
            {
              trainDetails = await firebaseHelper.GetAllRoute();
                if(departdate.SelectedDate >= arrivaldate.SelectedDate )
                {
                    if(departtime.SelectedTime > arrivaltime.SelectedTime)
                    {
                        try
                        {
                            TrainDetails traindetail = new TrainDetails();
                            traindetail.origin = origin.Text.ToString();
                            traindetail.destination = destination.Text.ToString();
                            traindetail.trainID = trainID.Text.ToString();
                            traindetail.price = price.Text.ToString();
                            traindetail.availableseat = availableseat.Text.ToString();
                            traindetail.departdate = departdate.SelectedDate.Value.ToString("dd-MM-yyyy");
                            traindetail.arrivaldate = arrivaldate.SelectedDate.Value.ToString("dd-MM-yyyy");
                            traindetail.departtime = departtime.SelectedTime.Value.ToString();
                            traindetail.arrivaltime = arrivaltime.SelectedTime.Value.ToString();

                            await firebaseHelper.AddRoute(traindetail);

                            DisplayDialog("Successful Message", "Add Route Successfully");

                        }
                        catch
                        {
                            DisplayDialog("Error Message", "Fail to add route");
                        }
                    }
                    else
                    {

                        DisplayDialog("Error Message", "arrival time cannot be late than depart time ");
                    }

                }
                else
                {

                    DisplayDialog("Error Message", "Depart date cannot be late than arrival date");
                }

               

            }
            else
            {
                DisplayDialog("Error Message", "Please key in the fields");
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainManagement));
        }

        private bool AllTextboxesFilled()
        {
            // Check if all textboxes are not empty
            return origin.Text != "" &&
                   destination.Text != "" &&
                   trainID != null &&
                   price.Text != "" &&
                   availableseat.Text != "" &&
                   departdate.SelectedDate != null &&
                   arrivaldate.SelectedDate != null &&
                   departtime.SelectedTime != null &&
                   arrivaltime.SelectedTime != null;
        }

      


        private async void DisplayDialog(string title, string content) // done and navigate to login page
        {
            ContentDialog noDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"

            };

            ContentDialogResult result = await noDialog.ShowAsync();
         
            
        }
    }
}
