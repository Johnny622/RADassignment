using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using static System.Net.WebRequestMethods;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicketManagementSystem
{
    public sealed partial class SeatSelectionDialog : ContentDialog
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public SeatSelectionDialog()
        {
            this.InitializeComponent();
            this.Content = new SeatSelectionPage();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)  //cancel button
        {

        }

        private async void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)  //confirm button
        {
            SeatSelectionPage seatSelectionPage = (SeatSelectionPage)this.Content;

            foreach (Button selectedSeatButton in SeatManagement.SelectedSeatButtons)
            {
                string selectedSeat = selectedSeatButton.Tag.ToString();

                if (seatSelectionPage.IsSeatAvailable(selectedSeat))
                {
                    seatSelectionPage.ReserveSeat(selectedSeat);

                    seatSelectionPage.UpdateSeatAppearance(selectedSeatButton, isBooked: true);

                    try
                    {
                        // Check if the selected seat is not null and is reserved
                        if (!string.IsNullOrEmpty(selectedSeat) && !seatSelectionPage.IsSeatAvailable(selectedSeat))
                        {
                            PassengerDetails p = new PassengerDetails();
                            p.IsReserved = true;
                            p.SeatNumber = selectedSeat;

                            await firebaseHelper.AddUser(p);

                            //DisplayDialog("Success", "User Added Successfully");

                            // Set variables to null after adding to Firebase
                            selectedSeat = null;
                        }

                        // Check if the selected seat is not null and is not reserved
                        else if (!string.IsNullOrEmpty(selectedSeat) && seatSelectionPage.IsSeatAvailable(selectedSeat))
                        {
                            // Simulate a waiting period of 15 minutes
                            await Task.Delay(TimeSpan.FromMinutes(15));

                            // Release the seat
                            seatSelectionPage.ReleaseSeat(selectedSeat);
                            seatSelectionPage.UpdateSeatAppearance(selectedSeatButton, isBooked: false);

                            //DisplayDialog("Payment Fail", "Payment was not completed within 15 minutes.");
                        }
                        else
                        {
                            //DisplayDialog("Error", "Seat number is not selected");
                        }
                    }
                    catch (Exception ex)
                    {
                        //DisplayDialog("Error", "Error: " + ex.Message);
                    }
                }
                else
                {
                    //DisplayDialog("Error", "This seat has been booked by someone");
                }
            }

            SeatManagement.SelectedSeatButtons.Clear();
        }

        //private async void loadFirebaseButton_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        List<PassengerDetails> allUsers = new List<PassengerDetails>();
        //        allUsers = await firebaseHelper.GetAllUsers();
               

        //    }
        //    catch (Exception theException)
        //    {
        //        // Handle all other exceptions.
        //        DisplayDialog("Error", "Error Message: " + theException.Message);
        //    }

        //}


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

    }
}

