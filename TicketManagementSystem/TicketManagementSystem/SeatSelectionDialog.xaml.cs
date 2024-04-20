﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
using Windows.UI.Xaml.Media.Imaging;
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
            if (ListStaticData.SelectedSeatButtons.Count < ListStaticData.noOfPax)
            {
                // Raise the event with a message indicating insufficient seat selection
                //
                args.Cancel = true; // Prevent the dialog from closing
            }
            else
            {
                List<Button> selectedSeatButtonsCopy = new List<Button>(ListStaticData.SelectedSeatButtons);

                if (selectedSeatButtonsCopy != null && selectedSeatButtonsCopy.Any())
                {
                    foreach (Button selectedSeatButton in selectedSeatButtonsCopy)
                    {
                        string selectedSeat = selectedSeatButton.Tag.ToString();

                        try
                        {
                            if (!string.IsNullOrEmpty(selectedSeat))
                            {
                                //if(  payment successful  )

                                PassengerDetails p = new PassengerDetails();
                                p.IsReserved = true;
                                p.SeatNumber = selectedSeat;

                                await firebaseHelper.AddUser(p);

                                //DisplayDialog("Insert", "Record Inserted Successfully");

                                ListStaticData.SelectedSeatButtons.Remove(selectedSeatButton);

                                //else payment unsuccessful

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
                }
                else
                {
                    //DisplayDialog("Error", "Seat number is not selected");
                }
            }

        }
        
            
           

        //private async void DisplayDialog(string title, string content)
        //{
        //    ContentDialog noDialog = new ContentDialog
        //    {
        //        Title = title,
        //        Content = content,
        //        CloseButtonText = "Ok"
        //    };

        //    ContentDialogResult result = await noDialog.ShowAsync();
        //}

    }

}


