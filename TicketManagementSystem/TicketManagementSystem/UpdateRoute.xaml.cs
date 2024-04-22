using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    public sealed partial class UpdateRoute : Page

    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public UpdateRoute()
        {
            this.InitializeComponent();
            loadData();
            availableseat.Text = "240";
        }

        private async void loadData()
        {
            TrainDetails trainDetail = await firebaseHelper.GetAllRouteByID(ListStaticData.trainID);

            origin.Text = trainDetail.origin;
            destination.Text = trainDetail.destination;
            trainID.Text = trainDetail.trainID;
            price.Text = trainDetail.price;


        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateModify(null);
        }

        private async void UpdateModify(Type train)
        {
            TrainDetails td = await firebaseHelper.GetAllRouteByID(ListStaticData.trainID);

            if (AllTextboxesFilled())
            {
                try
                {
                    td.origin = origin.Text;
                    td.destination = destination.Text;
                    td.trainID = trainID.Text;
                    td.price = price.Text;


                    GlobalVariable.CurrentTrainID = td.trainID;

                    await firebaseHelper.UpdateRoute(td);

                    DisplayDialog("Success", "Update Successfully", train);
                }catch(Exception ex)
                {
                    DisplayDialog("Error", "Error: " + ex.Message, null);

                }
            }
            else
            {
                DisplayDialog("Error", "Please fill in all information ", null);
            }
        }

        private async void ModifyNoUpdate(Type train)
        {
            TrainDetails td = await firebaseHelper.GetAllRouteByID(ListStaticData.trainID);

            if(td.origin != origin.Text || td.destination != destination.Text || td.trainID != trainID.Text)
            {
                ContentDialog noDialog = new ContentDialog
                {
                    Title = "Warning",
                    Content = "You have unsaved the modify data",
                    CloseButtonText = "Cancel",
                    SecondaryButtonText = "OK",
                };

                ContentDialogResult result = await noDialog.ShowAsync();
                if (result == ContentDialogResult.Secondary)
                {
                    UpdateModify(train);

                }
                else if (result == ContentDialogResult.None || result == ContentDialogResult.Primary)
                {
                    this.Frame.Navigate(train);
                }

            }
            else
            {
                this.Frame.Navigate(train);
            }
        
        }

        private bool AllTextboxesFilled()
        {
            // Check if all textboxes are not empty
            return origin.Text != "" &&
                    destination.Text != "" &&
                    trainID != null &&
                    price.Text != "";
                

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TrainManagement));
        }

        private async void DisplayDialog(string title, string content,Type train) // done and navigate to login page
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
